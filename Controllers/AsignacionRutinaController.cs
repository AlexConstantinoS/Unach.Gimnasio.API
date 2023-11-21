using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Api/AsignacionRutina")]
[Authorize]
public class AsignacionRutinaController : ControllerBase
{
    IAsignacionRutina _AsignacionRutinaService;

    public AsignacionRutinaController(IAsignacionRutina asignacionRutina)
    {
        _AsignacionRutinaService = asignacionRutina;
    }

    [HttpGet("ObtenerAsignacionRutina")]
    public async Task<IActionResult> ObtenerAsignacionRutina()
    {
        var resultado = await _AsignacionRutinaService.ConsultarAsignacionRutina();
        return Ok(resultado);
    }

    [HttpPost("RegistrarAsignacionRutina")]
    public async Task<IActionResult> GuardarAsignacionRutina(AsignacionRutina asignacionRutina)
    {
        var resultado = await _AsignacionRutinaService.GuardarAsignacionRutina(asignacionRutina);
        return Ok(resultado);
    }

    [HttpPut("ActualizarAsignacionRutina")]
    public async Task<IActionResult> ActualizarAsignacionRutina(AsignacionRutina asignacionRutina)
    {
        var resultado = await _AsignacionRutinaService.ActualizarAsignacionRutina(asignacionRutina);
        return Ok(resultado);
    }

    [HttpDelete("EliminarAsignacionRutina")]
    public async Task<IActionResult> EliminarAsignacionRutina(int Id)
    {
        var resultado = await _AsignacionRutinaService.EliminarAsignacionRutina(Id);
        return Ok(resultado);
    }
}
