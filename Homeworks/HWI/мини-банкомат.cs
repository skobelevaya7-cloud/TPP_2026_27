internal class Program
{
    static void PrintBalance(decimal balanse)
    {
        Console.WriteLine($"Текущий баланс: {balanse}$");
    }
    static void Deposit(ref decimal balance, List<string> history)
    {
        Console.Write("Введите сумму для пополнения: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        if (amount > 0)
        {
            balance += amount;
            string record = $"Пополнение: +{amount} $. Новый баланс: {balance} $";
            history.Add(record);
            Console.WriteLine("Счёт успешно пополнен.");
        }
        else
        {
            Console.WriteLine("Ошибка: сумма пополнения должна быть больше нуля!");
        }
    }
    static void Withdraw(ref decimal balance, List<string> history)
    {
        Console.Write("Введите сумму для снятия: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (amount <= 0)
        {
            Console.WriteLine("Ошибка: сумма снятия должна быть больше нуля!");
        }
        else if (amount > balance)
        {
            Console.WriteLine("Ошибка: недостаточно средств на счёте!");
        }
        else
        {
            balance -= amount;
            string record = $"Снятие: -{amount} $. Новый баланс: {balance} $";
            history.Add(record);
            Console.WriteLine("Деньги успешно сняты.");
        }
    }
    static void PrintHistory(List<string> history)
    {
        Console.WriteLine("История операций:");
    
        if (history.Count == 0)
        {
            Console.WriteLine("История операций пуста.");
            return;
        }
        for (int i = 0; i < history.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {history[i]}");
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите начальный балланс");
        decimal balance = Convert.ToDecimal(Console.ReadLine());
        List<string> transactionHistory = new List<string>();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать баланс");
            Console.WriteLine("2. Пополнить счёт");
            Console.WriteLine("3. Снять деньги");
            Console.WriteLine("4. Показать историю операций");
            Console.WriteLine("5. Выйти");
            Console.WriteLine("Выберите пункт меню");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    PrintBalance(balance);
                    break;
                case "2":
                    Deposit(ref balance, transactionHistory);
                    break;
                case "3":
                    Withdraw(ref balance, transactionHistory);
                    break;
                case "4":
                    PrintHistory(transactionHistory);
                    break;
                case "5":
                case "0":
                    Console.WriteLine("Работа завершена. Всего доброго!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
                    break;
            }
        }
    }
}
