using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosServices;

namespace ExaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentaController : ControllerBase
    {
        private const string connectionString = "Server=localhost;" + "Port=5432; User Id=postgres; Password=root; Database=Parcial;";
        private CuentaService servicio;

        public CuentaController()
        {
            servicio = new CuentaService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerCuentaAccion([FromRoute] int id)
        {
            var cuenta = servicio.obtenerCuentaPorId(id);
            return Ok(cuenta);
        }

        [HttpPost]
        public IActionResult InsertarCuentaAccion([FromBody] Infraestructura.Modelos.CuentaModel cuenta)
        {
            servicio.insertarCuenta(cuenta);

            return Created("Se inserto con exito", cuenta);
        }

        [HttpPut]

        public IActionResult ModificarCuentaAccion([FromBody] Infraestructura.Modelos.CuentaModel cuenta)
        {
            servicio.modificarCuenta(cuenta);
            return Ok("Se actualizo con exito");
        }
    }
}
