using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Api/Entrenador")]
[Authorize]
public class EntrenadorController:ControllerBase
{
    IEntrenador _EntrenadorService;
    public EntrenadorController(IEntrenador entrenador)
    {
      
      _EntrenadorService=entrenador;
        
    }

[HttpGet("ObtenerEntrenador")]
    public async Task<IActionResult> ObtenerEntrenador()
    {
        var resultado=await _EntrenadorService.ConsultarEntrenador();
        return Ok(resultado);

    }
    [HttpPost("RegistrarEntrenador")]
    public async  Task<IActionResult> GuardarEntrenador(Entrenador entrenador)
    {
var Resultado= await _EntrenadorService.GuardarEntrenador(entrenador);
    return Ok(Resultado);
    }
       [HttpPut("ActualizarEntrenador")]
    public async  Task<IActionResult> ActualizarEntrenador(Entrenador entrenador)
    {
var Resultado= await _EntrenadorService.ActualizarEntrenador(entrenador);
    return Ok(Resultado);
    }
          [HttpDelete("EliminarEntrenador")]
    public async  Task<IActionResult> EliminarEntrenador(int Id)
    {
var Resultado= await _EntrenadorService.EliminarEntrenador(Id);
    return Ok(Resultado);
    }

}