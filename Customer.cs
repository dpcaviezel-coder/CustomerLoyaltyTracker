namespace CustomerLoyaltyTracker
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int LoyaltyPoints { get; set; }

        public CustomerTier Tier { get; set; }

        public bool IsActiveMember { get; set; }

        public Customer(
            int id,
            string name,
            string email,
            string phoneNumber,
            int loyaltyPoints,
            CustomerTier tier,
            bool isActiveMember)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            LoyaltyPoints = loyaltyPoints;
            Tier = tier;
            IsActiveMember = isActiveMember;
        }
    }
}
