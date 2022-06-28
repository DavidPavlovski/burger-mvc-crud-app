namespace BurgerWebApp.Models
{
    public class BurgerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public BurgerViewModel()
        {

        }
        public BurgerViewModel(string name, string ingredients, string imageUrl)
        {
            Id = Guid.NewGuid();
            Name = name;
            Ingredients = ingredients;
            ImageUrl = imageUrl;
        }
    }
}
