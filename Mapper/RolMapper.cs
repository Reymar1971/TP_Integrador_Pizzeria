using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class RolMapper
    {
        public static Rol Map(SqlDataReader reader)
        {
            Rol rol = new Rol();
            rol.IdRol = reader.GetInt32(0);
            rol.Nombre = reader.GetString(1);
            rol.Descripcion = reader.GetString(2);
            
            return rol;
        }
    }
}
