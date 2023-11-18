using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("API/Seguridad")]
public class SeguridadController:ControllerBase
{

readonly ILogin _LoginService;

public SeguridadController(ILogin login)
{
    _LoginService=login;
}

[HttpPost("AutentificacionCl")]
public IActionResult Autenticacion(User user)
{
var Resultado=_LoginService.Login(user);
return Ok(Resultado);
}
}
