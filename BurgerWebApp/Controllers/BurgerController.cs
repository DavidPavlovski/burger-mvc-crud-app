using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp.Controllers
{
    public class BurgerController : Controller
    {
        private readonly IBurgerService _burgerSercvice;


        public BurgerController(IBurgerService burgerSercvice)
        {
            _burgerSercvice = burgerSercvice;
        }

        public IActionResult Index()
        {
            List<BurgerViewModel> burgers = _burgerSercvice.GetAll();
            return View(burgers);
        }

        public IActionResult Details(int id)
        {
            BurgerViewModel burger = _burgerSercvice.GetById(id);
            return View(burger);
        }

        public IActionResult Edit(int id)
        {
            BurgerViewModel burger = _burgerSercvice.GetById(id);
            return View(burger);
        }

        [HttpPost]
        public IActionResult Edit(BurgerViewModel model)
        {
            _burgerSercvice.Edit(model);
            return RedirectToAction("Index", "Burger");
        }

        public IActionResult Create()
        {
            return View(new BurgerViewModel());
        }

        [HttpPost]
        public IActionResult Create(BurgerViewModel model)
        {
            int id = _burgerSercvice.Create(model);
            return RedirectToAction("Details", "Burger", new { id = id });
        }

        public IActionResult Delete(int id)
        {
           _burgerSercvice.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
