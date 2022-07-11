﻿using BurgerWebApp.DataAccess;
using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp.Controllers
{
    public class ExtraController : Controller
    {
        private readonly IExtraService _extraService;

        public ExtraController(IExtraService extraService)
        {
            _extraService = extraService;
        }

        public IActionResult Index()
        {
            List<ExtraViewModel> extras = _extraService.GetAll();
            return View(extras);
        }

        public IActionResult Create()
        {
            return View(new ExtraViewModel());
        }

        [HttpPost]
        public IActionResult Create(ExtraViewModel model)
        {
            _extraService.Create(model);
            return RedirectToAction("index");
        }

        public IActionResult Edit(Guid id)
        {
            ExtraViewModel model = _extraService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ExtraViewModel model)
        {
            _extraService.Edit(model);
            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid id)
        {
            _extraService.Delete(id);
            return RedirectToAction("index");
        }
    }
}
