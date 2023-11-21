using Microsoft.EntityFrameworkCore;

public class ProgresoService : IProgreso
{
    public async Task<bool> ActualizarProgreso(Progreso progreso)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Progreso
            where c.Id == progreso.Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                consulta.Id_cliente=progreso.Id_cliente;
                consulta.Id_ejercicio=progreso.Id_ejercicio;
                consulta.Fecha=progreso.Fecha;
                consulta.Duracion=progreso.Duracion;

                await conexion.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

    public async Task<List<Progreso>> ConsultarProgreso()
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Progreso select c).ToListAsync();
            return consulta ?? new List<Progreso>();
        }
    }

    public async Task<bool> EliminarProgreso(int Id)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Progreso
            where c.Id == Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                conexion.Progreso.Remove(consulta);
                var resultado = await conexion.SaveChangesAsync();

                return resultado == 1;
            }

            return false;
        }
    }

    public async Task<bool> GuardarProgreso(Progreso progreso)
    {
        using (var conexion = new GimnasioDBContext())
        {
            conexion.Progreso.Add(progreso);
            await conexion.SaveChangesAsync();
            return true;
        }
    }
}
