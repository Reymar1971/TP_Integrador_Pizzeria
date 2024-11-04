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
        private Cliente cliente;
        private Producto producto;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string CodigoComprobante { get => codigoComprobante; set => codigoComprobante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Producto Producto { get => producto; set => producto = value; }
    }
}
