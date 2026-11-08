using System;

namespace MobileAccountSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Модель мобільного зв'язку та події\n");

            MobileAccount account = new MobileAccount("+380971112233", 40.0m, 15.0m);

            account.LowBalanceReached += HandleLowBalance;

            account.MakeCall(15, 1.0m);
            account.MakeCall(20, 1.0m);
            account.TopUp(50.0m);
        }

        private static void HandleLowBalance(object? sender, LowBalance e)
        {
            if (sender is MobileAccount account)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n--------------------------------------------------");
                Console.WriteLine($"ПОПЕРЕДЖЕННЯ: На номері {account.PhoneNumber} низький баланс!");
                Console.WriteLine($"Залишок: {e.CurrentBalance:F2} грн (Поріг: {e.MinimumThreshold:F2} грн)");
                Console.WriteLine($"--------------------------------------------------\n");
                Console.ResetColor();
            }
        }
    }
}