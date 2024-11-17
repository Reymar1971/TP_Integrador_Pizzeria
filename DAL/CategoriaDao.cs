using Entity;
using Mapper;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoriaDao
    {
        public static List<Categoria> Buscar(string nombreCategoria)
        {
            try
            {
                List<Categoria> categorias = new List<Categoria>();
                SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());
                using (conn)
                {
                    conn.Open();
                    string query = "SELECT ID_CATEGORIA,NOMBRE,DESCRIPCION,ESTADO FROM Categoria WHERE Nombre LIKE '%' + @nombreCategoria + '%'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombrecategoria", nombreCategoria);
                        cmd.ExecuteScalar();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Categoria categoria = new Categoria();
                                categoria.IdCategoria = reader.GetInt32(0);
                                categoria.Nombre = reader.GetString(1);
                                categoria.Descripcion = reader.GetString(2);
                                categoria.Estado = reader.GetBoolean(3);
                                categorias.Add(categoria);
                            }
                        }
                    }
                }
                return categorias;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void Carga(Categoria categoria)
        {
            SqlTransaction transaction = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Categoria(NOMBRE,DESCRIPCION,ESTADO) VALUES(@Nombre, @Descripcion,@estado)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Transaction = transaction;
                        commandInserExp.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                        commandInserExp.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                        commandInserExp.Parameters.AddWithValue("@estado", categoria.Estado);
                        commandInserExp.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Actualizar(int id, string nombre, string descripcion)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "UPDATE Categoria SET NOMBRE=@Nombre,DESCRIPCION=@Descripcion WHERE ID_CATEGORIA=@Id";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void Eliminar(int codigo)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "DELETE FROM CATEGORIA WHERE ID_CATEGORIA = @codigo";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@codigo", codigo);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public List<Categoria> Listar()
        {
            try
            {
                List<Categoria> categorias = new List<Categoria>();
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();
                    string query = "SELECT ID_CATEGORIA,NOMBRE,DESCRIPCION,ESTADO FROM categoria ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categorias.Add(CategoriaMapper.Map(reader));
                            }
                        }
                    }
                }
                return categorias;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
