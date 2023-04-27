using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static Store.Models.Producto;

namespace Store.Models
{
    public class Producto
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public Producto()
        {

        }

        public Producto(int Id, string Nombre, int Precio)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Precio = Precio;

        }

        public List<Producto> ConsultarProductos()
        {

            List<Producto> lista = new List<Producto>();
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(strcon))
            {

                String sql = "SELECT Id,Nombre,Precio FROM Productos";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                            lista.Add(producto);
                        }
                    }
                }
            }
            return lista;
        }


        public Producto ConsultarProducto(int id)
        {

            Producto producto = new Producto();
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(strcon))
            {

                String sql = "SELECT * FROM Productos where Id=" + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            producto.Id = reader.GetInt32(0);
                            producto.Nombre = reader.GetString(1);
                            producto.Precio = reader.GetInt32(2);
                            

                        }
                    }
                }
            }
            return producto;
        }

        public bool CrearProducto(Producto producto)
        {
            int i;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string sqlQuery = $"INSERT INTO Productos VALUES (@Nombre, @Precio)";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                cmd.Parameters.AddWithValue("Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("Precio", producto.Precio);
                
                i = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return i > 0;



        }

        public bool ActualizarProducto(Producto producto)
        {
            int i;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string sqlQuery = $"UPDATE Productos SET Nombre=@Nombre, Precio=@Precio where id=@id";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                cmd.Parameters.AddWithValue("Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("Precio", producto.Precio);
                cmd.Parameters.AddWithValue("Id",producto.Id);

                i = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return i > 0;

        }
        public bool EliminarProducto(int id)
        {
            int i;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string sqlQuery = "DELETE FROM Productos WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("id", id);
                i = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return i > 0;

        }
    }

}