using System;
using System.ComponentModel.Design;

namespace CustomerLoyaltyTracker
{
    class Program
    {

        static void Main()
        {
            
            Customer customer = new Customer(0, string.Empty, string.Empty, string.Empty, CustomerTier.Bronze, 0);

            CustomerManager manager = new CustomerManager();

            manager.AddCustomer(new Customer(100, "Haisley", "haisleyWins@example.com", "(122) 214-1215", 450, "Silver", true ));
            manager.AddCustomer(new Customer(101, "Reinan", "reinan_reinan@example.com", "(234) 123-5675", 45, "Bronze", true));
            manager.AddCustomer(new Customer(102, "Eisley", "eisley123@example.com", "(233) 777-6665", 700, "Gold", false));

            FileManager fileManager = new(customer, manager);

            fileManager.SaveToJson(customer);

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Remove Customer");
            Console.WriteLine("3. Edit Customer");
            Console.WriteLine("4. Search Customer");
            Console.WriteLine("5. Display Customer");
            Console.WriteLine("6. Display All Customers");
            Console.WriteLine("7. Award Points");
            Console.WriteLine("8. Redeem Points");
            Console.WriteLine("9. Show Top Customer");
            Console.WriteLine("10. Calculate Tier");
            Console.WriteLine("11. Display Statistics");
            Console.WriteLine("12. Sort Customers By Points");

            Console.WriteLine("13. Save");
            Console.WriteLine("14. Load");
            Console.WriteLine("15. Exit");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // Add Customer
                    manager.AddCustomer(customer);
                    break;

                case "2":
                    // Remove Customer
                    manager.RemoveCustomer(customer);
                    break;
                case "3":
                    manager.EditCustomer(customer);
                    break;
                case "4":
                    manager.SearchCustomer(customer);
                    break;
                case "5":
                    manager.DisplayCustomer(customer);
                    break;
                case "6":
                    manager.DisplayAllCustomers();
                    break;
                case "7":
                    manager.AwardPoints(customer);
                    break;
                case "8":
                    manager.RedeemPoints(customer);
                    break;
                case "9":
                    manager.GetTopCustomer();
                    break;
                case "10":
                    manager.CalculateTier(customer);
                    break;
                case "11":
                    manager.DisplayStatistics(customer, manager.list);
                    break;
                    manager.DisplayStatistics(customer, manager.list);
                    break;
                case "12":
                    manager.SortCustomerByPoints(manager.list);
                    break;
                case "13":
                    fileManager.SaveToJson(customer);
                    break;
                case "14":
                    fileManager.LoadFromJson(customer);
                    break;
                case "15":
                    Environment.Exit(0);
                    break;
                case "default":
                    Console.WriteLine("You entered an invalid character.");
                    break;

            }
        }
    }
}



