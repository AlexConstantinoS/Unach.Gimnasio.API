using Microsoft.EntityFrameworkCore;

public partial class GimnasioDBContext:DbContext
{
public virtual DbSet<Cliente>Cliente{get;set;}

public virtual DbSet<Membresia>Membresia{get;set;}

public virtual DbSet<Pago>Pagos{get;set;}

public virtual DbSet<Entrenador>Entrenador{get;set;}

public virtual DbSet<Nivel>Nivel{get;set;}

public virtual DbSet<Progreso>Progreso{get;set;}

public virtual DbSet<Rutina>Rutina{get;set;}

public virtual DbSet<AsignacionRutina>Asignacion_rutina{get;set;}

public virtual DbSet<Ejercicio>Ejercicio{get;set;}




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ContextoConfiguracion.CadenaConexion);
            
        }

    }
}