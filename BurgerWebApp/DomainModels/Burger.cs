using BurgerWebApp.Models;

namespace BurgerWebApp.DomainModels
{
    public class Burger
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public Burger()
        {

        }
        public Burger(string name, string ingredients, string imageUrl)
        {
            Id = Guid.NewGuid();
            Name = name;
            Ingredients = ingredients;
            ImageUrl = imageUrl;
        }

        public void Update(BurgerViewModel model)
        {
            Name = model.Name;
            Ingredients = model.Ingredients;
            ImageUrl = model.ImageUrl;
        }
    }
}

