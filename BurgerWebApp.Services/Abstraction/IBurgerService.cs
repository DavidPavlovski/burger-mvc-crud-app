﻿using BurgerWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.Services.Abstraction
{
    public interface IBurgerService
    {
        List<BurgerViewModel> GetAll();
        BurgerViewModel GetById(Guid id);
        Guid Create(BurgerViewModel model);
        void Edit(BurgerViewModel model);
        void Delete(Guid id);
    }
}
