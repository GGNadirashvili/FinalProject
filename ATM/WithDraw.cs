namespace ATM
{
    public class WithDraw
    {
        public static void WithDrawMoney(User user)
        {
            Console.WriteLine("Enter the amount to WithDraw:");
            double amount;
            while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid amount to WidthDraw:");
            }
            if (amount < user.Balance)
            {
                user.Balance -= amount;
                Console.WriteLine($"Successfully WidthDrawed ${amount}. New balance: ${user.Balance}");
            }
            else if (amount > user.Balance)
            {
                Console.WriteLine("You do not have enough money in your balance.");
                Console.WriteLine("Press '1' to try again or any other key to exit.");
                string choice = Console.ReadLine()!;
                if (choice == "1")
                {
                    WithDrawMoney(user);
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            UpdateBalance.UpdateBalanceInFile(user);
        }
    }
}
