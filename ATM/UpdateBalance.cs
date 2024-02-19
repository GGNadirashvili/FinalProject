using Newtonsoft.Json;

namespace ATM
{
    public class UpdateBalance
    {
        public static void UpdateBalanceInFile(User user)
        {
            string filePath = "C:\\Users\\georg\\OneDrive\\Desktop\\userData.txt";
            try
            {
                string json = File.ReadAllText(filePath);

                List<User> users = JsonConvert.DeserializeObject<List<User>>(json)!;

                User existingUser = users.FirstOrDefault(u => u.CardNumber == user.CardNumber)!;
                if (existingUser != null)
                {
                    existingUser.Balance = user.Balance;

                    string updatedJson = JsonConvert.SerializeObject(users);

                    File.WriteAllText(filePath, updatedJson);
                }
                else
                {
                    Console.WriteLine($"User with card number {user.CardNumber} not found in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating balance in file: {ex.Message}");
            }
        }
    }
}
