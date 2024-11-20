using Entity;
using Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class ProductoDao
    {
        private CategoriaDao categoriaDao = new CategoriaDao();

        public static void Carga(Producto producto)
        {
            SqlTransaction transaction = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Productos(ID_CATEGORIA,CODIGO,NOMBRE,PRECIO_VENTA,STOCK) VALUES(@IdCategoria, @Codigo,@Nombre,@PrecioVenta,@Stock)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Transaction = transaction;
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

        public static List<Producto> Buscar(string nombreProducto)
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());
                using (conn)
                {
                    conn.Open();
                    string query = "SELECT ID_PRODUCTO,ID_CATEGORIA,CODIGO,NOMBRE,PRECIO_VENTA,STOCK FROM Productos WHERE NOMBRE LIKE '%' + @nombreProducto + '%'";
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

    }
}
