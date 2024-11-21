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
    public class PedidoDao
    {
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

        public static void Carga(Pedido pedido)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Pedidos(ID_CLIENTE,CANTIDAD,FECHA,TOTAL) VALUES(@IdCliente, @Codigo,@Cantidad,@Fecha,@Total)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Parameters.AddWithValue("@IdCliente", pedido.Cliente.IdCliente);
                        commandInserExp.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                        commandInserExp.Parameters.AddWithValue("@Fecha", pedido.Fecha.Date);
                        commandInserExp.Parameters.AddWithValue("@Total", pedido.Total);
                        commandInserExp.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void CargaDetalle(DetallePedido detallePedido)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Detalla_Pedido(ID_PEDIDO,ID_PRODUCTO,CANTIDAD,PRECIO_UNITARIO) VALUES(@IdPedido, @IdProducto,@Cantidad,@PrecioUnitario)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Parameters.AddWithValue("@IdPedido", detallePedido.Pedido.IdPedido);
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
