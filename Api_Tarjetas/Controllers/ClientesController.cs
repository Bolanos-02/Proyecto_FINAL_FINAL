using Microsoft.AspNetCore.Mvc;
using Api_Tarjetas.Estructuras;
using biblioteca_de_clases;

namespace Api_Tarjetas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult InsertarCliente([FromBody] Cliente cliente)
        {
            try
            {
                EstructuraGlobal.ArbolClientes.Insertar(cliente);

                // Crear ResumenCliente con carné basado en su DPI (usaremos solo números si es necesario)
                int carne = int.Parse(cliente.DPI); // Asegúrate que se pueda convertir
                var resumen = new ResumenCliente(carne, cliente.Nombre);
                EstructuraGlobal.TablaResumenClientes.Insertar(carne, resumen);

                return Ok("Cliente y resumen insertados correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ObtenerClientesInorden()
        {
            string resultado = EstructuraGlobal.ArbolClientes.Inorden();
            return Ok(resultado);
        }

        [HttpDelete("{dpi}")]
        public IActionResult EliminarCliente(string dpi)
        {
            try
            {
                Cliente c = new Cliente(dpi, "TEMP");
                EstructuraGlobal.ArbolClientes.Eliminar(c);
                return Ok("Cliente eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}