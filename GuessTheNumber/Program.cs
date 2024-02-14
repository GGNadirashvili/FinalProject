using System;

namespace GuessTheNumber
{
    internal class Program
    {
        private const int MinNumber = 1;
        private const int MaxNumber = 100;

        private static readonly Random rand = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Guess The Number Game\n");

            bool playAgain = true;
            int count = 0;

            int randomNumber = GenerateRandomNumber();
            while (playAgain)
            {
                Console.WriteLine("Enter a number between 1 and 100");

                count++;

                int choice = GetUserInput();
                bool isCorrect = CheckNumber(choice, randomNumber);
                if (isCorrect)
                {
                    Console.WriteLine($"Congrats! The Number is {randomNumber}");
                    playAgain = false;
                    Console.WriteLine($"It took you {count} tries to guess the correct number");
                }
            }
        }

        private static int GetUserInput()
        {
            int choice;
            while (true)
            {
                string input = Console.ReadLine()!;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    continue;
                }
                if (choice < MinNumber || choice > MaxNumber)
                {
                    Console.WriteLine($"Input out of range! Please enter a number between {MinNumber} and {MaxNumber}.");
                    continue;
                }
                break;
            }
            return choice;
        }

        private static int GenerateRandomNumber()
        {
            return rand.Next(MinNumber, MaxNumber + 1);
        }

        private static bool CheckNumber(int choice, int number)
        {
            if (number > choice)
            {
                Console.WriteLine("Oops, Your number is Lower, Try Again!");
            }
            else if (number < choice)
            {
                Console.WriteLine("Oops, Your number is Higher, Try Again!");
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
