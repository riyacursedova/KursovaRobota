using System;
using System.Collections.Generic;
using System.Text.RegularExpressions; 

namespace KursovaRobota
{
    public class RegisterCommand : BaseCommand
    {
        private readonly IAuthService _authService;
        public override string Name => "Зареєструватися";
        public RegisterCommand(IAuthService authService, IShopService shopService, Session session) 
            : base(shopService, session) 
        {
            _authService = authService;
        }

        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("=== РЕЄСТРАЦІЯ ===");
            Console.WriteLine("(Вимоги: Латиниця (A-Z), цифри, без пробілів)");

            string username = GetValidInput("Введіть логін: ");
            string password = GetValidInput("Введіть пароль: ");
            GamingClass selectedClass = ChooseClass();
            
            bool result = _authService.Register(username, password, selectedClass);

            if (result)
            {
                Console.WriteLine($"\nУспішно! Користувач {username} ({selectedClass}) створений.");
            }
            else
            {
                PrintError("\nПомилка: Користувач з таким іменем вже існує.");
            }
            
            WaitForKey();
        }
        
        private string GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintError("Помилка: Поле не може бути пустим.");
                    continue;
                }

                if (input.Contains(" "))
                {
                    PrintError("Помилка: Пробіли заборонені.");
                    continue;
                }

                if (!Regex.IsMatch(input, "^[a-zA-Z0-9]+$"))
                {
                    PrintError("Помилка: Дозволена тільки латиниця (A-Z) та цифри.");
                    continue;
                }

                return input;
            }
        }

        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private GamingClass ChooseClass()
        {
            Console.WriteLine("\nОберіть клас героя:");
            var classes = Enum.GetValues(typeof(GamingClass));
            int i = 1;
            foreach (var c in classes)
            {
                Console.WriteLine($"{i}. {c}");
                i++;
            }

            while (true)
            {
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= classes.Length)
                {
                    return (GamingClass)classes.GetValue(choice - 1);
                }
                PrintError("Невірний вибір.");
            }
        }

        private void WaitForKey()
        {
            Console.WriteLine("Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}