using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BurgerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;
        private readonly ILocationService _locationService;



        public HomeController(ILogger<HomeController> logger, IOrderService orderService, IBurgerService burgerService ,ILocationService locationService)
        {
            _logger = logger;
            _orderService = orderService;
            _burgerService = burgerService;
            _locationService = locationService;
        }

        public IActionResult Index()
        {
            var burgers = _burgerService.GetAll().Take(5).ToList();
            return View(burgers);
        }

        public IActionResult Statistics()
        {
            var items = _orderService.GetAll();
            ViewBag.locations = _locationService.GetAll();
            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}