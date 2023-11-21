using Microsoft.EntityFrameworkCore;

public class MembresiaService : IMembresia
{
    public async Task<bool> ActualizarMembresia(Membresia membresia)
    {
        using (var conexon=new  GimnasioDBContext())
{
    var consulta=await(from  c in conexon.Membresia
    where c.Id==membresia.Id select c).FirstOrDefaultAsync();
    if (consulta!=null)
    {
        consulta.Id_nivel=membresia.Id_nivel;
        consulta.Nombre=membresia.Nombre;
        consulta.Duracion=membresia.Duracion;
        consulta.Costo=membresia.Costo;

       await conexon.SaveChangesAsync();
        
        return await Task.FromResult(true);
    }
     return await Task.FromResult(false);
}
       
    }

    public async Task<List<Membresia>> ConsultarMembresia()
    {
    using (var conexion=new GimnasioDBContext())
    {
        var consulta=await(from c in conexion.Membresia select c).ToListAsync();
        return consulta??new List<Membresia>();;
    }
    }

    public async Task<bool> EliminarMembresia(int Id)
    {
             using (var conexion=new GimnasioDBContext())
        {
            var consulta=(from c in conexion.Membresia
            where c.Id==Id select c).FirstOrDefault();
            if(consulta!=null)
            {
              conexion.Membresia.Remove(consulta);
                
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

    public async Task<bool> GuardarMembresia(Membresia membresia)
    {
       using (var conexion=new  GimnasioDBContext())
       {
        conexion.Membresia.Add(membresia);
       await conexion.SaveChangesAsync();
        return await Task.FromResult(true);
       }
    }
}