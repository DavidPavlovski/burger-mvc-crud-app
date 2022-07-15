using BurgerWebApp.DataAccess.Abstraction;
using BurgerWebApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.DataAccess.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly BurgerWebAppDbContext _dbContext;

        public LocationRepository(BurgerWebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Location> GetAll()
        {
            return _dbContext.Locations.ToList();
        }

        public Location GetById(int id)
        {
            return _dbContext.Locations.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Location entity)
        {
            _dbContext.Locations.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Location entity)
        {
            var item = GetById(entity.Id);
            if(item != null)
            {
                _dbContext.Locations.Update(entity);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);

            if(item != null)
            {
                _dbContext.Locations.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
