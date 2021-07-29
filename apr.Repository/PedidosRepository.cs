
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace apr.Repository
{
    public class PedidosRepository
    {
        public bool create(Pedido pedidos)
        {
            bool result = false;

            using (TransactionScope transactionScope = new TransactionScope())
            {
                //Insert header (Pedido)
                string sqlQuery = "dbo.USP_pedidos_Insert";

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlConnection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idpedido", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.AddWithValue("@idcliente", pedidos.IdCliente);
                        sqlCommand.Parameters.AddWithValue("@fecha", pedidos.Fecha);

                        sqlCommand.ExecuteNonQuery();

                        pedidos.IdPedido = Convert.ToInt32(sqlCommand.Parameters["@idpedido"].Value);

                    }
                }

                //Insert Detail (DetallePedidos)
                foreach (var item in pedidos.DetallePedido)
                {
                    sqlQuery = "dbo.USP_detalle_pedidos_Insert";

                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                        {
                            sqlConnection.Open();
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            sqlCommand.Parameters.AddWithValue("@idpedido", pedidos.IdPedido);
                            sqlCommand.Parameters.AddWithValue("@idproducto", item.IdProducto);
                            sqlCommand.Parameters.AddWithValue("@precio", item.Precio);
                            sqlCommand.Parameters.AddWithValue("@cantidad", item.Cantidad);

                            result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        }
                    }
                }

                transactionScope.Complete();
                result = true;
            }



            return result;
        }

        public bool edit(Pedido pedidos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_pedidos_Update";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", pedidos.IdPedido);
                    sqlCommand.Parameters.AddWithValue("@idcliente", pedidos.IdCliente);
                    sqlCommand.Parameters.AddWithValue("@fecha", pedidos.Fecha);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool remove(Int32 idpedido)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_pedidos_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public List<Pedido> findAll()
        {
            List<Pedido> listPedidos = new List<Pedido>();

            string sqlQuery = "dbo.USP_pedidos_SelectAll";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        Pedido resultPedidos = null;
                        Cliente cliente = null;

                        while (sqlDataReader.Read())
                        {
                            resultPedidos = new Pedido();
                            cliente = new Cliente();

                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                                resultPedidos.IdPedido = sqlDataReader.GetInt32(idpedido_index);

                            int idcliente_index = sqlDataReader.GetOrdinal("idcliente");
                            if (!sqlDataReader.IsDBNull(idcliente_index))
                            {
                                resultPedidos.IdCliente = sqlDataReader.GetInt32(idcliente_index);
                                cliente.IdCliente = resultPedidos.IdCliente;
                            }


                            int fecha_index = sqlDataReader.GetOrdinal("fecha");
                            if (!sqlDataReader.IsDBNull(fecha_index))
                                resultPedidos.Fecha = sqlDataReader.GetDateTime(fecha_index);

                            //Cliente
                            int dni_index = sqlDataReader.GetOrdinal("dni");
                            if (!sqlDataReader.IsDBNull(dni_index))
                                cliente.Dni = sqlDataReader.GetString(dni_index);

                            int nombres_index = sqlDataReader.GetOrdinal("nombres");
                            if (!sqlDataReader.IsDBNull(nombres_index))
                                cliente.Nombres = sqlDataReader.GetString(nombres_index);

                            int apellidos_index = sqlDataReader.GetOrdinal("apellidos");
                            if (!sqlDataReader.IsDBNull(apellidos_index))
                                cliente.Apellidos = sqlDataReader.GetString(apellidos_index);


                            resultPedidos.Cliente = cliente;

                            listPedidos.Add(resultPedidos);
                        }
                    }
                }
            }

            return listPedidos;
        }

        public Pedido find(Int32 idpedido)
        {
            Pedido resultPedidos = null;

            string sqlQuery = "dbo.USP_pedidos_SelectById";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        while (sqlDataReader.Read())
                        {
                            resultPedidos = new Pedido();

                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                                resultPedidos.IdPedido = sqlDataReader.GetInt32(idpedido_index);

                            int idcliente_index = sqlDataReader.GetOrdinal("idcliente");
                            if (!sqlDataReader.IsDBNull(idcliente_index))
                                resultPedidos.IdCliente = sqlDataReader.GetInt32(idcliente_index);

                            int fecha_index = sqlDataReader.GetOrdinal("fecha");
                            if (!sqlDataReader.IsDBNull(fecha_index))
                                resultPedidos.Fecha = sqlDataReader.GetDateTime(fecha_index);


                        }
                    }
                }
            }

            return resultPedidos;
        }

    }
}
