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
    public class DatosConjuntos : DatosConexionBD
    {

        public int abmConjuntos(string accion, Conjunto objConjunto)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Conjuntos values (" + objConjunto.Id +
                ",'" + objConjunto.Nombre + "');";
            if (accion == "Modificar")
                orden = "update Conjuntos set Nombre='" + objConjunto.Nombre + "'where Id = " + objConjunto.Id + "; ";
            // falta la orden de borrar
            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar,borrar o modificar de Conjuntos",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
        public int BuscarConjunto(string Nombre)
        {
            string orden = "SELECT ConjuntoId FROM Conjuntos WHERE Nombre = @Nombre";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);

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
        public DataSet listadoConjuntos(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Conjuntos where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Conjuntos;";
            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Conjuntos", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

    }
}
