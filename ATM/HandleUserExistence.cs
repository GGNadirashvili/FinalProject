namespace ATM
{
    public class UserExistence
    {
         public static void HandleUserExistence(List<User> users)
        {
            bool userFound = false;
            do
            {
                Console.WriteLine("Please Enter Card Number:");
                int cardNumber;
                while (!int.TryParse(Console.ReadLine(), out cardNumber))
                {
                    Console.WriteLine("Invalid Format. Please enter a valid card number:");
                }

                bool userExists = CheckUser.Exists(users, cardNumber);

                if (userExists)
                {
                    Console.WriteLine("Please Enter PinCode:");
                    int pinCode;
                    while (!int.TryParse(Console.ReadLine(), out pinCode))
                    {
                        Console.WriteLine("Invalid Format. Please enter a valid pin code:");
                    }

                    CheckUserPassword.CheckPassword(users, cardNumber, pinCode);
                    userFound = true;
                }
                else
                {
                    Console.WriteLine($" Do you want to try again? (Y/N)");
                    string tryAgainInput = Console.ReadLine()!;
                    if (tryAgainInput.ToLower() != "y")
                    {
                        Console.WriteLine("Exiting program.");
                        return;
                    }
                }
            }

            while (!userFound);
        }
    }
}
