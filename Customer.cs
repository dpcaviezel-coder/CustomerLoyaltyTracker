namespace CustomerLoyaltyTracker
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int LoyaltyPoints { get; set; }
        public Enum Tier { get; set; } = new CustomerTier(); 
        public bool IsActiveMember { get; set; }

        public Customer(int id, string name, string email, string phoneNumber, Enum tier, int loyaltyPoints)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            LoyaltyPoints = loyaltyPoints;
            Tier = tier;
            IsActiveMember = true;
        }
        public Customer(int id, string name, string email, string phoneNumber, int loyaltyPoints, string tier, bool isActiveMember)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            LoyaltyPoints = loyaltyPoints;
            Tier = Enum.TryParse(typeof(CustomerTier), tier, out var parsedTier) ? (CustomerTier)parsedTier : CustomerTier.Bronze;
            IsActiveMember = isActiveMember;
        }
    }
}
