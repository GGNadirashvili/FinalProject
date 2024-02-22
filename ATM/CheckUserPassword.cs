namespace ATM
{
	public class CheckUserPassword
	{
		public static bool CheckPassword(List<User> users, int cardNumber, int enteredPinCode)
		{
			User user = users.FirstOrDefault(user => user.CardNumber == cardNumber)!;

			int maxAttempts = 2; 
			int attempts = 0; 

			while (user != null && user.PinCode != enteredPinCode && attempts < maxAttempts)
			{
				attempts++;
				Console.WriteLine($"Incorrect password. You have {maxAttempts - attempts + 1} attempt(s) left.");
				Console.Write("Please enter your PIN again: ");
				enteredPinCode = int.Parse(Console.ReadLine()!);
				user = users.FirstOrDefault(user => user.CardNumber == cardNumber)!;
			}

			if (user != null && user.PinCode == enteredPinCode)
			{
				Console.WriteLine("Password correct. Access granted.");
				Console.WriteLine($"Your Balance Is {user.Balance}$\n");
				BankingChoice.UserChoice(user);
				return true;
			}
			else
			{
				Console.WriteLine("Maximum attempts reached. Access denied.");
				return false;
			}
		}
	}
}
