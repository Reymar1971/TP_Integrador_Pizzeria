using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{    public class DetallePedidoMapper
    {
        public static DetallePedido Map(SqlDataReader reader, Producto producto)
        {
            DetallePedido detallePedido = new DetallePedido
            {
                IdDetallePedido = Convert.ToInt32(reader["ID_DETALLE_PEDIDO"].ToString()),
                Cantidad = Convert.ToInt32(reader["CANTIDAD"].ToString()),
                PrecioUnitario = Convert.ToDecimal(reader["PRECIO_UNITARIO"].ToString()),
                Producto = producto,
                
            };
            return detallePedido;
        }
    }
}
