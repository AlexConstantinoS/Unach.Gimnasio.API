public interface IProgreso
{
    Task<bool> GuardarProgreso(Progreso progreso);
        Task<bool> ActualizarProgreso(Progreso progreso);
            Task<bool> EliminarProgreso(int Id);
                Task<List<Progreso>> ConsultarProgreso();
}