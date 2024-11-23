using Entity;
using Mapper;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClienteDao
    {
        // Carga clientes en l abase de datos
        public static void Carga(Cliente cliente)
        {
           try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Clientes(NOMBREYAPELLIDO,DIRECCION,TELEFONO) VALUES(@Nombre, @Direccion,@Telefono)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {

                        cmd.Parameters.AddWithValue("@Nombre", cliente.NombreApellido);
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualiza modificaciones de los clientes en la base de datos
        public void Actualizar(int id, string nombre, string direccion, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "UPDATE Clientes SET NOMBREYAPELLIDO=@Nombre,DIRECCION=@Direccion,TELEFONO=@Telefono WHERE ID_CLIENTE=@Id";
                    using (SqlCommand command = new SqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        // Elimina un cliente en la base de datos
        public void Eliminar(int codigo)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "DELETE FROM CLIENTES WHERE ID_CLIENTE = @codigo";
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

        // Lista todos los clientes de la base de datos
        public List<Cliente> Listar()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();
                    string query = "SELECT ID_CLIENTE,NOMBREYAPELLIDO,DIRECCION,TELEFONO FROM Clientes ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(ClienteMapper.Map(reader));
                            }
                        }
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Busca un nombre o aproximacion en la base de datos
        public static List<Cliente> Buscar(string nombreCliente)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());
                using (conn)
                {
                    conn.Open();
                    string query = "SELECT ID_CLIENTE,NOMBREYAPELLIDO,DIRECCION,TELEFONO FROM Clientes WHERE NOMBREYAPELLIDO LIKE '%' + @nombreCliente + '%' OR TELEFONO LIKE '%' + @nombreCliente + '%'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                        cmd.ExecuteScalar();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(ClienteMapper.Map(reader));
                            }
                        }
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Verifica que no se cargen numeros de telefono duplicados
        public bool VerificoTelefono(string codigo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string query = "SELECT * FROM Clientes WHERE TELEFONO = @NumeroTelefono";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NumeroTelefono", codigo.Trim());

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
          
        // Busca un cliente por su Id
        public Cliente GetById(int id)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conection.Open();
                    string query = "Select ID_CLIENTE,NOMBREYAPELLIDO,DIRECCION,TELEFONO FROM Clientes WHERE ID_CLIENTE = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(query, conection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return ClienteMapper.Map(reader);
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

        // Los metodos de Activa y Desactiva se de dejan por alguna implementacion futura 
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
                        command.Parameters.AddWithValue("@IdOperario", codigo);
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
