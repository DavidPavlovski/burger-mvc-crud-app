﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(Guid id);
        void Insert (T entity);
        void Update (T entity);
        void DeleteById (Guid id);
    }
}