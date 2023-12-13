using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosServices;

namespace ExaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private const string connectionString = "Server=localhost;" + "Port=5432; User Id=postgres; Password=root; Database=Parcial;";
        private UsuarioService servicio;

        public UsuarioController()
        {
            servicio = new UsuarioService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerUsuarioAccion([FromRoute] int id)
        {
            var usuario = servicio.obtenerUsuarioPorId(id);

            if (usuario != null)
            {
                if (usuario.estado == "Bloqueado")
                {
                    return BadRequest("El usuario está bloqueado.");
                }

                return Ok(usuario);
            }

            return NotFound("Usuario no encontrado.");
        }

        [HttpPost]
        public IActionResult InsertarUsuarioAccion([FromBody] Infraestructura.Modelos.UsuarioModel usuario)
        {
            // Validar el estado del usuario antes de realizar la inserción
            if (usuario.estado == "Bloqueado")
            {
                return BadRequest("No se puede insertar un usuario bloqueado.");
            }

            servicio.insertarUsuario(usuario);

            return Created("Se inserto con éxito", usuario);
        }

        [HttpPut]
        public IActionResult ModificarPersonaAccion([FromBody] Infraestructura.Modelos.UsuarioModel usuario)
        {
            servicio.modificarUsuario(usuario);
            return Ok("Se actualizo con éxito");
        }

        [HttpPost("verificar-contrasena")]
        public IActionResult VerificarContrasenaAccion([FromBody] VerificarContrasenaRequest request)
        {
            var resultado = servicio.VerificarContrasena(request.IdUsuario, request.Contrasena);

            if (resultado)
            {
                return Ok("Contraseña correcta");
            }
            else
            {
                return BadRequest("Contraseña incorrecta o usuario bloqueado.");
            }
        }

        public class VerificarContrasenaRequest
        {
            public int IdUsuario { get; set; }
            public string Contrasena { get; set; }
        }
    }
}
