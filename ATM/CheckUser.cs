namespace ATM
{
    public class CheckUser
    {
        public static bool Exists(List<User> users, int cardNumber)
        {
            User user = users.FirstOrDefault(user => user.CardNumber == cardNumber)!;

            if (user is not null)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"User with card number {cardNumber} not found.");
                return false;
            }
        }
    }
}
