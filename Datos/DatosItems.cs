using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.ComponentModel;

namespace Datos
{
    public class DatosItems : DatosConexionBD
    {

        public int abmItems(string accion, Item objItem)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Items values (" + objItem.Id +
                ",'" + objItem.Nombre + "');";
            if (accion == "Modificar")
                orden = "update Items set Nombre='" + objItem.Nombre + "'where Id = " + objItem.Id + "; ";
            // falta la orden de borrar
            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar,borrar o modificar de Items",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public void AgregarTodosLosItems(int idPersonaje, List<Item> items)
        {
            try
            {
                foreach (Item item in items)
                {
                    AgregarItemAlInventario(idPersonaje, item.Id);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al agregar items al inventario", e);
            }
            
        }

        /// <summary>
        /// Inserta items al inventario del personaje recien creado
        /// </summary>
        /// <param name="idPersonaje"></param>
        public void AgregarItemAlInventario(int idPersonaje, int idItem)
        {
            int resultado = -1;
            string orden = string.Empty;

            orden = "INSERT INTO Inventario (PersonajeId, ItemId, Cantidad, Equipado)" +
                " VALUES (" + idPersonaje + "," + idItem + ", 1, true);";
            
            // falta la orden de borrar
            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar,borrar o modificar de Items", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            

        }

        public DataSet listadoItemsEnInventario(int idPersonaje)
        {
            string orden = string.Empty;
            
            orden = "select * from Inventario where PersonajeId = " + idPersonaje + " AND Equipado = " + false + ";";
            
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
                throw new Exception("Error al listar Items", e);
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
