public interface IEjercicio
{
    Task<bool> GuardarEjercicio(Ejercicio ejercicio);
        Task<bool> ActualizarEjercicio(Ejercicio ejercicio);
            Task<bool> EliminarEjercicio(int Id);
                Task<List<Ejercicio>> ConsultarEjercicio();
}
