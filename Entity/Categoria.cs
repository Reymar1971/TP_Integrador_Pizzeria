namespace Entity
{
    public class Categoria
    {
        private int idCategoria;
        private string nombre;
        private string descripcion;
        private Boolean estado;

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
        
}
