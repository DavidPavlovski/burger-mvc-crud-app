using BurgerWebApp.ViewModels;

namespace BurgerWebApp.Domain
{
    public class Extra
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Extra() { }
        public Extra(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }


        public void Update(ExtraViewModel model)
        {
            Name = model.Name;
            Price = model.Price;
        }
    }
}
