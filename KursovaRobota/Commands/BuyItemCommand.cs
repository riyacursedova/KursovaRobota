using System;

namespace KursovaRobota
{
    public class BuyItemCommand : BaseCommand
    {
        public override string Name => "Купити предмет";

        public BuyItemCommand(IShopService service, Session session) : base(service, session) { }

        public override void Execute()
        {
            Console.Clear();
            if (!_session.IsLoggedIn)
            {
                Console.WriteLine("Помилка: Спочатку увійдіть в акаунт!");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("=== ДОСТУПНІ ТОВАРИ ===");
            var items = _service.GetAllItems();
            
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("Каталог порожній.");
            }
            else
            {
                foreach (var item in items)
                {
                   
                    Console.WriteLine($"ID: {item.ItemID} | Ціна: {item.ItemPrice.ToString()} Gold");
                    Console.WriteLine(item.GetStats());
                    Console.WriteLine(new string('-', 40));
                }
            }
            
            Console.WriteLine($"\n=== ВАШ БАЛАНС: {_session.CurrentUser.GoldBalance} Gold ===");
            Console.Write("Введіть ID товару для покупки (або 0 для скасування): ");
            
            string input = Console.ReadLine();
            
            if (input == "0" || string.IsNullOrWhiteSpace(input))
            {
                return; 
            }

            if (int.TryParse(input, out int id))
            {
                try 
                {
                    string result = _service.BuyItem(_session.CurrentUser, id);
                    if (result.StartsWith("Успіх"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    
                    Console.WriteLine("\n" + result);
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Сталася помилка при покупці: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Некоректний ID. Введіть число.");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}