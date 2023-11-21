using Microsoft.EntityFrameworkCore;

public class PagoService : IPago
{
    public async Task<bool> ActualizarPago(Pago pago)
    {
        using (var conexon=new  GimnasioDBContext())
{
    var consulta=await(from  c in conexon.Pagos
    where c.Id==pago.Id select c).FirstOrDefaultAsync();
    if (consulta!=null)
    {
        consulta.Id_cliente=pago.Id_cliente;
        consulta.Id_Membresia=pago.Id_Membresia;
        consulta.Fecha=pago.Fecha;
        consulta.Monto=pago.Monto;
        consulta.Metodo_pago=pago.Metodo_pago;

       await conexon.SaveChangesAsync();
        
        return await Task.FromResult(true);
    }
     return await Task.FromResult(false);
}
       
    }

    public async Task<List<Pago>> ConsultarPago()
    {
    using (var conexion=new GimnasioDBContext())
    {
        var consulta=await(from c in conexion.Pagos select c).ToListAsync();
        return consulta??new List<Pago>();;
    }
    }

    public async Task<bool> EliminarPago(int Id)
    {
             using (var conexion=new GimnasioDBContext())
        {
            var consulta=(from c in conexion.Pagos
            where c.Id==Id select c).FirstOrDefault();
            if(consulta!=null)
            {
              conexion.Pagos.Remove(consulta);
                
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

    public async Task<bool> GuardarPago(Pago pago)
    {
       using (var conexion=new  GimnasioDBContext())
       {
        conexion.Pagos.Add(pago);
       await conexion.SaveChangesAsync();
        return await Task.FromResult(true);
       }
    }
}