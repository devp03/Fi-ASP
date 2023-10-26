using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosServices;

namespace ExaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadController : ControllerBase
    {
        private const string connectionString = "Server=localhost;" + "Port=5432; User Id=postgres; Password=root; Database=Parcial;";
        private CiudadService servicio;

        public CiudadController()
        {
            servicio = new CiudadService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerCiudadAccion([FromRoute] int id)
        {
            var ciudad = servicio.obtenerCiudadPorId(id);
            return Ok(ciudad);
        }

        [HttpPost]
        public IActionResult InsertarCiudadAccion([FromBody] Infraestructura.Modelos.CiudadModel ciudad)
        {
            servicio.insertarCiudad(ciudad);

            return Created("Se inserto con exito", ciudad);
        }

        [HttpPut]

        public IActionResult ModificarCiudadAccion([FromBody] Infraestructura.Modelos.CiudadModel ciudad)
        {
            servicio.modificarCiudad(ciudad);
            return Ok("Se actualizo con exito");
        }
    }
}
