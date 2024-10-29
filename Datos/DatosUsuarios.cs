using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Entidades;

namespace Datos
{
    public class DatosUsuarios : DatosConexionBD
    {
        
        public int abmUsuarios(string accion, Usuario objUsuario)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Usuarios values (" + objUsuario.Id +
                ",'" + objUsuario.Nombre + "');";
            if (accion == "Modificar")
                orden = "update Usuarios set Nombre='" + objUsuario.Nombre + "'where Id = "+ objUsuario.Id + "; ";
            // falta la orden de borrar
            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar,borrar o modificar de Usuarios",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoUsuarios(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Usuarios where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Usuarios;";
            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
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
            return ds;
        }

    }
}
