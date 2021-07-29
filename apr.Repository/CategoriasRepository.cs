
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apr.Repository
{
    public class CategoriasRepository
    {
        public bool create(Categoria categorias)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_categorias_Insert";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@idcategoria", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.AddWithValue("@nombre", categorias.Nombre);
                    sqlCommand.Parameters.AddWithValue("@descripcion",(object) categorias.Descripcion ?? DBNull.Value);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool edit(Categoria categorias)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_categorias_Update";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idcategoria", categorias.IdCategoria);
                    sqlCommand.Parameters.AddWithValue("@nombre", categorias.Nombre);
                    sqlCommand.Parameters.AddWithValue("@descripcion", (object)categorias.Descripcion ?? DBNull.Value);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool remove(Int32 idcategoria)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_categorias_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idcategoria", idcategoria);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public List<Categoria> findAll()
        {
            List<Categoria> listCategorias = new List<Categoria>();

            string sqlQuery = "dbo.USP_categorias_SelectAll";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        Categoria resultCategorias = null;

                        while (sqlDataReader.Read())
                        {
                            resultCategorias = new Categoria();

                            int idcategoria_index = sqlDataReader.GetOrdinal("idcategoria");
                            if (!sqlDataReader.IsDBNull(idcategoria_index))
                                resultCategorias.IdCategoria = sqlDataReader.GetInt32(idcategoria_index);

                            int nombre_index = sqlDataReader.GetOrdinal("nombre");
                            if (!sqlDataReader.IsDBNull(nombre_index))
                                resultCategorias.Nombre = sqlDataReader.GetString(nombre_index);

                            int descripcion_index = sqlDataReader.GetOrdinal("descripcion");
                            if (!sqlDataReader.IsDBNull(descripcion_index))
                                resultCategorias.Descripcion = sqlDataReader.GetString(descripcion_index);


                            listCategorias.Add(resultCategorias);
                        }
                    }
                }
            }

            return listCategorias;
        }

        public Categoria find(Int32 idcategoria)
        {
            Categoria resultCategorias = null;

            string sqlQuery = "dbo.USP_categorias_SelectById";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idcategoria", idcategoria);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        while (sqlDataReader.Read())
                        {
                            resultCategorias = new Categoria();

                            int idcategoria_index = sqlDataReader.GetOrdinal("idcategoria");
                            if (!sqlDataReader.IsDBNull(idcategoria_index))
                                resultCategorias.IdCategoria = sqlDataReader.GetInt32(idcategoria_index);

                            int nombre_index = sqlDataReader.GetOrdinal("nombre");
                            if (!sqlDataReader.IsDBNull(nombre_index))
                                resultCategorias.Nombre = sqlDataReader.GetString(nombre_index);

                            int descripcion_index = sqlDataReader.GetOrdinal("descripcion");
                            if (!sqlDataReader.IsDBNull(descripcion_index))
                                resultCategorias.Descripcion = sqlDataReader.GetString(descripcion_index);


                        }
                    }
                }
            }

            return resultCategorias;
        }

    }
}
