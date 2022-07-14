﻿using BurgerWebApp.DataAccess.Abstraction;
using BurgerWebApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.DataAccess.Repositories
{
    public class ExtraOrderItemRepository : IRepository<ExtraOrderItem>
    {
        private readonly BurgerWebAppDbContext _dbContext;

        public ExtraOrderItemRepository(BurgerWebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExtraOrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExtraOrderItem GetById(int id)
        {
            return _dbContext.ExtraOrderItems.Include(x => x.Extra).Include(x => x.Order).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(ExtraOrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ExtraOrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
