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
    }
}
