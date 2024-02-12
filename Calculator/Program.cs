using System;

namespace Calculator
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator Program\n");

            Calculator calculator = new Calculator();
            bool continueCalculation = true;

            while (continueCalculation)
            {
                calculator.Run();
                Console.WriteLine("Do you want to perform another calculation? (yes/no)");
                string input = Console.ReadLine()!.ToLower();
                continueCalculation = input == "yes" || input == "y";
            }

            Console.WriteLine("Exiting the Calculator Program.");
        }

        public void Run()
        {
            try
            {
                DisplayMenu();
                int choice = GetOperationChoice();
                if (choice != 5)
                {
                    double x = GetNumberFromUser("Enter the first number:");
                    double y = GetNumberFromUser("Enter the second number:");
                    PerformOperation(choice, x, y);
                }
                else
                {
                    Console.WriteLine("Exiting the Calculator Program.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraction (-)");
            Console.WriteLine("3. Multiplication (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice (1-5): ");
        }

        private int GetOperationChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 5:");
            }
            return choice;
        }

        private double GetNumberFromUser(string message)
        {
            double number;
            Console.WriteLine(message);
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input! Please enter a valid number:");
            }
            return number;
        }

        private void PerformOperation(int choice, double x, double y)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{x} + {y} = {Addition(x, y)}");
                    break;
                case 2:
                    Console.WriteLine($"{x} - {y} = {Subtraction(x, y)}");
                    break;
                case 3:
                    Console.WriteLine($"{x} * {y} = {Multiplication(x, y)}");
                    break;
                case 4:
                    if (y != 0)
                        Console.WriteLine($"{x} / {y} = {Division(x, y)}");
                    else
                        Console.WriteLine("Error: Division by zero.");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select a valid operation.");
                    break;
            }
        }

        private double Addition(double x, double y) => x + y;

        private double Subtraction(double x, double y) => x - y;

        private double Multiplication(double x, double y) => x * y;

        private double Division(double x, double y) => x / y;
    }
}
