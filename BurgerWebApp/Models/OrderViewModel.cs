using BurgerWebApp.DomainModels;

namespace BurgerWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public List<ExtraOrderItemViewModel> Extras { get; set; }
        public List<BurgerOrderItemViewModel> Burgers { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
