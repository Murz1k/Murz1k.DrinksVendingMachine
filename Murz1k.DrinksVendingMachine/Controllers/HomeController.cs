using Murz1k.DrinksVendingMachine.Models;
using Murz1k.DrinksVendingMachine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Murz1k.DrinksVendingMachine.Controllers
{
    public class HomeController : Controller
    {
        private BeverageService _service;

        public HomeController()
        {
            _service = new BeverageService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAll()
        {
            return Json(_service.GetAllBeverage());
        }

        [HttpPost]
        public void BuyBeverage(int id)
        {
            var beverage = _service.GetBeverage(id);
            beverage.Count--;
            _service.EditBeverage(id, beverage);
        }
        [HttpPost]
        public void Save()
        {
            _service.SaveData();
        }
    }
}