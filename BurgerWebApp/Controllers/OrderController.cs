using BurgerWebApp.Mappers;
using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;
        private readonly IExtraService _extraService;

        public OrderController(IOrderService orderService, IBurgerService burgerService, IExtraService extraService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
            _extraService = extraService;
        }

        public IActionResult Index()
        {
            List<OrderViewModel> orders = _orderService.GetAll();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            OrderViewModel model = _orderService.GetById(id);
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.burgers = _burgerService.GetAll();
            ViewBag.extras = _extraService.GetAll();
            return View(new OrderViewModel());
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            _orderService.Create(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
