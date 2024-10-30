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
    public class DatosTiposEquipamiento : DatosConexionBD
    {

        public int abmTiposEquipamiento(string accion, TipoEquipamiento objTipoEquipamiento)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into TiposEquipamiento values (" + objTipoEquipamiento.Id +
                ",'" + objTipoEquipamiento.Nombre + "');";
            if (accion == "Modificar")
                orden = "update TiposEquipamiento set Nombre='" + objTipoEquipamiento.Nombre + "'where Id = " + objTipoEquipamiento.Id + "; ";
            // falta la orden de borrar
            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar,borrar o modificar de TiposEquipamiento",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public DataSet listadoTiposEquipamiento(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from TiposEquipamiento where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from TiposEquipamiento;";
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
                throw new Exception("Error al listar TiposEquipamiento", e);
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
