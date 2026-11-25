using System.Text.Json;

namespace CustomerLoyaltyTracker
{
    public class FileManager
    {
        public void SaveToJson(
            List<Customer> customers)
        {
            string json =
                JsonSerializer.Serialize(
                    customers,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

            File.WriteAllText(
                "customers.json",
                json);

            Console.WriteLine(
                "Customers saved.");
        }

        public List<Customer> LoadFromJson()
        {
            if (!File.Exists(
                "customers.json"))
            {
                return new List<Customer>();
            }

            string json =
                File.ReadAllText(
                    "customers.json");

            return
                JsonSerializer.Deserialize<List<Customer>>(
                    json)
                ?? new List<Customer>();
        }
    }
}