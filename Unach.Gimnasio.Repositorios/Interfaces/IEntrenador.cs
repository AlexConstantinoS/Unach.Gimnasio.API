public interface IEntrenador
{
    Task<bool> GuardarEntrenador(Entrenador entrenador);
        Task<bool>ActualizarEntrenador(Entrenador entrenador);
            Task<bool> EliminarEntrenador(int Id);
                Task<List<Entrenador>> ConsultarEntrenador();
                 
}