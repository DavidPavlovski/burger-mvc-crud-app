using BurgerWebApp.DataAccess.Abstraction;
using BurgerWebApp.DataAccess.Storage;
using BurgerWebApp.Domain;
using BurgerWebApp.Mappers;
using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Burger> _burgerRepository;
        private readonly IRepository<Extra> _extraRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Burger> burgerRepository, IRepository<Extra> extraRepository)
        {
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
            _extraRepository = extraRepository;
        }

        public List<OrderViewModel> GetAll()
        {

            var items = _orderRepository.GetAll();
            return _orderRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }

        public OrderViewModel GetById(Guid id)
        {
            Order model = _orderRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"Item with id :{id} does not exist");
            }
            return model.ToViewModel();
        }

        public void Create(OrderViewModel model)
        {
            List<BurgerOrderItemViewModel> selectedBurgers = model.Burgers.Where(x => x.IsSelected && x.Quantity > 0).ToList();
            List<ExtraOrderItemViewModel> selectedExtras = model.Extras.Where(x => x.IsSelected && x.Quantity > 0).ToList();
            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.Address))
            {
                throw new Exception("Name and Address fields cannot be empty");
            }
            else if (selectedBurgers.Count == 0 && selectedExtras.Count == 0)
            {
                throw new Exception("Cannot make an order without items");
            }
            Order newOrder = new Order
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
            };

            List<BurgerOrderItem> burgers = new List<BurgerOrderItem>();
            List<ExtraOrderItem> extras = new List<ExtraOrderItem>();
            foreach (var item in selectedBurgers)
            {
                Burger selectedBurger = _burgerRepository.GetById(item.Burger.Id);
                burgers.Add(new BurgerOrderItem(selectedBurger,newOrder, item.Quantity , item.Price));
            }
            foreach (var item in selectedExtras)
            {
                Extra selectedExtra = _extraRepository.GetById(item.Extra.Id);
                extras.Add(new ExtraOrderItem(selectedExtra, newOrder, item.Quantity , item.Price));
            }
            newOrder.Burgers = burgers;
            newOrder.Extras = extras;
            newOrder.TotalPrice = newOrder.Burgers.Sum(x => x.Burger.Price * x.Quantity) + newOrder.Extras.Sum(x => x.Extra.Price * x.Quantity);
            _orderRepository.Insert(newOrder);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderViewModel model)
        {
            throw new NotImplementedException();
        }

    }
}
