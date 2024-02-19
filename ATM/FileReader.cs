using Newtonsoft.Json;

namespace ATM.ATM
{
    public class FileReader
    {
        public static List<User> ReadJsonFile(string path)
        {
            List<User> users = new List<User>();

            try
            {
                string jsonData = File.ReadAllText(path);
                users = JsonConvert.DeserializeObject<List<User>>(jsonData)!;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

            return users;
        }
    }
}
