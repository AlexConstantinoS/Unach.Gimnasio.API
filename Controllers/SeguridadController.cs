using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
[ApiController]
[Route("Api/[controller]")]
public class SeguridadController : ControllerBase
{

    readonly ILogin _LoginService;
    readonly IConfiguration _Configuration;
    public SeguridadController(ILogin login, IConfiguration configuration)
    {
        _LoginService = login;
        _Configuration = configuration;
    }



    [HttpPost("IniciarSesion")]
    public async  Task<IActionResult> IniciarSesion(User user)
    {
        var resultado=await _LoginService.IniciarSesion(user);
        if(resultado.Nombre!=null)
        {
           //generar token
var token=GenerarToken(resultado);
            return Ok(token);
        }else
        {
            //Enviar error
            return BadRequest();
        }
    }

    private string GenerarToken(Cliente cliente)
    {
        //Header
        SymmetricSecurityKey issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._Configuration["Authentication:Secretkey"]));
SigningCredentials signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);
JwtHeader header = new JwtHeader(signingCredentials);
//Claims
Claim[] claims = {
    new Claim(ClaimTypes.Email, cliente.Nombre),
    new Claim(ClaimTypes.Name, cliente.Genero),
    new Claim(ClaimTypes.SerialNumber,cliente.Telefono)

};
//Payload
JwtPayload payload = new JwtPayload(
    this._Configuration["Authentication:Issuer"],
    this._Configuration["Authentication:Audience"],
    claims,
    DateTime.Now,
    DateTime.Now.Date.AddDays(1)
         
);
JwtSecurityToken token = new JwtSecurityToken(header, payload);
return new JwtSecurityTokenHandler().WriteToken(token);
    }
}