using Entity;
using Mapper;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DetallePedidoDao
    {
        private ProductoDao productoDao = new ProductoDao();

        // Obtengo el detalle de un pedido de la base de datos por su Id de pedido
        public List<DetallePedido> ObtenerDetallePedidoPorId(int pedidoId)
        {
            List<DetallePedido> detalles = new List<DetallePedido>();

            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                conn.Open();
                string query = "SELECT ID_DETALLE_PEDIDO,ID_PEDIDO,ID_PRODUCTO,CANTIDAD,PRECIO_UNITARIO FROM Detalle_Pedido WHERE ID_PEDIDO = @IdPedido";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPedido", pedidoId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString());
                            Producto producto = productoDao.GetById(idProducto);

                            detalles.Add(DetallePedidoMapper.Map(reader, producto));
                        }
                    }
                }
            }

            return detalles;
        }
    }
}
