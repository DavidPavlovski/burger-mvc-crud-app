namespace BurgerWebApp.Models
{
    public class BurgerOrderItemViewModel
    {
        public Guid Id { get; set; }
        public Guid BurgerId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public bool IsSelected { get; set; }
       
    }
}
