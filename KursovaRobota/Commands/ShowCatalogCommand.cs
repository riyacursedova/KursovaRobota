using System;
using KursovaRobota; 

namespace KursovaRobota 
{
    public class ShowCatalogCommand : BaseCommand
    {
        public override string Name => "Каталог товарів";

        public ShowCatalogCommand(IShopService service, Session session) : base(service, session) { }

        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("=== МАГАЗИН ===");
            
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

            Console.WriteLine("Натисніть будь-яку клавішу");
            Console.ReadKey();
        }
    }
}