using Entity;
using Mapper;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ProductoDao
    {
        private CategoriaDao categoriaDao = new CategoriaDao();

        // Cargo un producto a la base de datos
        public static void Carga(Producto producto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Productos(ID_CATEGORIA,CODIGO,NOMBRE,PRECIO_VENTA,STOCK) VALUES(@IdCategoria, @Codigo,@Nombre,@PrecioVenta,@Stock)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Parameters.AddWithValue("@IdCategoria", producto.TipoCategoria.IdCategoria);
                        commandInserExp.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        commandInserExp.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        commandInserExp.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        commandInserExp.Parameters.AddWithValue("@Stock", producto.Stock);
                        commandInserExp.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizo una modificacion de un producto en la base de datos
        public void Actualizar(int id, int idCategoria, string codigo, string nombre, decimal precioVenta, int stock)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "UPDATE Productos SET ID_CATEGORIA=@IdCategoria,CODIGO=@Codigo,NOMBRE=@Nombre,PRECIO_VENTA=@PrecioVenta,STOCK=@Stock WHERE ID_PRODUCTO=@Id";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                        command.Parameters.AddWithValue("@Stock", stock);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        // Elimina un producto de la base de datos
        public void Eliminar(int codigo)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "DELETE FROM Productos WHERE ID_PRODUCTO = @codigo";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@codigo", codigo);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        //Lista todos los productos de la base de datos
        public List<Producto> Listar()
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();
                    string query = "SELECT ID_PRODUCTO,ID_CATEGORIA,CODIGO,NOMBRE,PRECIO_VENTA,STOCK,ESTADO FROM Productos";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idCategoria = Convert.ToInt32(reader["ID_CATEGORIA"].ToString());
                                Categoria categoria = categoriaDao.GetById(idCategoria);
                                Producto producto = ProductoMapper.Map(reader, categoria);
                                productos.Add(producto);
                            }
                        }
                    }
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Busca en la base de datos un producto por su nombre o aproximacion
        public static List<Producto> Buscar(string nombreProducto)
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());
                using (conn)
                {
                    conn.Open();
                    string query = "SELECT ID_PRODUCTO,ID_CATEGORIA,CODIGO,NOMBRE,PRECIO_VENTA,STOCK,ESTADO FROM Productos WHERE NOMBRE LIKE '%' + @nombreProducto + '%'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                        cmd.ExecuteScalar();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idCategoria = Convert.ToInt32(reader["ID_CATEGORIA"].ToString());
                                Categoria categoria = new CategoriaDao().GetById(idCategoria);
                                Producto producto = ProductoMapper.Map(reader, categoria);
                                productos.Add(producto);
                            }
                        }
                    }
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se verifica la carga duplicad de un codigo de producto
        public bool VerificoCodigo(string codigo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string query = "SELECT * FROM Productos WHERE CODIGO = @Codigo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return false;
        }

        // Borrado logico de un producto
        public void Activar(int codigo)
        {
            SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());

            try
            {
                using (conn)
                {
                    conn.Open();
                    string insertQuery = "UPDATE Productos SET ESTADO=1 WHERE ID_PRODUCTO=@IdProducto";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@IdProducto", codigo);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // Desactivo el borrado logico de un producto
        public void Desactivar(int codigo)
        {
            SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());

            try
            {
                using (conn)
                {
                    conn.Open();
                    string insertQuery = "UPDATE Productos SET ESTADO=0 WHERE ID_PRODUCTO=@IdProducto";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@IdProducto", codigo);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // Busco un producto por su Id
        public Producto GetById(int idProducto)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conection.Open();
                    string query = "Select ID_PRODUCTO,ID_CATEGORIA,CODIGO,NOMBRE,PRECIO_VENTA,STOCK,ESTADO FROM Productos WHERE ID_PRODUCTO = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(query, conection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", idProducto);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            Producto producto = null;
                            while (reader.Read())
                            {
                                int idCategoria = Convert.ToInt32(reader["ID_CATEGORIA"].ToString());
                                Categoria categoria = categoriaDao.GetById(idCategoria);
                                producto = ProductoMapper.Map(reader, categoria);
                            }
                            return producto;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
