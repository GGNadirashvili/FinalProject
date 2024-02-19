using ATM.ATM;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\georg\\OneDrive\\Desktop\\userData.txt";
            List<User> users = FileReader.ReadJsonFile(path);

            if (users.Count > 0)
            {
                UserExistence.HandleUserExistence(users);
            }
            else
            {
                Console.WriteLine("No users found.");
            }
        }


    }
}

