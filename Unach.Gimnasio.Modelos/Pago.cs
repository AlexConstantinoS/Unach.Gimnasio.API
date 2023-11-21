public class Pago
{
    public int Id {get;set;}
    public int Id_cliente {get;set;}

    public int Id_Membresia {get;set;}

    public DateTime Fecha {get;set;}

    public string? Monto {get;set;}

    public string? Metodo_pago {get;set;}
}