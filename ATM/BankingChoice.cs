namespace ATM
{
    public static class BankingChoice
    {
        public static void UserChoice(User user)
        {

            Console.WriteLine("Press 1 For WithDrawal Money");
            Console.WriteLine("Press 2 For Deposit Money");
            Console.WriteLine("Press 3 Exit");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Format. Please enter a valid card number:");
            }
            switch(userInput)
            {
                case 1:
                    WithDraw.WithDrawMoney(user);
                    break;
                    case 2:
                    Deposit.DepositMoney(user);
                    break;
                    case 3:
                    Console.WriteLine("Exiting Program, Bye!");
                    break;

            }
        }
    }
}
