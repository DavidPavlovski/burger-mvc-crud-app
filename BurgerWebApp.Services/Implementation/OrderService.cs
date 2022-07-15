using BurgerWebApp.DataAccess.Abstraction;
using BurgerWebApp.Domain;
using BurgerWebApp.Mappers;
using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;

namespace BurgerWebApp.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;


        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public List<OrderViewModel> GetAll()
        {
            var items = _orderRepository.GetAll();
            return _orderRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }

        public OrderViewModel GetById(int id)
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
            Order newOrder = new Order(model.FirstName, model.LastName, model.Address, model.LocationId);

            List<BurgerOrderItem> burgers = new List<BurgerOrderItem>();
            List<ExtraOrderItem> extras = new List<ExtraOrderItem>();
            foreach (var item in selectedBurgers)
            {
                burgers.Add(new BurgerOrderItem(item.Burger.Id, newOrder.Id, item.Quantity, item.Price));
            }
            foreach (var item in selectedExtras)
            {
                extras.Add(new ExtraOrderItem(item.Extra.Id, newOrder.Id, item.Quantity, item.Price));
            }
            newOrder.Burgers = burgers;
            newOrder.Extras = extras;
            newOrder.TotalPrice = burgers.Sum(x => x.Price * x.Quantity) + extras.Sum(x => x.Price * x.Quantity);
            _orderRepository.Insert(newOrder);
        }

        public void Delete(int id)
        {
            var item = _orderRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Order with Id:{id} does not exist");
            }
            _orderRepository.DeleteById(id);
        }

        public void Edit(OrderViewModel model)
        {
            if (String.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.Address))
            {
                throw new Exception("All text fields must be filled");
            }
            Order order = _orderRepository.GetById(model.Id);
            if (order == null)
            {
                throw new Exception($"Order with id : {model.Id} does not exist");
            }
            order.Update(model);
            _orderRepository.Update(order);
        }
    }
}
