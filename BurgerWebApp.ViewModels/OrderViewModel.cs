namespace BurgerWebApp.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public List<ExtraOrderItemViewModel> Extras { get; set; }
        public List<BurgerOrderItemViewModel> Burgers { get; set; }
        public int LocationId { get; set; }
        public LocationViewModel Location { get; set; }
        public decimal TotalPrice { get; set; }
    }
}