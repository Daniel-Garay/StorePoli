using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Precio{ get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Promocion { get; set; }
        public string Categoria { get; set; }
       

        public Producto()
        {

        }

        public Producto(int Id, string Nombre, string Precio, string Marca, string Descripcion, string Promocion, string Categoria)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Marca = Marca;
            this.Marca = Precio;
            this.Descripcion = Descripcion;
            this.Promocion = Promocion;
            this.Categoria= Categoria;
        }


        public List<Producto> ConsultarProductos()
        {

            List<Producto> lista = new List<Producto>();
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(strcon))
            {

                String sql = "SELECT Id,Nombre,Precio, Marca,Descripcion,Promocion,Categoria FROM Productos";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          
                            Producto producto = new Producto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
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
                            producto.Precio = reader.GetString(2);
                            producto.Marca = reader.GetString(3);
                            producto.Descripcion = reader.GetString(4);
                            producto.Promocion = reader.GetString(5);
                            producto.Categoria = reader.GetString(6);
                            

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
            string sqlQuery = $"INSERT INTO Productos VALUES (@Nombre, @Precio, @Marca, @Descripcion, @Promocion, @Categoria)";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                cmd.Parameters.AddWithValue("Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("Precio", producto.Precio);
                cmd.Parameters.AddWithValue("Marca", producto.Marca);
                cmd.Parameters.AddWithValue("Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("Promocion", producto.Promocion);
                cmd.Parameters.AddWithValue("Categoria", producto.Categoria);
               
                i = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return i > 0;

        }

        public bool ActualizarProducto(Producto producto)
        {
            int i;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string sqlQuery = $"UPDATE Productos SET Nombre=@Nombre, Precio=@Precio, Marca=@Marca, Descripcion=@Descripcion, Promocion=@Promocion, Categoria=@Categoria where id=@id";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                cmd.Parameters.AddWithValue("Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("Precio", producto.Precio);
                cmd.Parameters.AddWithValue("Marca", producto.Marca);
                cmd.Parameters.AddWithValue("Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("Promocion", producto.Promocion);
                cmd.Parameters.AddWithValue("Categoria", producto.Categoria);
                cmd.Parameters.AddWithValue("Id", producto.Id);

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