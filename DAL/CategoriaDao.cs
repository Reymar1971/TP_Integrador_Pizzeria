using Entity;
using Mapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaDao
    {
        // Cargo una categoria en la base de datos
        public static void Carga(Categoria categoria)
        {
            SqlTransaction transaction = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Categoria(NOMBRE,DESCRIPCION) VALUES(@Nombre, @Descripcion)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Transaction = transaction;
                        commandInserExp.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                        commandInserExp.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                        commandInserExp.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizo una modificacion de una categoria
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

        // Elimono una categoria por si Id
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

        // Listo todas las categorias de la base de datos
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

        // Busca una categaria por el nombre o letras coincidentes
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

        // Busca un categira por su Id
        public Categoria GetById(int id)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conection.Open();
                    string query = "Select ID_CATEGORIA,NOMBRE,DESCRIPCION,ESTADO FROM Categoria WHERE ID_CATEGORIA = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(query, conection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return CategoriaMapper.Map(reader);
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Verifico de no ingresar una categoria que ya esta en la base
        public bool VerificoNombre(string nombre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string query = "SELECT ID_CATEGORIA, NOMBRE FROM Categoria WHERE NOMBRE = @Nombre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return false;
        }
        
        // Estado activo en las categorias
        public void Activar(int codigo)
        {
            SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());

            try
            {
                using (conn)
                {
                    conn.Open();
                    string insertQuery = "UPDATE Categoria SET ESTADO=1 WHERE ID_CATEGORIA=@IdCategoria";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@IdCategoria", codigo);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // Estado desactivo en las categorias
        public void Desactivar(int codigo)
        {
            SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());

            try
            {
                using (conn)
                {
                    conn.Open();
                    string insertQuery = "UPDATE Categoria SET ESTADO=0 WHERE ID_CATEGORIA=@IdCategoria";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@IdCategoria", codigo);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}
