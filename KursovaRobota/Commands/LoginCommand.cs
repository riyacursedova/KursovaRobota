using System;

namespace KursovaRobota
{
public class LoginCommand : BaseCommand
{
    private readonly IAuthService _authService;

    public override string Name => "Вхід";
    public LoginCommand(IAuthService authService, IShopService shopService, Session session) 
        : base(shopService, session) 
    {
        _authService = authService;
    }

    public override void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== ВХІД ===");
            
        Console.Write("Логін: ");
        string username = Console.ReadLine();
        
        Console.Write("Пароль: ");
        string password = Console.ReadLine();
        
        User user = _authService.Login(username, password);

        if (user != null)
        {
            _session.CurrentUser = user; 
            Console.WriteLine($"\nВітаємо, {user.Username}! Ви увійшли в систему.");
        }
        else
        {
            Console.WriteLine("\nНевірний логін або пароль.");
        }
            
        Console.WriteLine("Натисніть будь-яку клавішу...");
        Console.ReadKey();
    }
}
}