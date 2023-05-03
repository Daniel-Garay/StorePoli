using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string celular { get; set; }
        public string SegundoNombre { get; set; }
        public string direccion { get; set; }
        public string PrimerApellido { get; set; }
        public string TelFijo { get; set; }
        public string SegundoApellido { get; set; }
        public string email { get; set; }
        public string document { get; set; }
        public string tipoDocumento { get; set; }
        public string genero { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string confirmarcontrasena { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        public bool IsAdmin { get; set; }

        public Usuario()
        {

        }

        public Usuario(int Id, string PrimerNombre, string email, string PrimerApellido, bool IsAdmin)
        {
            this.Id = Id;
            this.PrimerNombre = PrimerNombre;
            this.email = email;
            this.PrimerApellido = PrimerApellido;
            this.IsAdmin = IsAdmin;
        }


        public List<Usuario> ConsultarUsuarios()
        {

            List<Usuario> lista = new List<Usuario>();
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(strcon))
            {

                String sql = "SELECT Id,PrimerNombre,email,PrimerApellido,IsAdmin FROM Usuarios";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4));
                            lista.Add(usuario);
                        }
                    }
                }
            }
            return lista;
        }

        public Usuario ConsultarUsuario(int id)
        {

            Usuario usuario = new Usuario();
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(strcon))
            {

                String sql = "SELECT * FROM Usuarios where Id=" + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario.Id = reader.GetInt32(0);
                            usuario.PrimerNombre = reader.GetString(1);
                            usuario.celular = reader.GetString(2);
                            usuario.SegundoNombre = reader.GetString(3);
                            usuario.direccion = reader.GetString(4);
                            usuario.PrimerApellido = reader.GetString(5);
                            usuario.TelFijo = reader.GetString(6);
                            usuario.SegundoApellido = reader.GetString(7);
                            usuario.email = reader.GetString(8);
                            usuario.document = reader.GetString(9);
                            usuario.tipoDocumento = reader.GetString(10);
                            usuario.genero = reader.GetString(11);
                            usuario.usuario = reader.GetString(12);
                            usuario.contrasena = reader.GetString(13);
                            usuario.confirmarcontrasena = reader.GetString(14);
                            usuario.fechaDeNacimiento = reader.GetDateTime(15);
                            usuario.IsAdmin = reader.GetBoolean(16);

                        }
                    }
                }
            }
            return usuario;
        }

        public bool CrearUsuario(Usuario usuario)
        {
            int i;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string sqlQuery = $"INSERT INTO Usuarios VALUES (@PrimerNombre, @celular, @SegundoNombre,@direccion, @PrimerApellido , @TelFijo ,@SegundoApellido, @email , @document ,@tipoDocumento, @genero, @usuario,@contrasena,@confirmarcontrasena,@fechaDeNacimiento , @IsAdmin)";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                cmd.Parameters.AddWithValue("PrimerNombre", usuario.PrimerNombre);
                cmd.Parameters.AddWithValue("celular", usuario.celular);
                cmd.Parameters.AddWithValue("SegundoNombre", usuario.SegundoNombre);
                cmd.Parameters.AddWithValue("direccion", usuario.direccion);
                cmd.Parameters.AddWithValue("PrimerApellido", usuario.PrimerApellido);
                cmd.Parameters.AddWithValue("TelFijo", usuario.TelFijo);
                cmd.Parameters.AddWithValue("SegundoApellido", usuario.SegundoApellido);
                cmd.Parameters.AddWithValue("email", usuario.email);
                cmd.Parameters.AddWithValue("document", usuario.document);
                cmd.Parameters.AddWithValue("tipoDocumento", usuario.tipoDocumento);
                cmd.Parameters.AddWithValue("genero", usuario.genero);

                cmd.Parameters.AddWithValue("usuario", usuario.usuario);
                cmd.Parameters.AddWithValue("contrasena", usuario.contrasena);
                cmd.Parameters.AddWithValue("confirmarcontrasena", usuario.confirmarcontrasena);
                cmd.Parameters.AddWithValue("fechaDeNacimiento", usuario.fechaDeNacimiento);


                cmd.Parameters.AddWithValue("IsAdmin", usuario.IsAdmin);
                i = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return i > 0;

        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            int i;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string sqlQuery = $"UPDATE Usuarios SET PrimerNombre=@PrimerNombre, celular=@celular, SegundoNombre=@SegundoNombre,direccion=@direccion, PrimerApellido=@PrimerApellido , TelFijo=@TelFijo ,SegundoApellido=@SegundoApellido,  genero=@genero,contrasena=@contrasena,confirmarcontrasena=@confirmarcontrasena,fechaDeNacimiento=@fechaDeNacimiento where id=@id";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                cmd.Parameters.AddWithValue("PrimerNombre", usuario.PrimerNombre);
                cmd.Parameters.AddWithValue("celular", usuario.celular);
                cmd.Parameters.AddWithValue("SegundoNombre", usuario.SegundoNombre);
                cmd.Parameters.AddWithValue("direccion", usuario.direccion);
                cmd.Parameters.AddWithValue("PrimerApellido", usuario.PrimerApellido);
                cmd.Parameters.AddWithValue("TelFijo", usuario.TelFijo);
                cmd.Parameters.AddWithValue("SegundoApellido", usuario.SegundoApellido);
                cmd.Parameters.AddWithValue("genero", usuario.genero);

                cmd.Parameters.AddWithValue("contrasena", usuario.contrasena);
                cmd.Parameters.AddWithValue("confirmarcontrasena", usuario.confirmarcontrasena);
                cmd.Parameters.AddWithValue("fechaDeNacimiento", usuario.fechaDeNacimiento);

                cmd.Parameters.AddWithValue("Id", usuario.Id);

                i = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return i > 0;

        }

        public bool EliminarUsuario(int id)
        {
            int i;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string sqlQuery = "DELETE FROM Usuarios WHERE Id = @id";
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