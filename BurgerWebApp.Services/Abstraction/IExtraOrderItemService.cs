using BurgerWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.Services.Abstraction
{
    public interface IExtraOrderItemService
    {
        ExtraOrderItemViewModel GetById(int it);
        void Edit(ExtraOrderItemViewModel model);
        void Create(ExtraOrderItemViewModel model);
        int Delete(int id);
    }
}
