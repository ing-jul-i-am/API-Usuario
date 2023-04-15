using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
}