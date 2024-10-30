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
    public class DatosPersonajes : DatosConexionBD
    {

        public int abmPersonajes(string accion, Personaje objPersonaje)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Personajes values (" + objPersonaje.Id +
                ",'" + objPersonaje.Nombre + "');";
            if (accion == "Modificar")
                orden = "update Personajes set Nombre='" + objPersonaje.Nombre + "'where Id = " + objPersonaje.Id + "; ";
            // falta la orden de borrar
            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar,borrar o modificar de Personajes",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoPersonajes(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Personajes where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Personajes;";
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
                throw new Exception("Error al listar Personajes", e);
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
