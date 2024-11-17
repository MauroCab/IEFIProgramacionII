using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosUsuarios : DatosConexionBD
    {
        
        public int abmUsuarios(string accion, Usuario objUsuario)
        {
            if (objUsuario == null)
            {
                throw new ArgumentNullException(nameof(objUsuario), "El objeto Usuario no puede ser nulo.");
            }

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Usuarios (NombreUsuario, Email, Contrasena) " +
                    "values ('" + objUsuario.Nombre + "','" + objUsuario.Email + "','" + objUsuario.Contrasena + "');";

            if (accion == "Modificar")
                orden = "update Usuarios set NombreUsuario = '" + objUsuario.Nombre +
                                        "', Email = '" + objUsuario.Email +
                                        "', Contrasena = '" + objUsuario.Contrasena +
                                        "' where UsuarioId = " + objUsuario.Id + ";";

            if (accion == "RecuperaciónContraseña")
                orden = "update Usuarios set Contrasena='" + objUsuario.Contrasena + "'where UsuarioId = " + objUsuario.Id + ";";

            if (accion == "Baja")
                orden = "Delete from Usuarios where UsuarioId = " + objUsuario.Id + ";";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar, borrar o modificar de Usuarios",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public int BuscarUsuario(string email, string contrasena)
        {
            string orden = "SELECT UsuarioId FROM Usuarios WHERE Email = @Email AND Contrasena = @Contrasena;";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Contrasena", contrasena);

            // Usamos SqlDataReader en lugar de DataSet, lo cual es más eficiente para este caso.
            try
            {
                Abrirconexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read(); // Lee la primera fila
                                       // Aseguramos que el valor de UsuarioId no sea DBNull antes de procesarlo.
                        if (!reader.IsDBNull(reader.GetOrdinal("UsuarioId")))
                        {
                            return reader.GetInt32(reader.GetOrdinal("UsuarioId"));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al buscar usuario", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return 0;
        }

        public int BuscarUsuario(string email)
        {
            string orden = "SELECT UsuarioId FROM Usuarios WHERE Email = @Email;";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@Email", email);
            

            // Usamos SqlDataReader en lugar de DataSet, lo cual es más eficiente para este caso.
            try
            {
                Abrirconexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read(); // Lee la primera fila
                                       // Aseguramos que el valor de UsuarioId no sea DBNull antes de procesarlo.
                        if (!reader.IsDBNull(reader.GetOrdinal("UsuarioId")))
                        {
                            return reader.GetInt32(reader.GetOrdinal("UsuarioId"));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al buscar usuario", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return 0;
        }

        public Usuario BuscarUsuarioById(int id)
        {
            string orden = "SELECT * FROM Usuarios WHERE UsuarioId = @ID ";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@ID", id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Abrirconexion();
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Usuarios", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable tabla = ds.Tables[0];

                DataRow fila = tabla.Rows[0];

                string IdUsuarioString = fila["UsuarioId"].ToString();

                int IdUsuario = int.Parse(IdUsuarioString);
                string NombreUsuario = fila["NombreUsuario"].ToString();
                string MailUsuario = fila["Email"].ToString();
                string ContrasenaUsuario = fila["Contrasena"].ToString();

                Usuario usuario = new Usuario(IdUsuario, NombreUsuario, MailUsuario, ContrasenaUsuario);

                return usuario;
            }
            else
                return null;
        }

        public bool EmailExiste(string email)
        {
            string orden = "SELECT 1 FROM Usuarios WHERE Email = @EMAIL";

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                cmd.Parameters.AddWithValue("@EMAIL", email);

                try
                {
                    Abrirconexion();

                    // Ejecutar y verificar si devuelve algo
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error al verificar si el email existe en la base de datos.", ex);
                }
                finally
                {
                    Cerrarconexion();
                }
            }
        }
        public string GetContrasena(string email)
        {
            string orden = "SELECT * FROM Usuarios WHERE Email = @EMAIL ";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Abrirconexion();
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Usuarios", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable tabla = ds.Tables[0];

                DataRow fila = tabla.Rows[0];

                string ContrasenaUsuario = fila["Contrasena"].ToString();

                return ContrasenaUsuario;
            }
            else
                return null;
        }

    }
}
