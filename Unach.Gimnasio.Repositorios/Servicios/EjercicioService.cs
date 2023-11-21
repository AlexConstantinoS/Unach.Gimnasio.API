using Microsoft.EntityFrameworkCore;

public class EjercicioService : IEjercicio
{
    public async Task<bool> ActualizarEjercicio(Ejercicio ejercicio)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Ejercicio
            where c.Id == ejercicio.Id select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                consulta.Id_rutina = ejercicio.Id_rutina;
                consulta.Nombre = ejercicio.Nombre;
                consulta.Series = ejercicio.Series;
                consulta.Repeticiones = ejercicio.Repeticiones;
                consulta.Descripcion = ejercicio.Descripcion;
                consulta.Imagen = ejercicio.Imagen;

                await conexion.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

    public async Task<List<Ejercicio>> ConsultarEjercicio()
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Ejercicio select c).ToListAsync();
            return consulta ?? new List<Ejercicio>();
        }
    }

    public async Task<bool> EliminarEjercicio(int Id)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Ejercicio
                                  where c.Id == Id
                                  select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                conexion.Ejercicio.Remove(consulta);
                var resultado = await conexion.SaveChangesAsync();

                return resultado == 1;
            }

            return false;
        }
    }

    public async Task<bool> GuardarEjercicio(Ejercicio ejercicio)
    {
        using (var conexion = new GimnasioDBContext())
        {
            conexion.Ejercicio.Add(ejercicio);
            await conexion.SaveChangesAsync();
            return true;
        }
    }
}
