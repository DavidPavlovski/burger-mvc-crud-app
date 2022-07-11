using BurgerWebApp.DataAccess.Storage;
using BurgerWebApp.Mappers;
using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            List<OrderViewModel> orders = _orderService.GetAll();
            return View(orders);
        }

        public IActionResult Details(Guid id)
        {
            OrderViewModel model = _orderService.GetById(id);
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
            _orderService.Create(model);
            return RedirectToAction("Index");
        }
    }
}
