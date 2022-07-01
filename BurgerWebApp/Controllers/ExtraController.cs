using BurgerWebApp.DataAccess;
using BurgerWebApp.DomainModels;
using BurgerWebApp.Mappers;
using BurgerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp.Controllers
{
    public class ExtraController : Controller
    {
        public IActionResult Index()
        {
            List<ExtraViewModel> extras = BurgerDb.Extras.ExtraViewModels();
            return View(extras);
        }

        public IActionResult Create()
        {
            return View(new ExtraViewModel());
        }

        [HttpPost]
        public IActionResult Create(ExtraViewModel model)
        {
            if(string.IsNullOrEmpty(model.Name) || model.Price <=0)
            {
                throw new Exception("All inputs must be filled and price cannot be 0 or less");
            }
            if(BurgerDb.Extras.Any(x => x.Name == model.Name))
            {
                throw new Exception("Extra with that name already exists");
            }
            BurgerDb.Extras.Add(new Extra(model.Name, model.Price));
            return RedirectToAction("index");
        }

        public IActionResult Edit(Guid id)
        {
            ExtraViewModel viewModel = BurgerDb.Extras.FirstOrDefault(x => x.Id == id).ToViewModel();
            if(viewModel == null)
            {
                throw new Exception($"Extra with id: {id} does not exist");
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ExtraViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || model.Price <= 0)
            {
                throw new Exception("All inputs must be filled and price cannot be 0 or less");
            }
            if (BurgerDb.Extras.Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new Exception("Extra with that name already exists");
            }
            Extra extra = BurgerDb.Extras.FirstOrDefault(x => x.Id == model.Id);
            if(extra == null)
            {
                throw new Exception($"Extra with id : {model.Id} does not exist");
            }
            extra.Update(model);
            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid id)
        {
            Extra extraToDelete = BurgerDb.Extras.FirstOrDefault(x => x.Id == id);
            if(extraToDelete == null)
            {
                throw new Exception($"Extra with id : {id} does not exist");
            }
            BurgerDb.Extras.Remove(extraToDelete);
            return RedirectToAction("index");
        }
    }
}
