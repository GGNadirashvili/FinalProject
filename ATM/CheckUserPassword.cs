namespace ATM
{
    public class CheckUserPassword
    {
        public static bool CheckPassword(List<User> users, int cardNumber, int enteredPinCode)
        {
            User user = users.FirstOrDefault(user => user.CardNumber == cardNumber)!;

            if (user.PinCode == enteredPinCode)
            {
                Console.WriteLine("Password correct. Access granted.");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password. Access denied.");
                return false;
            }
        }
    }
}