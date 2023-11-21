public interface IAsignacionRutina
{
    Task<bool> GuardarAsignacionRutina(AsignacionRutina asignacionRutina);
        Task<bool> ActualizarAsignacionRutina(AsignacionRutina asignacionRutina);
            Task<bool> EliminarAsignacionRutina(int Id);
                Task<List<AsignacionRutina>> ConsultarAsignacionRutina();
}
