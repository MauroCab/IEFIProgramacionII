using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosConexionBD
    {
        public DatosConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public SqlConnection conexion;
        public string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\piero\RPG_CharMngr.mdf;
        Integrated Security = True; Connect Timeout = 60";

        #region Cadenas de Conexion
        //CadenaConexion de Tiago: @"Data Source=(LocalDB)\MSSQLLocalDB;
        // AttachDbFilename=C:\Users\piero\RPG_CharMngr.mdf;
        // Integrated Security = True; Connect Timeout = 60";

        //CadenaConexion de Mauro: @"Data Source=(LocalDB)\MSSQLLocalDB;
        // AttachDbFilename=D:\Data\a\DB-Prog\RPG_CharMngr.mdf;
        // Integrated Security = True; Connect Timeout = 60";
        #endregion

        public void Abrirconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State ==
                ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexión", e);
            }
        }
        public void Cerrarconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
        }
    }
}

