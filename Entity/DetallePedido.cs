using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetallePedido
    {
        private int idDetallePedido;
        private int cantidad;
        private decimal precioUnitario;
        private Producto producto;
        private string nombrePrducto;
        private Pedido pedido;

        public int IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public string NombreProducto { get => producto?.Nombre; }
        public Pedido Pedido { get => pedido; set => pedido = value; }

    }
}
