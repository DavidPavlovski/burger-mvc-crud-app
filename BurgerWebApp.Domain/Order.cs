namespace BurgerWebApp.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public List<ExtraOrderItem> Extras { get; set; }
        public List<BurgerOrderItem> Burgers { get; set; }
        public decimal TotalPrice { get; set; }

        public Order() { }

        public Order(string firstName, string lastName, string address, decimal totalPrice)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Extras = new List<ExtraOrderItem>();
            Burgers = new List<BurgerOrderItem>();
            TotalPrice = totalPrice;
        }
    }
}
