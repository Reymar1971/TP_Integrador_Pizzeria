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
                    categoriaDao.VerificoNombre(nomCategoria);
                    if (categoria != null)
                    {
                        throw new Exception("La categoria ya existe !!!");
                    }

                    CategoriaDao.Carga(categoria);
                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

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
