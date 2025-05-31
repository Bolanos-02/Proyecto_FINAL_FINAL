using Microsoft.AspNetCore.Mvc;
using Api_Tarjetas.Estructuras;
using biblioteca_de_clases;

namespace Api_Tarjetas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumenController : ControllerBase
    {
        // GET: api/resumen/{carne}
        [HttpGet("{carne}")]
        public IActionResult ObtenerResumen(int carne)
        {
            var resumen = (ResumenCliente)EstructuraGlobal.TablaResumenClientes.Buscar(carne);
            if (resumen != null)
                return Ok(resumen.ToString());
            else
                return NotFound("Resumen no encontrado para ese dpi.");
        }

        // GET: api/resumen
        [HttpGet]
        public IActionResult VerTodos()
        {
            return Ok(EstructuraGlobal.TablaResumenClientes.MostrarTodo());
        }
    }
}