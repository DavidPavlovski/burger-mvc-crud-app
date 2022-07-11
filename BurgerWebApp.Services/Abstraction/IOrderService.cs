using BurgerWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.Services.Abstraction
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();
        OrderViewModel GetById(Guid id);
        void Create(OrderViewModel model);
        void Edit(OrderViewModel model);
        void Delete(Guid id);
    }
}
