using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosServices;

namespace ExaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private const string connectionString = "Server=localhost;" + "Port=5432; User Id=postgres; Password=root; Database=Parcial;";
        private PersonaService servicio;

        public PersonaController()
        {
            servicio = new PersonaService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerPersonaAccion([FromRoute] int id)
        {
            var persona = servicio.obtenerPersonaPorId(id);
            return Ok(persona);
        }

        [HttpPost]
        public IActionResult InsertarPersonaAccion([FromBody] Infraestructura.Modelos.PersonaModel persona)
        {
            servicio.insertarPersona(persona);

            return Created("Se inserto con exito", persona);
        }

        [HttpPut]

        public IActionResult ModificarPersonaAccion([FromBody] Infraestructura.Modelos.PersonaModel persona)
        {
            servicio.modificarPersona(persona);
            return Ok("Se actualizo con exito");
        }
    }
}
