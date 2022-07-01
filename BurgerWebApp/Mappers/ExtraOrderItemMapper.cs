using BurgerWebApp.DomainModels;
using BurgerWebApp.Models;

namespace BurgerWebApp.Mappers
{
    public static class ExtraOrderItemMapper
    {
        public static ExtraOrderItemViewModel ToViewModel(this ExtraOrderItem extra)
        {
            return new ExtraOrderItemViewModel
            {
                Id = extra.Id,
                ExtraId = extra.Extra.Id,
                OrderId = extra.Order.Id,
                Quantity = 0,
                IsSelected = false
            };
        }
    }
}
