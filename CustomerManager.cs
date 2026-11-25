using System.Linq;

namespace CustomerLoyaltyTracker
{
    public class CustomerManager
    {
        public List<Customer> Customers { get; } =
            new();

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
        }

        public Customer? SearchCustomer(int id)
        {
            return Customers.FirstOrDefault(
                c => c.Id == id);
        }

        public void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("\n===== CUSTOMER =====");

            Console.WriteLine($"Id: {customer.Id}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.PhoneNumber}");
            Console.WriteLine($"Points: {customer.LoyaltyPoints}");
            Console.WriteLine($"Tier: {customer.Tier}");
            Console.WriteLine($"Active: {customer.IsActiveMember}");

            Console.WriteLine("====================");
        }

        public void DisplayAllCustomers()
        {
            foreach (var customer in Customers)
            {
                DisplayCustomer(customer);
            }
        }

        public void AwardPoints(
            Customer customer,
            int points)
        {
            customer.LoyaltyPoints += points;

            CalculateTier(customer);
        }

        public void RedeemPoints(
            Customer customer,
            int points)
        {
            customer.LoyaltyPoints -= points;

            if (customer.LoyaltyPoints < 0)
            {
                customer.LoyaltyPoints = 0;
            }

            CalculateTier(customer);
        }

        public void GetTopCustomer()
        {
            Customer? customer =
                Customers
                    .OrderByDescending(
                        c => c.LoyaltyPoints)
                    .FirstOrDefault();

            if (customer != null)
            {
                DisplayCustomer(customer);
            }
        }

        public void CalculateTier(
            Customer customer)
        {
            if (customer.LoyaltyPoints >= 1000)
            {
                customer.Tier =
                    CustomerTier.Platinum;
            }
            else if (customer.LoyaltyPoints >= 500)
            {
                customer.Tier =
                    CustomerTier.Gold;
            }
            else if (customer.LoyaltyPoints >= 100)
            {
                customer.Tier =
                    CustomerTier.Silver;
            }
            else
            {
                customer.Tier =
                    CustomerTier.Bronze;
            }
        }

        public void DisplayStatistics()
        {
            Console.WriteLine(
                $"\nTotal Customers: {Customers.Count}");

            Console.WriteLine(
                $"Active Members: {Customers.Count(c => c.IsActiveMember)}");

            Console.WriteLine(
                $"Total Loyalty Points: {Customers.Sum(c => c.LoyaltyPoints)}");
        }
    }
}