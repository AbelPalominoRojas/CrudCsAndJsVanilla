
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apr.Repository
{
    public class DetallePedidosRepository
    {
        public bool create(DetallePedido detallePedidos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_detalle_pedidos_Insert";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", detallePedidos.IdPedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", detallePedidos.IdProducto);
                    sqlCommand.Parameters.AddWithValue("@precio", detallePedidos.Precio);
                    sqlCommand.Parameters.AddWithValue("@cantidad", detallePedidos.Cantidad);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool edit(DetallePedido detallePedidos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_detalle_pedidos_Update";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", detallePedidos.IdPedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", detallePedidos.IdProducto);
                    sqlCommand.Parameters.AddWithValue("@precio", detallePedidos.Precio);
                    sqlCommand.Parameters.AddWithValue("@cantidad", detallePedidos.Cantidad);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool remove(Int32 idpedido, Int32 idproducto)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_detalle_pedidos_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", idproducto);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public List<DetallePedido> findAll(Int32 idpedido)
        {
            List<DetallePedido> listDetallePedidos = new List<DetallePedido>();

            string sqlQuery = "dbo.USP_detalle_pedidos_SelectAll";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        DetallePedido resultDetallePedidos = null;
                        Producto producto = null;
                        Categoria categoria = null;

                        while (sqlDataReader.Read())
                        {
                            resultDetallePedidos = new DetallePedido();
                            producto = new Producto();
                            categoria = new Categoria();


                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                            {
                                resultDetallePedidos.IdPedido = sqlDataReader.GetInt32(idpedido_index);
                                producto.IdProducto = resultDetallePedidos.IdProducto;
                            }

                            int idproducto_index = sqlDataReader.GetOrdinal("idproducto");
                            if (!sqlDataReader.IsDBNull(idproducto_index))
                                resultDetallePedidos.IdProducto = sqlDataReader.GetInt32(idproducto_index);

                            int precio_index = sqlDataReader.GetOrdinal("precio");
                            if (!sqlDataReader.IsDBNull(precio_index))
                                resultDetallePedidos.Precio = sqlDataReader.GetDecimal(precio_index);

                            int cantidad_index = sqlDataReader.GetOrdinal("cantidad");
                            if (!sqlDataReader.IsDBNull(cantidad_index))
                                resultDetallePedidos.Cantidad = sqlDataReader.GetInt32(cantidad_index);
                            

                            int idcategoria_index = sqlDataReader.GetOrdinal("idcategoria");
                            if (!sqlDataReader.IsDBNull(idcategoria_index))
                            {
                                producto.IdCategoria = sqlDataReader.GetInt32(idcategoria_index);
                                categoria.IdCategoria = producto.IdCategoria;
                            }

                            //Producto
                            int nombre_index = sqlDataReader.GetOrdinal("nombre");
                            if (!sqlDataReader.IsDBNull(nombre_index))
                                producto.Nombre = sqlDataReader.GetString(nombre_index);

                            int presentacion_index = sqlDataReader.GetOrdinal("presentacion");
                            if (!sqlDataReader.IsDBNull(presentacion_index))
                                producto.Presentacion = sqlDataReader.GetString(presentacion_index);

                            int precioproducto_index = sqlDataReader.GetOrdinal("precioproducto");
                            if (!sqlDataReader.IsDBNull(precioproducto_index))
                                producto.Precio = sqlDataReader.GetDecimal(precioproducto_index);

                            //Categoria
                            int categoria_index = sqlDataReader.GetOrdinal("Categoria");
                            if (!sqlDataReader.IsDBNull(categoria_index))
                                categoria.Nombre = sqlDataReader.GetString(categoria_index);

                           
                            producto.Categoria = categoria;
                            resultDetallePedidos.Producto = producto;

                            listDetallePedidos.Add(resultDetallePedidos);
                        }
                    }
                }
            }

            return listDetallePedidos;
        }

        public DetallePedido find(Int32 idpedido, Int32 idproducto)
        {
            DetallePedido resultDetallePedidos = null;

            string sqlQuery = "dbo.USP_detalle_pedidos_SelectById";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", idproducto);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        while (sqlDataReader.Read())
                        {
                            resultDetallePedidos = new DetallePedido();

                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                                resultDetallePedidos.IdPedido = sqlDataReader.GetInt32(idpedido_index);

                            int idproducto_index = sqlDataReader.GetOrdinal("idproducto");
                            if (!sqlDataReader.IsDBNull(idproducto_index))
                                resultDetallePedidos.IdProducto = sqlDataReader.GetInt32(idproducto_index);

                            int precio_index = sqlDataReader.GetOrdinal("precio");
                            if (!sqlDataReader.IsDBNull(precio_index))
                                resultDetallePedidos.Precio = sqlDataReader.GetDecimal(precio_index);

                            int cantidad_index = sqlDataReader.GetOrdinal("cantidad");
                            if (!sqlDataReader.IsDBNull(cantidad_index))
                                resultDetallePedidos.Cantidad = sqlDataReader.GetInt32(cantidad_index);


                        }
                    }
                }
            }

            return resultDetallePedidos;
        }

    }
}
