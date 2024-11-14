﻿using System;
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
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Usuarios (NombreUsuario, Email, Contrasena) " +
                    "values ('" + objUsuario.Nombre + "','" + objUsuario.Email + "','" + objUsuario.Contrasena + "');";

            if (accion == "Modificar")
                orden = "update Usuarios set Nombre='" + objUsuario.Nombre + "'where Id = "+ objUsuario.Id + "; ";
            // falta la orden de borrar
            SqlCommand cmd = new SqlCommand(orden, conexion);
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
                throw new Exception("Error al listar Usuarios", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        public int BuscarUsuario(string email, string contrasena)
        {
            string orden = "Select NombreUsuario from Usuarios where Email = '" + email + "' and Contrasena = '"+ contrasena +"';";
            
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
                throw new Exception("Error al listar Usuarios", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            DataTable tabla = ds.Tables[0];

            DataRow fila = tabla.Rows[0];

            if (fila["UsuarioId"] != DBNull.Value)
            {
                string IdUsuario = fila["Usuario"].ToString();

                int id = int.Parse(IdUsuario);

                return id;
            }
            else
            {
                return 0;
            }

            
        }

        public Usuario BuscarUsuarioById(int id)
        {
            string orden = "Select * from Usuarios where UsuarioId = " + id + ";";

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
                throw new Exception("Error al listar Usuarios", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            DataTable tabla = ds.Tables[0];

            DataRow fila = tabla.Rows[0];

            string IdUsuarioString = fila["UsuarioId"].ToString();

            int IdUsuario = int.Parse(IdUsuarioString);
            string NombreUsuario = fila["NombreUsuario"].ToString();
            
            Usuario usuario = new Usuario(IdUsuario, NombreUsuario);

            return usuario;
        }

    }
}
