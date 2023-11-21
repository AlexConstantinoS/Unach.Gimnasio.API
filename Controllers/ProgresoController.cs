using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Api/Progreso")]
[Authorize]
public class ProgresoController : ControllerBase
{
    IProgreso _ProgresoService;

    public ProgresoController(IProgreso progresoService)
    {
        _ProgresoService = progresoService;
    }

    [HttpGet("ObtenerProgreso")]
    public async Task<IActionResult> ObtenerProgreso()
    {
        var resultado = await _ProgresoService.ConsultarProgreso();
        return Ok(resultado);
    }

    [HttpPost("RegistrarProgreso")]
    public async Task<IActionResult> GuardarProgreso(Progreso progreso)
    {
        var resultado = await _ProgresoService.GuardarProgreso(progreso);
        return Ok(resultado);
    }

    [HttpPut("ActualizarProgreso")]
    public async Task<IActionResult> ActualizarProgreso(Progreso progreso)
    {
        var resultado = await _ProgresoService.ActualizarProgreso(progreso);
        return Ok(resultado);
    }

    [HttpDelete("EliminarProgreso")]
    public async Task<IActionResult> EliminarProgreso(int Id)
    {
        var resultado = await _ProgresoService.EliminarProgreso(Id);
        return Ok(resultado);
    }
}