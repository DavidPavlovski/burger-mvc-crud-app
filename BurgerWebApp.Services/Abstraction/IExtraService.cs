using BurgerWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.Services.Abstraction
{
    public interface IExtraService
    {
        List<ExtraViewModel> GetAll();
        ExtraViewModel GetById(Guid id);
        void Create(ExtraViewModel model);
        void Edit(ExtraViewModel model);
        void Delete(Guid id);
    }
}
