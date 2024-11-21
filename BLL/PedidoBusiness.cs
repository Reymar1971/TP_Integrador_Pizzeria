using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class PedidoBusiness
    {
        PedidoDao pedidoDao = new PedidoDao();
       
        public Cliente ObtenerClientePorTelefono(string numeroTelefono)
        {
            return PedidoDao.ObtenerClientePorTelefono(numeroTelefono);
        }

        public void Carga(Pedido pedido)
        {
            using (var trx = new TransactionScope())
                try
                {
                    if (pedido.Cliente.Telefono.Length == 0)
                    {
                        throw new Exception("Debe tener ingresado el telefono del cliente");
                    }
                    if (pedido.Cliente.NombreApellido.Length == 0)
                    {
                        throw new Exception("Debe tener ingresado el Nombre del cliente");
                    }
                    if (pedido.Total == 0)
                    {
                        throw new Exception("El total del pedido no puede ser cero");
                    }
                    PedidoDao.Carga(pedido);
                    
                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

        public void CargaDetalle(DetallePedido detallePedido)
        {
            using (var trx = new TransactionScope())
                try
                {
                    PedidoDao.CargaDetalle(detallePedido);

                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }
    }
}
