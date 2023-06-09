using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PruebaMySQLWinForm
{
    public static class Conexion
    {
        private static MySqlConnection mysqlConexion;
        //Para consultas a la base uso query
        private static MySqlCommand query;
        //Credenciales de la conexion
        private static String cadenaConexion = "Server=localhost;Database=bdpruebamysql;Uid=root;Pwd='';";
        //El constructor se ejecutaria solo 1 vez porque es estatica la clase
        static Conexion() {
            mysqlConexion = new MySqlConnection(cadenaConexion);
        }

        public static void Conectar() {
            try {
                Console.WriteLine("Conectando...");
                mysqlConexion.Open();
            } catch(Exception ex) {
                Console.WriteLine("Error: "+ ex);
            } finally {
                mysqlConexion.Close();
            }
        }

        public static void Insertar(Usuario usuario) {
            try
            {
                mysqlConexion.Open();

                Console.WriteLine("Insertando usario...");
                string consulta = "INSERT INTO usuarios (Nombre, Contrasenia,Estado) VALUES (@nombre, @contrasenia,@estado)";
                query = new MySqlCommand(consulta, mysqlConexion);

                //query.Parameters.AddWithValue("@id", usuario.Id);
                query.Parameters.AddWithValue("@nombre", usuario.Nombre);
                query.Parameters.AddWithValue("@contrasenia", usuario.Contrasenia);
                query.Parameters.AddWithValue("@estado", usuario.Estado);
                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar usuario: " + ex);
            }
            finally
            {
                // Cerrar la conexión con la base de datos
                mysqlConexion.Close();
            }
        }
        public static void Eliminar(int id)
        {
            try
            {
                mysqlConexion.Open();

                Console.WriteLine("Eliminando usario...");
               
                string consulta = "UPDATE usuarios SET Estado=0 WHERE Id=@id";

                query = new MySqlCommand(consulta, mysqlConexion);
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar usuario: " + ex);
            }
            finally
            {
                // Cerrar la conexión con la base de datos
                mysqlConexion.Close();
            }
        }

        public static void Modificar(Usuario usuario)
        {
            try
            {
                mysqlConexion.Open();

                Console.WriteLine("Modificando usario...");
                string consulta = "UPDATE usuarios SET Nombre=@nombre, Contrasenia=@contrasenia WHERE Id=@id";
                query = new MySqlCommand(consulta, mysqlConexion);

                query.Parameters.AddWithValue("@id", usuario.Id);
                query.Parameters.AddWithValue("@nombre", usuario.Nombre);
                query.Parameters.AddWithValue("@contrasenia", usuario.Contrasenia);
                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar usuario: " + ex);
            }
            finally
            {
                // Cerrar la conexión con la base de datos
                mysqlConexion.Close();
            }
        }

        public static Usuario Traer(int id) {

            Usuario usuario = null;
            try {
                mysqlConexion.Open();

                Console.WriteLine("Buscando usario...");
                string consulta = "SELECT * FROM usuarios WHERE Id = @id";
                query = new MySqlCommand(consulta, mysqlConexion);
                
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader lectura = query.ExecuteReader();
                if(lectura.Read()) {
                    usuario = new Usuario();

                    usuario.Id = lectura.GetInt32("Id");
                    usuario.Nombre = lectura.GetString("Nombre");
                    usuario.Contrasenia = lectura.GetString("Contrasenia");
                    usuario.Estado = lectura.GetBoolean("Estado");

                }
            } catch (Exception ex) {
                Console.WriteLine("Error al buscar usuario: " + ex);
            } finally {
                // Cerrar la conexión con la base de datos
                mysqlConexion.Close();
            }
            return usuario;
        }

        public static List<Usuario> Traer() {
            List<Usuario> usuarios = new List<Usuario>();
            try {
                mysqlConexion.Open();

                Console.WriteLine("Buscando usario...");
                string consulta = "SELECT * FROM usuarios";
                query = new MySqlCommand(consulta, mysqlConexion);

                MySqlDataReader lectura = query.ExecuteReader();
                while (lectura.Read()) {
                    Usuario usuario = new Usuario();

                    usuario.Id = lectura.GetInt32("Id");
                    usuario.Nombre = lectura.GetString("Nombre");
                    usuario.Contrasenia = lectura.GetString("Contrasenia");
                    usuario.Estado = lectura.GetBoolean("Estado");

                    usuarios.Add(usuario);
                }
            } catch (Exception ex) {
                Console.WriteLine("Error al insertar usuario: " + ex);
            } finally {
                // Cerrar la conexión con la base de datos
                mysqlConexion.Close();
            }
            return usuarios;
        }
    }
}
