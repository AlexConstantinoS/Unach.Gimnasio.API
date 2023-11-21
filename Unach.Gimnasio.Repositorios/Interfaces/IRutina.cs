public interface IRutina
{
    Task<bool> GuardarRutina(Rutina rutina);
        Task<bool> ActualizarRutina(Rutina rutina);
            Task<bool> EliminarRutina(int Id);
                Task<List<Rutina>> ConsultarRutina();
}