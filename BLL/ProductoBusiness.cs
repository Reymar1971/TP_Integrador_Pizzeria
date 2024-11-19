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
    public  class ProductoBusiness
    {
        private ProductoDao productoDao = new ProductoDao();

        public void Carga(Producto producto)
        {
            using (var trx = new TransactionScope())
                try
                {
                    if (producto.Nombre.Length == 0)
                    {
                        throw new Exception("Falta ingresar Nombre");
                    }
                    if (producto.Codigo.Length == 0)
                    {
                        throw new Exception("Falta ingresar Código");
                    }
                    if (producto.Stock > 0)
                    {
                        throw new Exception("El Stock no puede ser menor que cero");
                    }
                    if (producto.PrecioVenta <= 0)
                    {
                        throw new Exception("Precio de venta incorrecto");
                    }
                    if (producto.TipoCategoria.IdCategoria >=0)
                    {
                        throw new Exception("Falta ingresar Categoría");
                    }
                    ProductoDao.Carga(producto); // Changed to static call
                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        public void CargaVarios(List<Producto> borradorProducto)
        {
            try
            {
                using (var trx = new TransactionScope())
                {
                    foreach (Producto producto in borradorProducto)
                    {
                        Carga(producto);
                    }
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Actualizar(int id, string codigo, string nombre, decimal precioVenta, int stock, int tipoCategoria)
        {
            try
            {
                if (nombre.Length == 0)
                {
                    throw new Exception("Falta ingresar Nombre");
                }
                if (codigo.Length == 0)
                {
                    throw new Exception("Falta ingresar Código");
                }
                if (stock > 0)
                {
                    throw new Exception("El Stock no puede ser menor que cero");
                }
                if (precioVenta <= 0)
                {
                    throw new Exception("Precio de venta incorrecto");
                }
                if (tipoCategoria >= 0)
                {
                    throw new Exception("Falta ingresar Categoría");
                }
                productoDao.Actualizar(id, tipoCategoria, codigo, nombre, precioVenta, stock);
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
                productoDao.Eliminar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Producto> Listar()
        {
            try
            {
                return productoDao.Listar();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Producto> Buscar(string text)
        {
            try
            {
                return ProductoDao.Buscar(text);
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
                productoDao.Activar(codigo);
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
                productoDao.Desactivar(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
