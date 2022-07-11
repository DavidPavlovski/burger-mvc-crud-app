namespace BurgerWebApp.ViewModels
{
    public class ExtraOrderItemViewModel
    {
        public Guid Id { get; set; }
        public ExtraViewModel Extra { get; set; }
        public OrderViewModel Order { get; set; }
        public int Quantity { get; set; }
        public bool IsSelected { get; set; }

    }
}
