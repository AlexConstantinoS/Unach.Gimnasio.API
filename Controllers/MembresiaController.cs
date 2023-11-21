using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Api/Membresia")]
[Authorize]
public class MembresiaController:ControllerBase
{
    IMembresia _MembresiaService;
    public MembresiaController(IMembresia membresia)
    {
      
      _MembresiaService=membresia;
        
    }

[HttpGet("ObtenerMembresia")]
    public async Task<IActionResult> ObtenerMembresia()
    {
        var resultado=await _MembresiaService.ConsultarMembresia();
        return Ok(resultado);

    }
    [HttpPost("RegistrarMembresia")]
    public async  Task<IActionResult> GuardarMembresia(Membresia membresia)
    {
var Resultado= await _MembresiaService.GuardarMembresia(membresia);
    return Ok(Resultado);
    }
       [HttpPut("ActualizarMembresia")]
    public async  Task<IActionResult> ActualizarMembresia(Membresia membresia)
    {
var Resultado= await _MembresiaService.ActualizarMembresia(membresia);
    return Ok(Resultado);
    }
          [HttpDelete("EliminarMembresia")]
    public async  Task<IActionResult> EliminarMembresia(int Id)
    {
var Resultado= await _MembresiaService.EliminarMembresia(Id);
    return Ok(Resultado);
    }

}