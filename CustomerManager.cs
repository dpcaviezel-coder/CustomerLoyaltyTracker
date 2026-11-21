using System.Linq;

namespace CustomerLoyaltyTracker
{
    public class CustomerManager
    {
        public List<Customer> list = new List<Customer>();


        // Needs manual input for Customer information 
        public void AddCustomer(Customer customer)
        {
            list.Add(customer();
        }
        // also needs fixing...
        public void RemoveCustomer(Customer customer)
        {
            list.Remove(customer);
        }
        // And so does this.
        public void EditCustomer(Customer customer)
        {
            list.Insert(0, customer);
        }

        public void SearchCustomer(Customer customer)
        {
            Console.Write("Search the customer's by their ID number:");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int IdNumber))
            {
                Console.WriteLine("You entered invalid characters.");
            }
            else
            {
                Console.WriteLine($"{IdNumber} == {customer.Id} Customer's Name: {customer.Name}");
            }
        }

        public void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("\n========== Customer Info ===========");
            Console.WriteLine($"ID: {customer.Id}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
            Console.WriteLine($"Loyalty Points: {customer.LoyaltyPoints}");
            Console.WriteLine($"Active Member: {customer.IsActiveMember}");
            Console.WriteLine("======================================\n");
        }


        public void DisplayAllCustomers()
        {
            foreach (Customer customer in list)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"ID: {customer.Id}");
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                Console.WriteLine($"Loyalty Points: {customer.LoyaltyPoints}");
                Console.WriteLine($"Active Member: {customer.IsActiveMember}");
                Console.WriteLine("---------------------------------\n");
            }
        }


        public void AwardPoints(Customer customer)
        {
            Console.Write("Enter amount of Loyalty Points customer is to receive: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int awardPoints))
            {
                Console.WriteLine("You entered invalid characters");
            }
            else
            {
                customer.LoyaltyPoints = awardPoints;
                Console.WriteLine($"{customer.Name} received {awardPoints}");
            }
        }


        public void RedeemPoints(Customer customer)
        {
            Console.Write("Enter amount of Loyalty Points:");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int output))
            {
                Console.WriteLine("You entered invalid characters");
                return;
            }
            if (customer.LoyaltyPoints <= 0)
            {
                Console.WriteLine("You have no Loyalty Points to spend");
            }
            else
            {
                customer.LoyaltyPoints -= output;
                Console.WriteLine($"Your remaining Loyalty Points: {customer.LoyaltyPoints}");
            }
        }


        public void GetTopCustomer()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No customers available.");
                return;
            }

            Customer topCustomer = list.OrderByDescending(c => c.LoyaltyPoints).First();
            Console.WriteLine("Top Customer:");
            DisplayCustomer(topCustomer);
        }

        public void CalculateTier(Customer customer)
        {
            if (customer.LoyaltyPoints > 999)
            {
                Console.WriteLine($"{customer.Tier} = Platinum");
            }
            else if (customer.LoyaltyPoints > 499)
            {
                Console.WriteLine($"{customer.Tier} = Gold");
            }
            else if (customer.LoyaltyPoints > 99)
            {
                Console.WriteLine($"{customer.Tier} = Silver");
            }
            else
            {
                Console.WriteLine($"{customer.Tier} = Bronze");
            }
        }

        public void DisplayStatistics(Customer customer, List<Customer> list)
        {
            int totalCustomers = list.Count;
            int activeMembers = list.Count(c => c.IsActiveMember);
            int totalLoyaltyPoints = list.Sum(c => c.LoyaltyPoints);
            Customer? highestPointCustomer = list.OrderByDescending(c => c.LoyaltyPoints).FirstOrDefault();

            Console.WriteLine("\n==== Customer Statistics: ====");
            Console.WriteLine($"Total Customers: {totalCustomers}");
            Console.WriteLine($"Active Members: {activeMembers}");
            Console.WriteLine($"Total Loyalty Points: {totalLoyaltyPoints}");
            if (highestPointCustomer != null)
            {
                Console.WriteLine($"Highest Point Customer: {highestPointCustomer.Name}");
            }
            else
            {
                Console.WriteLine("Highest Point Customer: N/A");
            }
        }

        public void SortCustomerByPoints(List<Customer> list)
        {
            var sorted = list.OrderByDescending(c => c.LoyaltyPoints).ToList();
            Console.WriteLine("Customer's order by Loyalty Points (Highest to Lowest):");
            foreach (var customer in sorted)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Loyalty Points: {customer.LoyaltyPoints}");
            }
        }
    }
}
