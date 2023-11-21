using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Api/Pagos")]
[Authorize]
public class PagoController:ControllerBase
{
    IPago _PagoService;
    public PagoController(IPago pago)
    {
      
      _PagoService=pago;
        
    }

[HttpGet("ObtenerPago")]
    public async Task<IActionResult> ObtenerPago()
    {
        var resultado=await _PagoService.ConsultarPago();
        return Ok(resultado);

    }
    [HttpPost("RegistrarPago")]
    public async  Task<IActionResult> GuardarPago(Pago pago)
    {
var Resultado= await _PagoService.GuardarPago(pago);
    return Ok(Resultado);
    }
       [HttpPut("ActualizarPago")]
    public async  Task<IActionResult> ActualizarPago(Pago pago)
    {
var Resultado= await _PagoService.ActualizarPago(pago);
    return Ok(Resultado);
    }
          [HttpDelete("EliminarPago")]
    public async  Task<IActionResult> EliminarPago(int Id)
    {
var Resultado= await _PagoService.EliminarPago(Id);
    return Ok(Resultado);
    }

}