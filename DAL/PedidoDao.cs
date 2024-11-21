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
