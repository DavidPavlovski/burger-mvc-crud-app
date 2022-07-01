using BurgerWebApp.DomainModels;
using BurgerWebApp.Models;

namespace BurgerWebApp.Mappers
{
    public static class BurgerOrderItemMapper
    {
        public static BurgerOrderItemViewModel ToViewModel(this BurgerOrderItem burger)
        {
            return new BurgerOrderItemViewModel()
            {
                BurgerId=burger.Burger.Id,
                OrderId = burger.Order.Id,
                Quantity = 0,
                IsSelected=false,
            };
        }
    }
}
