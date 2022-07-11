using BurgerWebApp.Domain;
using BurgerWebApp.ViewModels;

namespace BurgerWebApp.Mappers
{
    public static class BurgerOrderItemMapper
    {
        public static BurgerOrderItemViewModel ToViewModel(this BurgerOrderItem burger)
        {
            return new BurgerOrderItemViewModel()
            {
                Burger=burger.Burger.ToViewModel(),
                Quantity = burger.Quantity,
                IsSelected=false,
            };
        }
    }
}
