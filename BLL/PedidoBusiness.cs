using DAL;
using Entity;
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

        // Lista los productos para armar un pedido
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

        // Lista los pedidos generados
        public List<Pedido> Listar()
        {
            try
            {
                return pedidoDao.Listar();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Elimina un pedido con su detalle
        public void Eliminar(int codigo)
        {
            try
            {
                pedidoDao.EliminarDetallePorPedido(codigo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // Busca en la base de datos el cliente para el pedido
        public Cliente ObtenerClientePorTelefono(string numeroTelefono)
        {
            return PedidoDao.ObtenerClientePorTelefono(numeroTelefono);
        }

        // Valida y carga el pedido 
        public void Carga(Pedido pedido)
        {
            using (var trx = new TransactionScope())
                try
                {
                    if(pedido.Cliente == null)
                    {
                        throw new Exception("Falta ingresar el cliente");
                    }
                    if (pedido.Detalle == null)
                    {
                        throw new Exception("No ha ingresado porductos al pedido!!");
                    }
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
