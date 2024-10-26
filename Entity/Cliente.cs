using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cliente
    {
        private int idCliente;
        private string nombreApellido;
        private string direccion;
        private string telefono;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
