using Entity;
using Microsoft.Data.SqlClient;

namespace Mapper
{
    public class CategoriaMapper
    {
        public static Categoria Map(SqlDataReader reader)
        {
            Categoria categoria = new Categoria();
            categoria.IdCategoria = reader.GetInt32(0);
            categoria.Nombre = reader.GetString(1);
            categoria.Descripcion = reader.GetString(2);
            categoria.Estado = reader.GetBoolean(3);
            
            return categoria;
        }
    }
}
