using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static API_Usuario.Models.Usuario.csEstructuraUsuario;

namespace API_Usuario.Models.Usuario
{
    public class csUsuario
    {
        public responseUsuario insertarUsuario(int idUsuario, string nombre, string contrasena)
        {
            responseUsuario result = new responseUsuario();

            //Con esta linea vamos a traer todos los datos para ingresar a la base de datos
            //El nombre del servidor, que base de datos se esta usando, usuario, password, etc.

            string conexion = "";
            SqlConnection con = null;
            
            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "Insert into USUARIO values " +
                    "(" + idUsuario + ", '" + nombre + "', '" + contrasena + "')";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descriptionRespuest = "Operacion realizada exitosamente";
            } 
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descriptionRespuest = "Ocurrio un error durante la transaccion. Detalles: " + ex.Message.ToString();
            }
            

            con.Close();

            return result;
        }

        public responseUsuario actualizarUsuario(int idUsuario, string nombre, string contrasena)
        {
            responseUsuario result = new responseUsuario();

            //Con esta linea vamos a traer todos los datos para actualizar a la base de datos
            //El nombre del servidor, que base de datos se esta usando, usuario, password, etc.

            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "update USUARIO set nombre='" + nombre + "', contrasena='" + contrasena + "' where idUsuario=" + idUsuario + ";";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descriptionRespuest = "Operacion realizada exitosamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descriptionRespuest = "Ocurrio un error durante la transaccion. Detalles: " + ex.Message.ToString();
            }


            con.Close();

            return result;
        }

        public responseUsuario eliminarUsuario(int idUsuario)
        {
            responseUsuario result = new responseUsuario();

            //Con esta linea vamos a traer todos los datos para actualizar a la base de datos
            //El nombre del servidor, que base de datos se esta usando, usuario, password, etc.

            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "delete from USUARIO where idUsuario=" + idUsuario + ";";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descriptionRespuest = "Operacion realizada exitosamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descriptionRespuest = "Ocurrio un error durante la transaccion. Detalles: " + ex.Message.ToString();
            }


            con.Close();

            return result;
        }

        public DataSet listarUsuarios()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string cadena = "select * from USUARIO;";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Lista";
                return dsi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet listarUsuariosPorID(int idUsuario)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string cadena = "select * from USUARIO where idUsuario=" + idUsuario + ";";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Elemento";
                return dsi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}