public interface IMembresia
{
    Task<bool> GuardarMembresia(Membresia membresia);
        Task<bool>ActualizarMembresia(Membresia membresia);
            Task<bool> EliminarMembresia(int Id);
                Task<List<Membresia>> ConsultarMembresia();
                 
}