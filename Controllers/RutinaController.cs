using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Api/Rutina")]
[Authorize]
public class RutinaController : ControllerBase
{
    IRutina _RutinaService;

    public RutinaController(IRutina rutinaService)
    {
        _RutinaService = rutinaService;
    }

    [HttpGet("ObtenerRutina")]
    public async Task<IActionResult> ObtenerRutina()
    {
        var resultado = await _RutinaService.ConsultarRutina();
        return Ok(resultado);
    }

    [HttpPost("RegistrarRutina")]
    public async Task<IActionResult> GuardarRutina(Rutina rutina)
    {
        var resultado = await _RutinaService.GuardarRutina(rutina);
        return Ok(resultado);
    }

    [HttpPut("ActualizarRutina")]
    public async Task<IActionResult> ActualizarRutina(Rutina rutina)
    {
        var resultado = await _RutinaService.ActualizarRutina(rutina);
        return Ok(resultado);
    }

    [HttpDelete("EliminarRutina")]
    public async Task<IActionResult> EliminarRutina(int Id)
    {
        var resultado = await _RutinaService.EliminarRutina(Id);
        return Ok(resultado);
    }
}
