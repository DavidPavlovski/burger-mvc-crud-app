namespace BurgerWebApp.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public ICollection<ExtraOrderItem> Extras { get; set; }
        public ICollection<BurgerOrderItem> Burgers { get; set; }
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

        public Order(string firstName, string lastName, string address, ICollection<ExtraOrderItem> extras, ICollection<BurgerOrderItem> burgers, decimal totalPrice)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Extras = extras;
            Burgers = burgers;
            TotalPrice = totalPrice;
        }
    }
}