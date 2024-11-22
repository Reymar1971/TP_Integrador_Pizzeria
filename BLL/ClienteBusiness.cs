using DAL;
using Entity;
using System.Transactions;

namespace BLL
{
    public  class ClienteBusiness
    {
        private ClienteDao clienteDao = new ClienteDao();

        // Cargo un cliente en la base de datos
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
                    // Verifico que el telefono no se ingrese duplicado
                    string telefono = cliente.Telefono;
                    Boolean verifico= clienteDao.VerificoTelefono(telefono);
                    if (verifico)
                    {
                        throw new Exception("El telefono ya esta registrado");
                    }
                    else
                    {
                        ClienteDao.Carga(cliente);
                    }
                                       
                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        // Carga una lista de clientes en la base de datos
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

        // Actualiza modificaciones de un ciente en la base de datos
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

        // Borra un cliente de la base de datos
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

        // Lista todos los cientes de la base de datos
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

        // Busca por nombre o aproximacion un cliente en la dase de datos
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
                
    }
}
