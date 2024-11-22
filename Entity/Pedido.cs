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
        private string telefonoCliente;
        private int cantidad;
        private DateTime fecha;
        private decimal total;
        private List<DetallePedido> detalle; // nueva linea
        
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string NombreCliente { get => Cliente.NombreApellido; }
        public string TelefonoCliente { get => Cliente.Telefono; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
        public List<DetallePedido> Detalle { get => detalle; set => detalle  = value; }
    }
}
