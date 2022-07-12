namespace BurgerWebApp.Domain
{
    public class BurgerOrderItem
    {
        public Guid Id { get; set; }
        public Burger Burger { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public BurgerOrderItem() { }
        public BurgerOrderItem(Burger burger, Order order, int quantity, decimal price)
        {
            Id = Guid.NewGuid();
            Burger = burger;
            Order = order;
            Quantity = quantity;
            Price = price;
        }
    }
}
