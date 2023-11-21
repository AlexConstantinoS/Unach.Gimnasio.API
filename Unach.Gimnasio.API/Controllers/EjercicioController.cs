using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Api/Ejercicio")]
[Authorize]
public class EjercicioController : ControllerBase
{
    IEjercicio _EjercicioService;

    public EjercicioController(IEjercicio ejercicioService)
    {
        _EjercicioService = ejercicioService;
    }

    [HttpGet("ObtenerEjercicio")]
    public async Task<IActionResult> ObtenerEjercicio()
    {
        var resultado = await _EjercicioService.ConsultarEjercicio();
        return Ok(resultado);
    }

    [HttpPost("RegistrarEjercicio")]
    public async Task<IActionResult> GuardarEjercicio(Ejercicio ejercicio)
    {
        var resultado = await _EjercicioService.GuardarEjercicio(ejercicio);
        return Ok(resultado);
    }

    [HttpPut("ActualizarEjercicio")]
    public async Task<IActionResult> ActualizarEjercicio(Ejercicio ejercicio)
    {
        var resultado = await _EjercicioService.ActualizarEjercicio(ejercicio);
        return Ok(resultado);
    }

    [HttpDelete("EliminarEjercicio")]
    public async Task<IActionResult> EliminarEjercicio(int Id)
    {
        var resultado = await _EjercicioService.EliminarEjercicio(Id);
        return Ok(resultado);
    }
}
