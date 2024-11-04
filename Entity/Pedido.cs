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
        private int cantidad;
        private string codigoComprobante;
        private DateTime fecha;
        private decimal total;
        private Cliente Cliente;
        private Producto Producto;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string CodigoComprobante { get => codigoComprobante; set => codigoComprobante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
        public Cliente Cliente1 { get => Cliente; set => Cliente = value; }
        public Producto Producto1 { get => Producto; set => Producto = value; }
    }
}
