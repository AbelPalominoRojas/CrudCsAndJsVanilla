
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apr.Repository
{
    public class ClientesRepository
    {
        public bool create(Cliente clientes)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_clientes_Insert";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@idcliente", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.AddWithValue("@dni", clientes.Dni);
                    sqlCommand.Parameters.AddWithValue("@nombres", clientes.Nombres);
                    sqlCommand.Parameters.AddWithValue("@apellidos", clientes.Apellidos);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool edit(Cliente clientes)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_clientes_Update";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idcliente", clientes.IdCliente);
                    sqlCommand.Parameters.AddWithValue("@dni", clientes.Dni);
                    sqlCommand.Parameters.AddWithValue("@nombres", clientes.Nombres);
                    sqlCommand.Parameters.AddWithValue("@apellidos", clientes.Apellidos);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool remove(Int32 idcliente)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_clientes_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idcliente", idcliente);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public List<Cliente> findAll()
        {
            List<Cliente> listClientes = new List<Cliente>();

            string sqlQuery = "dbo.USP_clientes_SelectAll";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        Cliente resultClientes = null;

                        while (sqlDataReader.Read())
                        {
                            resultClientes = new Cliente();

                            int idcliente_index = sqlDataReader.GetOrdinal("idcliente");
                            if (!sqlDataReader.IsDBNull(idcliente_index))
                                resultClientes.IdCliente = sqlDataReader.GetInt32(idcliente_index);

                            int dni_index = sqlDataReader.GetOrdinal("dni");
                            if (!sqlDataReader.IsDBNull(dni_index))
                                resultClientes.Dni = sqlDataReader.GetString(dni_index);

                            int nombres_index = sqlDataReader.GetOrdinal("nombres");
                            if (!sqlDataReader.IsDBNull(nombres_index))
                                resultClientes.Nombres = sqlDataReader.GetString(nombres_index);

                            int apellidos_index = sqlDataReader.GetOrdinal("apellidos");
                            if (!sqlDataReader.IsDBNull(apellidos_index))
                                resultClientes.Apellidos = sqlDataReader.GetString(apellidos_index);


                            listClientes.Add(resultClientes);
                        }
                    }
                }
            }

            return listClientes;
        }

        public Cliente find(Int32 idcliente)
        {
            Cliente resultClientes = null;

            string sqlQuery = "dbo.USP_clientes_SelectById";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idcliente", idcliente);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        while (sqlDataReader.Read())
                        {
                            resultClientes = new Cliente();

                            int idcliente_index = sqlDataReader.GetOrdinal("idcliente");
                            if (!sqlDataReader.IsDBNull(idcliente_index))
                                resultClientes.IdCliente = sqlDataReader.GetInt32(idcliente_index);

                            int dni_index = sqlDataReader.GetOrdinal("dni");
                            if (!sqlDataReader.IsDBNull(dni_index))
                                resultClientes.Dni = sqlDataReader.GetString(dni_index);

                            int nombres_index = sqlDataReader.GetOrdinal("nombres");
                            if (!sqlDataReader.IsDBNull(nombres_index))
                                resultClientes.Nombres = sqlDataReader.GetString(nombres_index);

                            int apellidos_index = sqlDataReader.GetOrdinal("apellidos");
                            if (!sqlDataReader.IsDBNull(apellidos_index))
                                resultClientes.Apellidos = sqlDataReader.GetString(apellidos_index);


                        }
                    }
                }
            }

            return resultClientes;
        }

    }
}
