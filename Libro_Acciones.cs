using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

using WebAppLibros.BaseDeDatos;
using WebAppLibros.Modelo;

namespace WebAppLibros.Acciones
{
    public class Libro_Acciones
    {
        private static Conexion con = new Conexion();

        public static List<Libro> Consulta_General()
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                con.Abrir();

                string sql = "SeleccionarUsuarios  ";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.IdLibro = int.Parse(reader["IdLibro"].ToString());
                    libro.Titulo = reader["Titulo"].ToString();
                    libro.Autor = reader["Autor"].ToString();
                    libro.Descripcion = reader["Descripcion"].ToString();
                    libro.TotalPaginas = int.Parse(reader["TotalPaginas"].ToString());
                    libro.Precio = double.Parse(reader["Precio"].ToString());

                    libros.Add(libro);
                }

                reader.Close();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return libros;
        }

        public static Libro Consultar_Id(int id)
        {
            Libro libro = new Libro();

            try
            {
                con.Abrir();

                string sql = "SeleccUsuario";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    libro.IdLibro = int.Parse(reader["IdLibro"].ToString());
                    libro.Titulo = reader["Titulo"].ToString();
                    libro.Autor = reader["Autor"].ToString();
                    libro.Descripcion = reader["Descripcion"].ToString();
                    libro.TotalPaginas = int.Parse(reader["TotalPaginas"].ToString());
                    libro.Precio = double.Parse(reader["Precio"].ToString());
                }

                reader.Close();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return libro;
        }

        public static int Insertar(Libro libro)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "InsertarUsuario";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                comando.Parameters.AddWithValue("@autor", libro.Autor);
                comando.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                comando.Parameters.AddWithValue("@totalPaginas", libro.TotalPaginas);
                comando.Parameters.AddWithValue("@precio", libro.Precio);

                resultado = comando.ExecuteNonQuery();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return resultado;
        }

        public static int Modificar(Libro libro)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "ActualizarUsuario ";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                comando.Parameters.AddWithValue("@autor", libro.Autor);
                comando.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                comando.Parameters.AddWithValue("@totalPaginas", libro.TotalPaginas);
                comando.Parameters.AddWithValue("@precio", libro.Precio);
                comando.Parameters.AddWithValue("@id", libro.IdLibro);

                resultado = comando.ExecuteNonQuery();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return resultado;
        }

        public static int Eliminar(int id)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "EliminarUsuario";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@id", id);

                resultado = comando.ExecuteNonQuery();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return resultado;
        }
    }
}