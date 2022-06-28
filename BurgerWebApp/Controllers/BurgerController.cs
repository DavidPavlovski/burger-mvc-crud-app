using BurgerWebApp.DataAccess;
using BurgerWebApp.DomainModels;
using BurgerWebApp.Mappers;
using BurgerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp.Controllers
{
    public class BurgerController : Controller
    {
        public IActionResult Index()
        {
            List<BurgerViewModel> burgers = BurgerDb.Burgers.BurgerViewModels();
            return View(burgers);
        }

        public IActionResult Details(Guid id)
        {
            BurgerViewModel burger = BurgerDb.Burgers.FirstOrDefault(x => x.Id == id).ToViewModel();
            if (burger == null)
            {
                throw new Exception("The page you are trying to reach does not exist");
            }
            return View(burger);
        }

        public IActionResult Edit(Guid id)
        {
            BurgerViewModel burger = BurgerDb.Burgers.FirstOrDefault(x => x.Id == id).ToViewModel();
            if (burger == null)
            {
                throw new Exception("The page you are trying to reach does not exist");
            }
            return View(burger);
        }

        [HttpPost]
        public IActionResult Edit(BurgerViewModel model)
        {
            Burger burger = BurgerDb.Burgers.FirstOrDefault(x => x.Id == model.Id);
            if (burger == null)
            {
                throw new Exception("The endpoint does not exist");
            }
            burger.Update(model);
            return RedirectToAction("Index", "Burger");
        }

        public IActionResult Create()
        {
            return View(new BurgerViewModel());
        }

        [HttpPost]
        public IActionResult Create(BurgerViewModel model)
        {
            Burger newBurger = new Burger(model.Name, model.Ingredients, model.ImageUrl);
            BurgerDb.Burgers.Add(newBurger);
            return RedirectToAction("Details", "Burger", new { id = newBurger.Id });
        }

        public IActionResult Delete(Guid id)
        {
            Burger burgerToDelete = BurgerDb.Burgers.FirstOrDefault(x => x.Id == id);
            if (burgerToDelete == null)
            {
                throw new Exception("Cannot perform that action");
            }
            BurgerDb.Burgers.Remove(burgerToDelete);
            return RedirectToAction("Index");
        }
    }
}
