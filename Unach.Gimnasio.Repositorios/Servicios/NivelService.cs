using Microsoft.EntityFrameworkCore;

public class NivelService : INivel
{
    public async Task<bool> ActualizarNivel(Nivel nivel)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Nivel
            where c.Id == nivel.Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                consulta.Nombre = nivel.Nombre;
                consulta.Descripcion = nivel.Descripcion;

                await conexion.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

    public async Task<List<Nivel>> ConsultarNivel()
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Nivel select c).ToListAsync();
            return consulta ?? new List<Nivel>();
        }
    }

    public async Task<bool> EliminarNivel(int Id)
    {
        using (var conexion = new GimnasioDBContext())
        {
            var consulta = await (from c in conexion.Nivel
            where c.Id == Id
            select c).FirstOrDefaultAsync();

            if (consulta != null)
            {
                conexion.Nivel.Remove(consulta);
                var resultado = await conexion.SaveChangesAsync();

                return resultado == 1;
            }

            return false;
        }
    }

    public async Task<bool> GuardarNivel(Nivel nivel)
    {
        using (var conexion = new GimnasioDBContext())
        {
            conexion.Nivel.Add(nivel);
            await conexion.SaveChangesAsync();
            return true;
        }
    }
}
