public interface INivel
{
    Task<bool> GuardarNivel(Nivel nivel);
        Task<bool> ActualizarNivel(Nivel nivel);
            Task<bool> EliminarNivel(int Id);
                Task<List<Nivel>> ConsultarNivel();
}
