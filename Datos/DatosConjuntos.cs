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
    public class DatosConjuntos : DatosConexionBD
    {

        public int abmConjuntos(string accion, Conjunto objConjunto)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Conjuntos values (" + objConjunto.CodProf +
                ",'" + objConjunto.Nombre + "');";
            if (accion == "Modificar")
                orden = "update Conjuntos set Nombre='" + objConjunto.Nombre + "'where CodProf = " + objConjunto.CodProf + "; ";
            // falta la orden de borrar
            OleDbCommand cmd = new OleDbCommand(orden, conexion);
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

        public DataSet listadoConjuntos(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Conjuntos where CodProf = " + int.Parse(cual) + ";";
            else
                orden = "select * from Conjuntos;";
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
