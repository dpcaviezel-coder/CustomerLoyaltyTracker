namespace CustomerLoyaltyTracker
{
    class Program
    {
        static void Main()
        {
            CustomerManager manager = new();
            FileManager fileManager = new();

            // Seed Data
            manager.AddCustomer(
                new Customer(
                    100,
                    "Haisley",
                    "haisleyWins@example.com",
                    "(122) 214-1215",
                    450,
                    CustomerTier.Silver,
                    true));

            manager.AddCustomer(
                new Customer(
                    101,
                    "Reinan",
                    "reinan_reinan@example.com",
                    "(233) 777-6665",
                    45,
                    CustomerTier.Bronze,
                    true));

            manager.AddCustomer(
                new Customer(
                    102,
                    "Eisley",
                    "eisley123@example.com",
                    "(234) 123-5675",
                    700,
                    CustomerTier.Gold,
                    false));

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Customer Loyalty Tracker =====");

                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Display Customer");
                Console.WriteLine("3. Display All Customers");
                Console.WriteLine("4. Award Points");
                Console.WriteLine("5. Redeem Points");
                Console.WriteLine("6. Show Top Customer");
                Console.WriteLine("7. View Statistics");
                Console.WriteLine("8. Save");
                Console.WriteLine("9. Load");
                Console.WriteLine("10. Exit");

                Console.Write("\nChoice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        Customer newCustomer =
                            CreateCustomer();

                        manager.AddCustomer(
                            newCustomer);

                        Console.WriteLine(
                            "Customer Added.");

                        break;

                    case "2":

                        Console.Write(
                            "Customer Id: ");

                        int searchId =
                            int.Parse(
                                Console.ReadLine() ?? "0");

                        Customer? foundCustomer =
                            manager.SearchCustomer(
                                searchId);

                        if (foundCustomer != null)
                        {
                            manager.DisplayCustomer(
                                foundCustomer);
                        }
                        else
                        {
                            Console.WriteLine(
                                "Customer not found.");
                        }

                        break;

                    case "3":

                        manager.DisplayAllCustomers();

                        break;

                    case "4":

                        Console.Write(
                            "Customer Id: ");

                        int awardId =
                            int.Parse(
                                Console.ReadLine() ?? "0");

                        Customer? awardCustomer =
                            manager.SearchCustomer(
                                awardId);

                        if (awardCustomer != null)
                        {
                            Console.Write(
                                "Points: ");

                            int points =
                                int.Parse(
                                    Console.ReadLine() ?? "0");

                            manager.AwardPoints(
                                awardCustomer,
                                points);
                        }

                        break;

                    case "5":

                        Console.Write(
                            "Customer Id: ");

                        int redeemId =
                            int.Parse(
                                Console.ReadLine() ?? "0");

                        Customer? redeemCustomer =
                            manager.SearchCustomer(
                                redeemId);

                        if (redeemCustomer != null)
                        {
                            Console.Write(
                                "Points: ");

                            int points =
                                int.Parse(
                                    Console.ReadLine() ?? "0");

                            manager.RedeemPoints(
                                redeemCustomer,
                                points);
                        }

                        break;

                    case "6":

                        manager.GetTopCustomer();

                        break;

                    case "7":

                        manager.DisplayStatistics();

                        break;

                    case "8":

                        fileManager.SaveToJson(
                            manager.Customers);

                        break;

                    case "9":

                        manager.Customers.Clear();

                        manager.Customers.AddRange(
                            fileManager.LoadFromJson());

                        break;

                    case "10":

                        running = false;

                        break;
                }
            }
        }

        static Customer CreateCustomer()
        {
            Console.Write("Id: ");
            int id =
                int.Parse(
                    Console.ReadLine() ?? "0");

            Console.Write("Name: ");
            string name =
                Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string email =
                Console.ReadLine() ?? "";

            Console.Write("Phone Number: ");
            string phone =
                Console.ReadLine() ?? "";

            Console.Write("Loyalty Points: ");
            int points =
                int.Parse(
                    Console.ReadLine() ?? "0");

            Console.Write(
                "Tier (Bronze, Silver, Gold, Platinum): ");

            string tierInput =
                Console.ReadLine() ?? "Bronze";

            Enum.TryParse(
                tierInput,
                true,
                out CustomerTier tier);

            Console.Write(
                "Active Member (true/false): ");

            bool activeMember =
                bool.Parse(
                    Console.ReadLine() ?? "true");

            return new Customer(
                id,
                name,
                email,
                phone,
                points,
                tier,
                activeMember);
        }
    }
}
