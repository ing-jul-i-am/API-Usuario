using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API_Usuario.Models.Usuario;
using static API_Usuario.Models.Usuario.csEstructuraUsuario;

namespace API_Usuario.Controllers
{
    public class usuarioController : ApiController
    {
        //Metodo para insertar
        [HttpPost]
        [Route("rest/api/insertarUsuario")]
        public IHttpActionResult insertarUsuarios(requestUsuario model)
        {
            return Ok(new csUsuario().insertarUsuario(model.idUsuario, model.nombre, model.contrasena));
        }

        //Metodo para actualizar
        [HttpPost]
        [Route("rest/api/actualizarUsuario")]
        public IHttpActionResult actualizarUsuarios(requestUsuario model)
        {
            return Ok(new csUsuario().actualizarUsuario(model.idUsuario, model.nombre, model.contrasena));
        }

        //Metodo para eliminar
        [HttpPost]
        [Route("rest/api/eliminarUsuario")]
        public IHttpActionResult eliminarUsuarios(requestEliminarArticulo model)
        {
            return Ok(new csUsuario().eliminarUsuario(model.idUsuario));
        }

        //Metodo para consultar todo
        [HttpGet]
        [Route("rest/api/listarUsuarios")]
        public IHttpActionResult listarUsuarios()
        {
            return Ok(new csUsuario().listarUsuarios());
        }

        //Metodo para consultar especifico
        [HttpGet]
        [Route("rest/api/listarUsuariosPorID")]
        public IHttpActionResult listarUsuarios(int idUsuario)
        {
            return Ok(new csUsuario().listarUsuariosPorID(idUsuario));
        }
    }
}