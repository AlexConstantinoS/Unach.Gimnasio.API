using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//Inyeccion de Dependencias
builder.Services.AddTransient<ILogin,LoginService>();
builder.Services.AddTransient<IMembresia,MembresiaService>();
builder.Services.AddTransient<IPago,PagoService>();
builder.Services.AddTransient<IEntrenador,EntrenadorService>();
builder.Services.AddTransient<INivel,NivelService>();
builder.Services.AddTransient<IProgreso,ProgresoService>();
builder.Services.AddTransient<IRutina,RutinaService>();
builder.Services.AddTransient<IAsignacionRutina,AsignacionRutinaService>();
builder.Services.AddTransient<IEjercicio,EjercicioService>();



//Obtener Cadena de conexion

ContextoConfiguracion.CadenaConexion=builder.Configuration.GetConnectionString("CadenaConexion");

// Add services to the container.

//Para el Uso de Tokens

builder.Services.AddAuthentication(op=>{
  op.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;  
  op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options=>
{
   options.TokenValidationParameters = new TokenValidationParameters
 {
     ValidateIssuer = true,
     ValidateAudience = true,
     ValidateLifetime = true,
     ValidateIssuerSigningKey = true,
     ValidIssuer = builder.Configuration["Authentication:Issuer"],
     ValidAudience = builder.Configuration["Authentication:Audience"],
     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Secretkey"]))
 };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Token
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
