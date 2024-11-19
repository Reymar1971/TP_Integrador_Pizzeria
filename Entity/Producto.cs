using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        private int idProducto;
        private string codigo;
        private string nombre;
        private decimal precioVenta;
        private int stock;
        private Boolean estado;
        private Categoria tipoCategoria;
        private string descripcionCategoria;


        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public bool Estado { get => estado; set => estado = value; }
        public Categoria TipoCategoria { get => tipoCategoria; set => tipoCategoria = value; }
        public string DescripcionCategoria { get => tipoCategoria?.Nombre; }
    }
}
