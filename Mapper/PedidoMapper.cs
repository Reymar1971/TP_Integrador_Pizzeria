using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class PedidoMapper
    {
        public static Cliente Map(SqlDataReader reader)
        {
            Cliente cliente = new Cliente
            {
                NombreApellido = reader["NOMBREYAPELLIDO"]?.ToString() ?? string.Empty,
                Direccion = reader["DIRECCION"]?.ToString() ?? string.Empty,
                IdCliente = reader["ID_CLIENTE"] != DBNull.Value ? Convert.ToInt32(reader["ID_CLIENTE"]) : 0
            };
            return cliente;
        }

        public static Pedido Map(SqlDataReader reader, Cliente cliente)
        {
            Pedido pedido = new Pedido
            {
                IdPedido = Convert.ToInt32(reader["ID_PEDIDO"].ToString()),
                Cantidad = Convert.ToInt32(reader["CANTIDAD"].ToString()),
                Fecha = Convert.ToDateTime(reader["FECHA"].ToString()),
                Total = Convert.ToDecimal(reader["TOTAL"].ToString()),
                Cliente = cliente
            };
            return pedido;

        }
    }
}
