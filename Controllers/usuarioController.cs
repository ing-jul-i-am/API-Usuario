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
        [HttpPost]
        [Route("rest/api/insertarUsuario")]
        public IHttpActionResult insertarUsuarios(requestUsuario model)
        {
            return Ok(new csUsuario().insertarUsuario(model.idUsuario, model.nombre, model.contrasena));
        }
    }
}