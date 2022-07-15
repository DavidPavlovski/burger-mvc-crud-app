using BurgerWebApp.ViewModels;

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
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public bool IsOrderCompleted { get; set; }
        public Order() { }
        public Order(string firstName, string lastName, string address, int locationId)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Extras = new List<ExtraOrderItem>();
            Burgers = new List<BurgerOrderItem>();
            LocationId = locationId;
            IsOrderCompleted = false;
        }

        public void CompleteOrder()
        {
            IsOrderCompleted = true;
        }

        public void Update(OrderViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Address = model.Address;
            LocationId = model.LocationId;
        }
    }
}