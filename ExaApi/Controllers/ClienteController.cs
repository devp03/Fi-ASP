using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosServices;

namespace ExaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private const string connectionString = "Server=localhost;" + "Port=5432; User Id=postgres; Password=root; Database=Parcial;";
        private ClienteService servicio;

        public ClienteController()
        {
            servicio = new ClienteService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerClienteAccion([FromRoute] int id)
        {
            var cliente = servicio.obtenerClientePorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult InsertarClienteAccion([FromBody] Infraestructura.Modelos.ClienteModel cliente)
        {
            servicio.insertarCliente(cliente);

            return Created("Se inserto con exito", cliente);
        }

        [HttpPut]

        public IActionResult ModificarClienteAccion([FromBody] Infraestructura.Modelos.ClienteModel cliente)
        {
            servicio.modificarCliente(cliente);
            return Ok("Se actualizo con exito");
        }
    }
}
