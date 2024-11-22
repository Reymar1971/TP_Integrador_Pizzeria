using DAL;
using Entity;
using System.Transactions;

namespace BLL
{
    public  class ProductoBusiness
    {
        private ProductoDao productoDao = new ProductoDao();

        // Se valida y se Carga de un producto 
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
                    if (producto.Stock < 0)
                    {
                        throw new Exception("El Stock no puede ser menor que cero");
                    }
                    if (producto.PrecioVenta <= 0)
                    {
                        throw new Exception("Precio de venta incorrecto");
                    }
                    if (producto.TipoCategoria.IdCategoria <=0)
                    {
                        throw new Exception("Falta ingresar Categoría");
                    }
                    // Verifico que el codio de producto no este usado
                    string codigo = producto.Codigo;
                    Boolean verifico = productoDao.VerificoCodigo(codigo);
                    if (verifico)
                    {
                        throw new Exception("Codigo de producto ya usado!!!");
                    }
                    else
                    {
                        ProductoDao.Carga(producto);
                    }
                    
                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        // Se valida y se cargan una lista de productos
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

        // Se actualiza una modificacion de un producto
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
                if (stock < 0)
                {
                    throw new Exception("El Stock no puede ser menor que cero");
                }
                if (precioVenta <= 0)
                {
                    throw new Exception("Precio de venta incorrecto");
                }
                if (tipoCategoria <= 0)
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

        // Se elimina un producto
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

        // Listado de todos los productos
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

        // Busqueda de un producto por su nombre o aproximacion
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

        // Borrado logico de un producto
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

        // Desactiva el borrado logico de un producto
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
