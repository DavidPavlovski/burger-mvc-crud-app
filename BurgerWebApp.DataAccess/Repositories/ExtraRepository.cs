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
    public class ExtraRepository : IRepository<Extra>
    {
        public List<Extra> GetAll()
        {
            return BurgerDb.Extras;
        }
        public Extra GetById(Guid id)
        {
            return BurgerDb.Extras.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Extra entity)
        {
            BurgerDb.Extras.Add(entity);
        }
        public void Update(Extra entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                int index = BurgerDb.Extras.IndexOf(item);
                BurgerDb.Extras[index] = entity;
            }
        }
        public void DeleteById(Guid id)
        {
            var item = GetById(id);
            if (item != null)
            {
                BurgerDb.Extras.Remove(item);
            }
        }
    }
}
