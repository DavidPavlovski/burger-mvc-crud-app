using BurgerWebApp.DomainModels;
using BurgerWebApp.Models;

namespace BurgerWebApp.Mappers
{
    public static class OrderDetailsMapper
    {
        public static OrderDetailsViewModel ToDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                FirstName = order.FirstName,
                LastName = order.LastName,
                Address = order.LastName,
                Extras = order.Extras,
                Burgers = order.Burgers,
                TotalPrice = order.TotalPrice

            };
        }
    }
}
