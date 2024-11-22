using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DAL;

namespace BLL
{
    public class CategoriaBusiness
    {
        private CategoriaDao categoriaDao = new CategoriaDao();

        // Valido y Cargo una categoria en la base de datos
        public void Carga(Categoria categoria)
        {
            using (var trx = new TransactionScope())
                try
                {
                    if (categoria.Nombre.Length == 0)
                    {
                        throw new Exception("Falta ingresar Nombre");
                    }
                    if (categoria.Descripcion.Length == 0)
                    {
                        throw new Exception("Falta ingresar descripcion");
                    }

                    // Verifico que el nombre de la cagoria ya este en la ingresada
                    string nomCategoria = categoria.Nombre;
                    Boolean verifico = categoriaDao.VerificoNombre(nomCategoria.Trim());
                    if (verifico)
                    {
                        throw new Exception("La Categoria ya extiste!!!");
                        
                    }
                    else
                    {
                        CategoriaDao.Carga(categoria);
                    }
                                        
                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        // Valida y Carga una lista de categorias en la base de datos
        public void CargaVarios(List<Categoria> borradorCategoria)
        {
            try
            {
                using (var trx = new TransactionScope())
                {
                    foreach (Categoria categoria in borradorCategoria)
                    {
                        Carga(categoria);
                    }
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // Modifica una categoria
        public void Actualizar(int id, string nombre, string descripcion)
        {
            try
            {
                if (nombre.Length == 0)
                {
                    throw new Exception("Falta ingresar Nombre");
                }
                if (descripcion.Length == 0)
                {
                    throw new Exception("Falta ingresar descripcion");
                }
                categoriaDao.Actualizar(id, nombre, descripcion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        // Elimina una categoria
        public void Eliminar(int codigo)
        {
            try
            {
                categoriaDao.Eliminar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Lista todas las catgorias de la base de datos
        public List<Categoria> Listar()
        {
            try
            {
                return categoriaDao.Listar();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Busca una categoria por su nombre o aproximacion en la base de datos
        public List<Categoria> Buscar(string text)
        {
            try
            {
                return CategoriaDao.Buscar(text);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Activa una categoria
        public void Activar(int codigo)
        {
            try
            {
                categoriaDao.Activar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // desactiva una catgoria
        public void Desactivar(int codigo)
        {
            try
            {
                categoriaDao.Desactivar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
