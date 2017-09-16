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
        private CoinService _coinService;

        public HomeController()
        {
            _service = new BeverageService();
            _coinService = new CoinService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllCoins()
        {
            return Json(_coinService.GetAllCoins());
        }

        [HttpPost]
        public JsonResult GetAll()
        {
            return Json(_service.GetAllBeverage());
        }

        public void BuyBeverage(int id)
        {
            var beverage = _service.GetBeverage(id);
            beverage.Count--;
            _service.EditBeverage(id, beverage);
        }

        public void Save()
        {
            _service.SaveData();
        }
    }
}