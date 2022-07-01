using BurgerWebApp.DataAccess;
using BurgerWebApp.DomainModels;
using BurgerWebApp.Mappers;
using BurgerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<OrderViewModel> orders = BurgerDb.Orders.OrderViewModels();
            return View(orders);
        }

        public IActionResult Details(Guid id)
        {
            OrderDetailsViewModel model = BurgerDb.Orders.FirstOrDefault(x => x.Id == id).ToDetailsViewModel();
            if (model == null)
            {
                throw new Exception($"Item with id :{id} does not exist");
            }
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.burgers = BurgerDb.Burgers.BurgerViewModels();
            ViewBag.extras = BurgerDb.Extras.ExtraViewModels();
            return View(new OrderViewModel());
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
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
                Burger selectedBurger = BurgerDb.Burgers.FirstOrDefault(x => x.Id == item.BurgerId);
                burgers.Add(new BurgerOrderItem(selectedBurger, newOrder, item.Quantity));
            }
            foreach (var item in selectedExtras)
            {
                Extra selectedExtra = BurgerDb.Extras.FirstOrDefault(x => x.Id == item.ExtraId);
                extras.Add(new ExtraOrderItem(selectedExtra, newOrder, item.Quantity));
            }
            newOrder.Burgers = burgers;
            newOrder.Extras = extras;
            newOrder.TotalPrice = newOrder.Burgers.Sum(x => x.Burger.Price * x.Quantity) + newOrder.Extras.Sum(x => x.Extra.Price * x.Quantity);
            BurgerDb.Orders.Add(newOrder);
            return RedirectToAction("Index");
        }
    }
}
