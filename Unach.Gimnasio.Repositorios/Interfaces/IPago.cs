public interface IPago
{
    Task<bool> GuardarPago(Pago pago);
        Task<bool>ActualizarPago(Pago pago);
            Task<bool> EliminarPago(int Id);
                Task<List<Pago>> ConsultarPago();
                 
}