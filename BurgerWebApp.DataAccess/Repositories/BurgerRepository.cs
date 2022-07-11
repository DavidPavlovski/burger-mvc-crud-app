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
    public class BurgerRepository : IRepository<Burger>
    {
        public List<Burger> GetAll()
        {
            return BurgerDb.Burgers;
        }

        public Burger GetById(Guid id)
        {
            return BurgerDb.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Burger entity)
        {

            BurgerDb.Burgers.Add(entity);
        }

        public void Update(Burger entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                int index = BurgerDb.Burgers.IndexOf(item);
                BurgerDb.Burgers[index] = entity;
            }
        }

        public void DeleteById(Guid id)
        {
            var item = GetById(id);
            if (item != null)
            {
                BurgerDb.Burgers.Remove(item);
            }
        }
    }
}
