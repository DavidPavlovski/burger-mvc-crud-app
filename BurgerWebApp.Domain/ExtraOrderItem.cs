namespace BurgerWebApp.Domain
{
    public class ExtraOrderItem
    {
        public Guid Id { get; set; }
        public Extra Extra { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public ExtraOrderItem() { }
        public ExtraOrderItem(Extra extra,Order order, int quantity)
        {
            Id = Guid.NewGuid();
            Extra = extra;
            Order = order;
            Quantity = quantity;
        }
    }
}
