using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public  class ClienteBusiness
    {
        private ClienteDao clienteDao = new ClienteDao();

        public void Carga(Cliente cliente)
        {
            using (var trx = new TransactionScope())
                try
                {
                    if (cliente.NombreApellido.Length == 0)
                    {
                        throw new Exception("Falta ingresar Nombre y Apellido");
                    }
                    if (cliente.Direccion.Length == 0)
                    {
                        throw new Exception("Falta ingresar direccion");
                    }
                    if (cliente.Telefono.Length == 0)
                    {
                        throw new Exception("Falta ingresar número de teléfono");
                    }
                    ClienteDao.Carga(cliente); // Changed to static call
                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        public void CargaVarios(List<Cliente> borradorCliente)
        {
            try
            {
                using (var trx = new TransactionScope())
                {
                    foreach (Cliente cliente in borradorCliente)
                    {
                        Carga(cliente);
                    }
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Actualizar(int id, string nombre, string direccion, string telefono)
        {
            try
            {
                if (nombre.Length == 0)
                {
                    throw new Exception("Falta ingresar Nombre y Apellido");
                }
                if (direccion.Length == 0)
                {
                    throw new Exception("Falta ingresar dirección");
                }
                if (telefono.Length == 0)
                {
                    throw new Exception("Falta ingresar número de teléfono");
                }
                clienteDao.Actualizar(id, nombre, direccion, telefono);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Eliminar(int codigo)
        {
            try
            {
                clienteDao.Eliminar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Cliente> Listar()
        {
            try
            {
                return clienteDao.Listar();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Cliente> Buscar(string text)
        {
            try
            {
                return ClienteDao.Buscar(text);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Los metodos de Activa y Desactiva se de dejan por alguna implementacion futura 
        public void Activar(int codigo)
        {
            try
            {
                clienteDao.Activar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Desactivar(int codigo)
        {
            try
            {
                clienteDao.Desactivar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ExisteNumeroTelefono(string numeroTelefono)
        {
            return clienteDao.ExisteNumeroTelefono(numeroTelefono);
        }
    }
}
