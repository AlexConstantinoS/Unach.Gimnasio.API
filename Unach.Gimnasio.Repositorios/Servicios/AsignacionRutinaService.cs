using Microsoft.EntityFrameworkCore;

public class AsignacionRutinaService : IAsignacionRutina
{
    public async Task<bool> ActualizarAsignacionRutina(AsignacionRutina asignacionRutina)
    {
        using (var conexon = new GimnasioDBContext())
        {
            var consulta = await (from c in conexon.Asignacion_rutina
            where c.Id == asignacionRutina.Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                consulta.Id_rutina = asignacionRutina.Id_rutina;
                consulta.Id_Entrenador = asignacionRutina.Id_Entrenador;

                await conexon.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

    public async Task<List<AsignacionRutina>> ConsultarAsignacionRutina()
    {
        using (var context = new GimnasioDBContext())
        {
            var consulta = await (from c in context.Asignacion_rutina select c).ToListAsync();
            return consulta ?? new List<AsignacionRutina>();
        }
    }

    public async Task<bool> EliminarAsignacionRutina(int Id)
    {
        using (var context = new GimnasioDBContext())
        {
            var consulta = await (from c in context.Asignacion_rutina
            where c.Id == Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                context.Asignacion_rutina.Remove(consulta);
                var resultado = await context.SaveChangesAsync();
                return resultado == 1;
            }

            return false;
        }
    }

    public async Task<bool> GuardarAsignacionRutina(AsignacionRutina asignacionRutina)
    {
        using (var context = new GimnasioDBContext())
        {
            context.Asignacion_rutina.Add(asignacionRutina);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
