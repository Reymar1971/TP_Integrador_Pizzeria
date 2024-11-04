using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TipoCategoria
    {
        private int idTipoCategoria;
        private string descripcion;

        public int IdTipoCategoria { get => idTipoCategoria; set => idTipoCategoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
