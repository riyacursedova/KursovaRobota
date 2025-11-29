using System;
using System.Collections.Generic;
using System.Text;

namespace KursovaRobota
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            IUserRepository userRepository = new UserRepository();
            IItemRepository itemRepository = new ItemRepository();
            IAuthService authService = new AuthService(userRepository);
            IShopService shopService = new ShopService(itemRepository, userRepository);
            Session session = new Session(); 
            
            List<ICommand> commands = new List<ICommand>
            {
                new RegisterCommand(authService, shopService, session),
                new LoginCommand(authService, shopService, session),
                new ShowCatalogCommand(shopService, session),
                new BuyItemCommand(shopService, session),
                new AddGoldCommand(shopService, session),
                new ShowHistoryCommand(shopService, session)
            };
            
            
            while (true)
            {
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==========================================");
                Console.WriteLine("      КРАМНИЦЯ АРТАСА: WARCRAFT SHOP     ");
                Console.WriteLine("==========================================");
                Console.ResetColor();

                if (session.IsLoggedIn)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" [Гравець]: {session.CurrentUser.Username}");
                    Console.WriteLine($" [Клас]   : {session.CurrentUser.CharacterClass}");
                    Console.WriteLine($" [Баланс] : {session.CurrentUser.GoldBalance} золота");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" [Статус] : Гість (Необхідно увійти або зареєструватися)");
                    Console.ResetColor();
                }
                Console.WriteLine(new string('-', 42));
                
                for (int i = 0; i < commands.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {commands[i].Name}");
                }
                Console.WriteLine(" 0. Вихід");
                Console.WriteLine(new string('-', 42));
                Console.Write(" Ваш вибір > ");
                string input = Console.ReadLine();
                
                if (input == "0")
                {
                    Console.WriteLine("Lok'tar ogar! (До зустрічі!)");
                    break;
                }
                
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= commands.Count)
                {
                    try
                    {
                        commands[choice - 1].Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nКритична помилка: {ex.Message}");
                        Console.ResetColor();
                        Console.WriteLine("Натисніть Enter для продовження...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("\nНевірний вибір. Спробуйте ще раз.");
                    Console.WriteLine("Натисніть Enter...");
                    Console.ReadLine();
                }
            }
        }
    }
}