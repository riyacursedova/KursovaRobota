using KursovaRobota;

namespace KursovaRobota
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Register(string username, string password, GamingClass gamingClass)
        {
            var existingUser = _userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                return false;
            }

            var newUser = new User(0, username, password, gamingClass);
            _userRepository.AddUser(newUser);
            return true;
        }

        public User Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}