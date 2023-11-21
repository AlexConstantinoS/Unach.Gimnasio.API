using Microsoft.EntityFrameworkCore;

public class RutinaService : IRutina
{
    public async Task<bool> ActualizarRutina(Rutina rutina)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Rutina
            where c.Id == rutina.Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                consulta.Id_nivel = rutina.Id_nivel;
                consulta.Nombre = rutina.Nombre;
                consulta.Duracion = rutina.Duracion;
                consulta.Descripcion = rutina.Descripcion;

                await conexion.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

    public async Task<List<Rutina>> ConsultarRutina()
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Rutina select c).ToListAsync();
            return consulta ?? new List<Rutina>();
        }
    }

    public async Task<bool> EliminarRutina(int Id)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Rutina
            where c.Id == Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                conexion.Rutina.Remove(consulta);
                var resultado = await conexion.SaveChangesAsync();

                return resultado == 1;
            }

            return false;
        }
    }

    public async Task<bool> GuardarRutina(Rutina rutina)
    {
        using (var conexion = new GimnasioDBContext())
        {
            conexion.Rutina.Add(rutina);
            await conexion.SaveChangesAsync();
            return true;
        }
    }
}
