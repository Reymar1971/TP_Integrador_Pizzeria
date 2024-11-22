using Entity;
using Mapper;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class PedidoDao
    {
        private ClienteDao clienteDao = new ClienteDao();

        // Este procedimiento no lista los productos que tengan stock en cero
        public static List<Producto> Buscar(string nombreProducto)
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());
                using (conn)
                {
                    conn.Open();
                    string query = "SELECT ID_PRODUCTO,ID_CATEGORIA,CODIGO,NOMBRE,PRECIO_VENTA,STOCK,ESTADO FROM Productos WHERE NOMBRE LIKE '%' + @nombreProducto + '%' AND STOCK > 0";
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

        // Lista todos los pedidos de la base de datos
        public List<Pedido> Listar()
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();
                    string query = "SELECT ID_PEDIDO,ID_CLIENTE,CANTIDAD,FECHA,TOTAL FROM Pedidos";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idCliente = Convert.ToInt32(reader["ID_CLIENTE"].ToString());
                                Cliente cliente = clienteDao.GetById(idCliente);
                                Pedido pedido = PedidoMapper.Map(reader, cliente);
                                pedidos.Add(pedido);
                            }
                        }
                    }
                }
                return pedidos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        // Elimina los pedidos en la base de datos
        public void EliminarPedido(int codigo)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Pedidos WHERE ID_PEDIDO = @codigo";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.ExecuteNonQuery();
                    }
                                       
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        // Elimina los detalles del pedido que se quiere eliminar 
        public void EliminarDetallePorPedido(int idPedido)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Detalle_Pedido WHERE ID_PEDIDO = @idPedido";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPedido", idPedido);
                        cmd.ExecuteNonQuery();

                        // Eliminar el pedido
                        EliminarPedido(idPedido);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        // Verifica el cliente en la gestion de Pedidos
        public static Cliente ObtenerClientePorTelefono(string numeroTelefono)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                string query = "SELECT NOMBREYAPELLIDO, DIRECCION, ID_CLIENTE FROM Clientes WHERE TELEFONO = @NumeroTelefono";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@NumeroTelefono", numeroTelefono);

                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return PedidoMapper.Map(reader);
                    }
                }
            }
            return null;
        }

        // Carga un pedido en la base de datos
        public void Carga(Pedido pedido)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Pedidos(ID_CLIENTE,CANTIDAD,FECHA,TOTAL) VALUES(@IdCliente,@Cantidad,@Fecha,@Total); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", pedido.Cliente.IdCliente);
                        cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                        cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha.Date);
                        cmd.Parameters.AddWithValue("@Total", pedido.Total);
                    
                        int nuevoIdPedido = Convert.ToInt32(cmd.ExecuteScalar());

                        foreach (var detalle in pedido.Detalle)
                        {
                            CargaDetalle(detalle, nuevoIdPedido);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Carga el datelle del pedido en la base de datos
        public void CargaDetalle(DetallePedido detallePedido, int idPedido)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Detalle_Pedido(ID_PEDIDO,ID_PRODUCTO,CANTIDAD,PRECIO_UNITARIO) VALUES(@IdPedido, @IdProducto,@Cantidad,@PrecioUnitario)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Parameters.AddWithValue("@IdPedido", idPedido);
                        commandInserExp.Parameters.AddWithValue("@IdProducto", detallePedido.Producto.IdProducto);
                        commandInserExp.Parameters.AddWithValue("@Cantidad", detallePedido.Cantidad);
                        commandInserExp.Parameters.AddWithValue("@PrecioUnitario", detallePedido.PrecioUnitario);
                        commandInserExp.ExecuteNonQuery();
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
