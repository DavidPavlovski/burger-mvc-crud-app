namespace BurgerWebApp.ViewModels
{
    public class BurgerOrderItemViewModel
    {
        public Guid Id { get; set; }
        public BurgerViewModel Burger { get; set; }
        public OrderViewModel Order { get; set; }
        public int Quantity { get; set; }
        public bool IsSelected { get; set; }

    }
}
