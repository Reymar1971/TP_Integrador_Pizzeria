using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RolBusiness
    {
        private RolDao rolDao = new RolDao();

        public List<Rol> Listar()
        {
            try
            {
                return rolDao.Listar();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
