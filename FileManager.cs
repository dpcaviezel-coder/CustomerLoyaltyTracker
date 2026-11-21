using System.Text.Json;

namespace CustomerLoyaltyTracker
{
    public class FileManager
    {
        private Customer Customer { get; set; }
        private CustomerManager Manager { get; set; }

        public FileManager(Customer customer, CustomerManager manager)
        {
            Customer = customer;
            Manager = manager;
        }

        public void SaveToJson(Customer customer)
        {
            string json = JsonSerializer.Serialize(customer);
            File.WriteAllText("customer.json", json);
            Console.WriteLine($"{customer.Name} successfully saved to json.");
        }

        public void LoadFromJson(Customer customer)
        {
            string json = File.ReadAllText("customer.json");
            Customer loadedCustomer = JsonSerializer.Deserialize<Customer>(json);
            if (loadedCustomer != null)
            {
                customer.Id = loadedCustomer.Id;
                customer.Name = loadedCustomer.Name;
                customer.Email = loadedCustomer.Email;
                customer.PhoneNumber = loadedCustomer.PhoneNumber;
                customer.LoyaltyPoints = loadedCustomer.LoyaltyPoints;
                customer.IsActiveMember = loadedCustomer.IsActiveMember;
                Console.WriteLine($"{customer.Name} successfully loaded from json.");
            }
            else
            {
                Console.WriteLine("Failed to load customer from json.");
            }
        }
    }
}
