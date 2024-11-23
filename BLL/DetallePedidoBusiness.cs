using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class DetallePedidoBusiness
    {
        DetallePedidoDao detallePedidoDao = new DetallePedidoDao();

        public List<DetallePedido> ObtenerDetallePedidoPorId(int IdPedido)
        {
            try
            {
                return detallePedidoDao.ObtenerDetallePedidoPorId(IdPedido);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
