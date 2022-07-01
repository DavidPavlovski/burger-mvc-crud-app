namespace BurgerWebApp.Models
{
    public class ExtraOrderItemViewModel
    {
        public Guid Id { get; set; }
        public Guid ExtraId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public bool IsSelected { get; set; }
        
    }
}
