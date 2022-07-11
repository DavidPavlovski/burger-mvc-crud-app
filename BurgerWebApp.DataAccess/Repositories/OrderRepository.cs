using BurgerWebApp.DataAccess.Abstraction;
using BurgerWebApp.DataAccess.Storage;
using BurgerWebApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.DataAccess.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        public List<Order> GetAll()
        {
            return BurgerDb.Orders;
        }
        public Order GetById(Guid id)
        {
            return BurgerDb.Orders.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Order entity)
        {
            BurgerDb.Orders.Add(entity);
        }
        public void Update(Order entity)
        {
            var item = GetById(entity.Id);
            if(item != null)
            {
                int index = BurgerDb.Orders.IndexOf(item);
                BurgerDb.Orders[index] = entity;
            }
        }
        public void DeleteById(Guid id)
        {
            var item = GetById(id);
            if (item != null)
            {
                BurgerDb.Orders.Remove(item);
            }
        }
    }
}
