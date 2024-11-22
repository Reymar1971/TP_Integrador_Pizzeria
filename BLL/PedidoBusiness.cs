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
        static PedidoBusiness()
        {
            TransactionManager.ImplicitDistributedTransactions = true;
        }

        PedidoDao pedidoDao = new PedidoDao();

        public List<Producto> Buscar(string text)
        {
            try
            {
                return PedidoDao.Buscar(text);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Cliente ObtenerClientePorTelefono(string numeroTelefono)
        {
            return PedidoDao.ObtenerClientePorTelefono(numeroTelefono);
        }

        public void Carga(Pedido pedido)
        {
            using (var trx = new TransactionScope())
                try
                {

                    if (pedido.Total == 0)
                    {
                        throw new Exception("El total del pedido no puede ser cero");
                    }
                    pedidoDao.Carga(pedido);

                    trx.Complete();

                }
                catch (Exception ex)
                {

                    throw;
                }

        }

    }
}
