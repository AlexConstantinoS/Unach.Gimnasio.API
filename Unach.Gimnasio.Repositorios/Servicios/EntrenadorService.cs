using Microsoft.EntityFrameworkCore;

public class EntrenadorService : IEntrenador
{
    public async Task<bool> ActualizarEntrenador(Entrenador entrenador)
    {
        using (var conexon=new  GimnasioDBContext())
{
    var consulta=await(from  c in conexon.Entrenador
    where c.Id==entrenador.Id select c).FirstOrDefaultAsync();
    if (consulta!=null)
    {
        consulta.Nombre=entrenador.Nombre;
        consulta.Apellido=entrenador.Apellido;
        consulta.Telefono=entrenador.Telefono;
        consulta.Especialidad=entrenador.Especialidad;

       await conexon.SaveChangesAsync();
        
        return await Task.FromResult(true);
    }
     return await Task.FromResult(false);
}
       
    }

    public async Task<List<Entrenador>> ConsultarEntrenador()
    {
    using (var conexion=new GimnasioDBContext())
    {
        var consulta=await(from c in conexion.Entrenador select c).ToListAsync();
        return consulta??new List<Entrenador>();;
    }
    }

    public async Task<bool> EliminarEntrenador(int Id)
    {
             using (var conexion=new GimnasioDBContext())
        {
            var consulta=(from c in conexion.Entrenador
            where c.Id==Id select c).FirstOrDefault();
            if(consulta!=null)
            {
              conexion.Entrenador.Remove(consulta);
                
            }
          
        var resultado=  await conexion.SaveChangesAsync();
        if(resultado==1)
        {
        return true;
        }else{
        return false;
        }
        }
      
    }

    public async Task<bool> GuardarEntrenador(Entrenador entrenador)
    {
       using (var conexion=new  GimnasioDBContext())
       {
        conexion.Entrenador.Add(entrenador);
       await conexion.SaveChangesAsync();
        return await Task.FromResult(true);
       }
    }
}