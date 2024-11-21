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
            {
                orden = "insert into Personajes (UsuarioId, Nombre, Nivel, Clase, Salud, Energia, Ataque, Defensa, Evasion, CascoId, PantId, GuantesId, " +
                    "ArmaduraId, ArmaId, EscudoId, FechaCreacion) " +
                "values (" + objPersonaje.IdUsuario + ", '" + objPersonaje.Nombre + "', " + objPersonaje.Nivel + ", '" + objPersonaje.Clase
                + "', " + objPersonaje.Salud + ", " + objPersonaje.Energia + ", " + objPersonaje.Ataque + ","
                + objPersonaje.Defensa + ", " + objPersonaje.Evasion + ", " + objPersonaje.CascoEq.Id + ", " + objPersonaje.PantEq.Id + ", "
                + objPersonaje.GuantesEq.Id + ", " + objPersonaje.ArmaduraEq.Id + ",  " + objPersonaje.ArmaEq.Id + ",  "
                + objPersonaje.EscudoEq.Id + ",  " + "NOW()" + ");";
            }

            if (accion == "Modificar")
                orden = "update Personajes set Nivel = '" + objPersonaje.Nivel +
                                        "', Salud = '" + objPersonaje.Salud +
                                        "', Energia = '" + objPersonaje.Energia +
                                        "', Ataque = '" + objPersonaje.Ataque +
                                        "', Defensa = '" + objPersonaje.Defensa +
                                        "', Evasion = '" + objPersonaje.Evasion +
                                        "', CascoId = '" + objPersonaje.CascoEq.Id +
                                        "', PantId = '" + objPersonaje.PantEq.Id +
                                        "', GuantesId = '" + objPersonaje.GuantesEq.Id +
                                        "', ArmaduraId = '" + objPersonaje.ArmaduraEq.Id +
                                        "', ArmaId = '" + objPersonaje.ArmaEq.Id +
                                        "', EscudoId = '" + objPersonaje.EscudoEq.Id +
                                        "'where Id = " + objPersonaje.Id + "; ";

            if (accion == "Baja")
                orden = "Delete from Personajes where PersonajeId = " + objPersonaje.Id + ";";

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
