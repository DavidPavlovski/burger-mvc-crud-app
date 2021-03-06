
using BurgerWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.Services.Abstraction
{
    public interface IBurgerOrderItemService
    {
        BurgerOrderItemViewModel GetById(int it);
        void Edit(BurgerOrderItemViewModel model);
        void Create(BurgerOrderItemViewModel model);
        int Delete(int id);
    }
}
