using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Api/Nivel")]
[Authorize]
public class NivelController : ControllerBase
{
    INivel _NivelService;

    public NivelController(INivel nivelService)
    {
        _NivelService = nivelService;
    }

    [HttpGet("ObtenerNivel")]
    public async Task<IActionResult> ObtenerNivel()
    {
        var resultado = await _NivelService.ConsultarNivel();
        return Ok(resultado);
    }

    [HttpPost("RegistrarNivel")]
    public async Task<IActionResult> GuardarNivel(Nivel nivel)
    {
        var resultado = await _NivelService.GuardarNivel(nivel);
        return Ok(resultado);
    }

    [HttpPut("ActualizarNivel")]
    public async Task<IActionResult> ActualizarNivel(Nivel nivel)
    {
        var resultado = await _NivelService.ActualizarNivel(nivel);
        return Ok(resultado);
    }

    [HttpDelete("EliminarNivel")]
    public async Task<IActionResult> EliminarNivel(int Id)
    {
        var resultado = await _NivelService.EliminarNivel(Id);
        return Ok(resultado);
    }
}
