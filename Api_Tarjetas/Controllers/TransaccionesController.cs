using Microsoft.AspNetCore.Mvc;
using Api_Tarjetas.Estructuras;
using biblioteca_de_clases;

namespace Api_Tarjetas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionesController : ControllerBase
    {
        private static int contadorId = 1;

        // POST: api/Transacciones
        [HttpPost]
        public IActionResult Registrar([FromBody] Transaccion transaccion)
        {
            try
            {
                transaccion.Id = contadorId++;
                transaccion.Fecha = DateTime.Now;

                // Guardar en estructuras
                EstructuraGlobal.Movimientos.InsertarFinal(transaccion);
                EstructuraGlobal.Historial.Push(transaccion);

                // Actualizar resumen
                if (transaccion.Tipo.Equals("Pago", StringComparison.OrdinalIgnoreCase))
                {
                    var resumen = (ResumenCliente)EstructuraGlobal.TablaResumenClientes.Buscar(transaccion.Id);
                    resumen?.AgregarAbono((int)transaccion.Monto);
                }
                else if (transaccion.Tipo.Equals("Consumo", StringComparison.OrdinalIgnoreCase))
                {
                    var resumen = (ResumenCliente)EstructuraGlobal.TablaResumenClientes.Buscar(transaccion.Id);
                    resumen?.AgregarCargo((int)transaccion.Monto);
                }

                return Ok("Transacción registrada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al registrar: {ex.Message}");
            }
        }

        // GET: api/Transacciones/movimientos
        [HttpGet("movimientos")]
        public IActionResult ObtenerMovimientos()
        {
            return Ok(EstructuraGlobal.Movimientos.Recorrer());
        }

        // GET: api/Transacciones/historial
        [HttpGet("historial")]
        public IActionResult ObtenerHistorial()
        {
            return Ok(EstructuraGlobal.Historial.Recorrer());
        }

        // GET: api/Transacciones/por-tipo?tipo=Pago
        [HttpGet("por-tipo")]
        public IActionResult FiltrarPorTipo([FromQuery] string tipo)
        {
            var resultado = new List<string>();
            var actual = EstructuraGlobal.Movimientos.Primero;

            while (actual != null)
            {
                if (actual.Dato is Transaccion t && t.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase))
                {
                    resultado.Add(t.ToString());
                }
                actual = actual.Siguiente;
            }

            return Ok(resultado);
        }
    }
}