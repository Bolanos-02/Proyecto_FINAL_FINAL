using biblioteca_de_clases;
using Microsoft.AspNetCore.Mvc;
using Api_Tarjetas.Estructuras;

[ApiController]
[Route("api/[controller]")]
public class DebugController : ControllerBase
{
    [HttpPost("reset")]
    public IActionResult Reset()
    {
        EstructuraGlobal.TablaResumenClientes.Vaciar();
        EstructuraGlobal.ArbolClientes = new ArbolAVL();
        return Ok("Estructuras reiniciadas.");
    }
}