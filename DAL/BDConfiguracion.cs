using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static class BDConfiguracion
    {
        private const string BD_CONFIG_NAME = "BDConexion";

        public static string getConectionBD()
        {
            return ConfigurationManager.ConnectionStrings[BD_CONFIG_NAME].ConnectionString;
        }

    }
}
