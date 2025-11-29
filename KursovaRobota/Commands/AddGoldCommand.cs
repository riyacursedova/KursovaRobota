using System;

namespace KursovaRobota;

public class AddGoldCommand : BaseCommand
{
    public override string Name => "Поповнити баланс";

    public AddGoldCommand(IShopService service, Session session) : base(service, session) { }

    public override void Execute()
    {
        Console.Clear();
        if (!_session.IsLoggedIn)
        {
            Console.WriteLine("Помилка: Спочатку увійдіть в акаунт!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Баланс: {_session.CurrentUser.GoldBalance}");
        Console.Write("Скільки золота додати? ");
        
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            try
            {
                _service.TopUpBalance(_session.CurrentUser, amount);
                Console.WriteLine($"Успішно! Новий баланс: {_session.CurrentUser.GoldBalance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Некоректна сума.");
        }
        
        Console.ReadKey();
    }
}