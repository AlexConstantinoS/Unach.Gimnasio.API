using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class LoginService : ILogin
{
    public async Task<Cliente> IniciarSesion(User user)
    {
     
     using (var conexion=new GimnasioDBContext())
     {
        var consulta= await (from c in conexion.Cliente
        where c.Nombre_Usuario==user.Usuario
        && c.Contraseña==user.Password
        select c).FirstOrDefaultAsync();
        
        if(consulta!=null)
        {
           return consulta;
        }else{

            return new Cliente();
        }

      }
    }  
}
