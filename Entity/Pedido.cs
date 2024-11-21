using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pedido
    {
        private int idPedido;
        private Cliente cliente;
        private string nombreCliente;
        private int cantidad;
        private string numeroComprobante;
        private DateTime fecha;
        private decimal total;
        private List<DetallePedido> detallePedido;
        
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string NombreCliente { get => Cliente.NombreApellido; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string NumeroComprobante { get => NumeroComprobante; set => NumeroComprobante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
        internal List<DetallePedido> DetallePedido { get => detallePedido; set => detallePedido = value; }
    }
}
