using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Api_Tarjetas.Estructuras;
using biblioteca_de_clases;

namespace Api_Tarjetas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargaInicialController : ControllerBase
    {
        [HttpPost("clientes")]
        public IActionResult CargarClientes()
        {
            try
            {
                string ruta = Path.Combine(Directory.GetCurrentDirectory(), "Datos", "clientes.json");
                if (!System.IO.File.Exists(ruta))
                    return NotFound("Archivo no encontrado.");

                string json = System.IO.File.ReadAllText(ruta);
                var clientes = JsonSerializer.Deserialize<List<Cliente>>(json);

                foreach (var cliente in clientes)
                {
                    EstructuraGlobal.ArbolClientes.Insertar(cliente);

                    // Convertir el DPI a carne (como clave entera)
                    if (int.TryParse(cliente.DPI, out int carne))
                    {
                        if (EstructuraGlobal.TablaResumenClientes.Buscar(carne) == null)
                        {
                            var resumen = new ResumenCliente(carne, cliente.Nombre);
                            EstructuraGlobal.TablaResumenClientes.Insertar(carne, resumen);
                        }
                    }
                }

                return Ok($"Se insertaron {clientes.Count} clientes.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}