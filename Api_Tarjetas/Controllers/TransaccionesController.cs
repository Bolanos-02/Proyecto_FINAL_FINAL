using Microsoft.AspNetCore.Mvc;
using biblioteca_de_clases;
using Api_Tarjetas.Estructuras;

namespace Api_Tarjetas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarjetasController : ControllerBase
    {
        [HttpPost]
        public IActionResult CrearTarjeta([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                // Validar si ya existe
                if (EstructuraGlobal.TablaTarjetas.Buscar(tarjeta.Numero) != null)
                    return BadRequest("Esta tarjeta ya existe.");

                EstructuraGlobal.TablaTarjetas.Insertar(tarjeta.Numero, tarjeta);
                return Ok("Tarjeta creada correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{numero}")]
        public IActionResult ConsultarTarjeta(string numero)
        {
            var tarjeta = (TarjetaCredito)EstructuraGlobal.TablaTarjetas.Buscar(numero);
            if (tarjeta == null)
                return NotFound("Tarjeta no encontrada.");
            return Ok(tarjeta.ToString());
        }

        [HttpGet]
        public IActionResult VerTodas()
        {
            return Ok(EstructuraGlobal.TablaTarjetas.MostrarTodo());
        }
    }
}