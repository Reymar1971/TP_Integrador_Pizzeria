using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    internal class DetallePedido
    {
        private Pedido pedido;
        private Producto produto;
        private int cantidad;
        private decimal precio;

        public Pedido Pedido { get => pedido; set => pedido = value; }
        public Producto Produto { get => produto; set => produto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
