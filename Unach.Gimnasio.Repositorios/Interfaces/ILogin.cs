public interface ILogin
{
    Task <Cliente> IniciarSesion(User user);
}