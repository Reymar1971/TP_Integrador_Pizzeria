using DAL;
using Entity;

namespace BLL
{
    public  class DetallePedidoBusiness
    {
        DetallePedidoDao detallePedidoDao = new DetallePedidoDao();

        // Odtengo el detalle del pedido por su Id
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
