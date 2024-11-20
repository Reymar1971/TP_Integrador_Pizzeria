using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidoBusiness
    {
        PedidoDao pedidoDao = new PedidoDao();

        public Cliente ObtenerClientePorTelefono(string numeroTelefono)
        {
            return PedidoDao.ObtenerClientePorTelefono(numeroTelefono);
        }
    }
}
