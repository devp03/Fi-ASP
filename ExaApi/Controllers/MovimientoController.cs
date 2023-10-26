using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosServices;

namespace ExaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoController : ControllerBase
    {
        private const string connectionString = "Server=localhost;" + "Port=5432; User Id=postgres; Password=root; Database=Parcial;";
        private MovimientoService servicio;

        public MovimientoController()
        {
            servicio = new MovimientoService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerMovimientoAccion([FromRoute] int id)
        {
            var movimiento = servicio.obtenerMovimientoPorId(id);
            return Ok(movimiento);
        }

        [HttpPost]
        public IActionResult InsertarMovimientoAccion([FromBody] Infraestructura.Modelos.MovimientoModel movimiento)
        {
            servicio.insertarMovimiento(movimiento);

            return Created("Se inserto con exito", movimiento);
        }

        [HttpPut]

        public IActionResult ModificarMovimientoAccion([FromBody] Infraestructura.Modelos.MovimientoModel movimiento)
        {
            servicio.modificarMovimiento(movimiento);
            return Ok("Se actualizo con exito");
        }
    }
}
