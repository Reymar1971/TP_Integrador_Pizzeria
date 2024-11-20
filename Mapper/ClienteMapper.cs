using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ClienteMapper
    {
        public static Cliente Map(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = reader.GetInt32(0);
            cliente.NombreApellido = reader.GetString(1);
            cliente.Direccion = reader.GetString(2);
            cliente.Telefono = reader.GetString(3);

            return cliente;
        }
    }
}
