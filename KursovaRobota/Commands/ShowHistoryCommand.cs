using System;
using KursovaRobota;

namespace KursovaRobota
{
    public class ShowHistoryCommand : BaseCommand
    {
        public override string Name => "Історія покупок";

        public ShowHistoryCommand(IShopService service, Session session) : base(service, session) { }

        public override void Execute()
        {
            Console.Clear();
            if (!_session.IsLoggedIn)
            {
                Console.WriteLine("Помилка: Спочатку увійдіть в акаунт!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"=== ІСТОРІЯ ПОКУПОК ({_session.CurrentUser.Username}) ===");

            var history = _session.CurrentUser.PurchaseHistory;

            if (history == null || history.Count == 0)
            {
                Console.WriteLine("Ви ще нічого не купували.");
            }
            else
            {
                for (int i = history.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(history[i].ToString());
                }
            }
            
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}