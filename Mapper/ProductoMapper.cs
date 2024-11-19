using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mapper
{
    public class ProductoMapper
    {
        public static Producto Map(SqlDataReader reader, Categoria categoria)
        {
            Producto producto = new Producto
            {
                IdProducto = Convert.ToInt32(reader["ID_PRODUCTO"].ToString()),
                Codigo = reader["CODIGO"].ToString(),
                Nombre = reader["NOMBRE"].ToString(),
                PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString()),
                Stock = Convert.ToInt32(reader["STOCK"].ToString()),
                Estado = Convert.ToBoolean(reader["ESTADO"].ToString()),
                TipoCategoria = categoria
            };
            return producto;

        }
    }
}
