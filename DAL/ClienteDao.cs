using Entity;
using Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDao
    {
        public static void Carga(Cliente cliente)
        {
            SqlTransaction transaction = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Clientes(NOMBREYAPELLIDO,DIRECCION,TELEFONO) VALUES(@Nombre, @Direccion,@Telefono)";

                    using (SqlCommand commandInserExp = new SqlCommand(insertQuery, conn))
                    {
                        commandInserExp.Transaction = transaction;
                        commandInserExp.Parameters.AddWithValue("@Nombre", cliente.NombreApellido);
                        commandInserExp.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        commandInserExp.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        commandInserExp.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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

        public void Eliminar(int codigo)
        {
            using (SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD()))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "DELETE FROM CLIENTE WHERE ID_CLIENTE = @codigo";
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

        public static List<Cliente> Buscar(string nombreCliente)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());
                using (conn)
                {
                    conn.Open();
                    string query = "SELECT ID_CLIENTE,NOMBREYAPELLIDO,DIRECCION,TELEFONO FROM Clientes WHERE NOMBREYAPELLIDO LIKE '%' + @nombreCliente + '%'";
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

        public bool ExisteNumeroTelefono(string numeroTelefono)
        {
            SqlConnection conn = new SqlConnection(BDConfiguracion.getConectionBD());

            try
            {
                using (conn)
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Clientes WHERE NumeroTelefono = @NumeroTelefono";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@NumeroTelefono", numeroTelefono);
                                        
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
