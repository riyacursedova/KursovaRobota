using KursovaRobota;

namespace KursovaRobota
{
    public interface IAuthService
    {
        bool Register(string username, string password, GamingClass gamingClass);
        User Login(string username, string password);
    }
}