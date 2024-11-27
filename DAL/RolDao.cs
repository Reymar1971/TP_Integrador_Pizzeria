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
    public class RolDao
    {
        public List<Rol> Listar()
        {
            try
            {
                List<Rol> roles = new List<Rol>();
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();
                    string query = "SELECT ID_ROL,NOMBRE,DESCRIPCION FROM Rol";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                roles.Add(RolMapper.Map(reader));
                            }
                        }
                    }
                }
                return roles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
