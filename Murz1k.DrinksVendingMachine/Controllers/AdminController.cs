using Murz1k.DrinksVendingMachine.Models;
using Murz1k.DrinksVendingMachine.Services;
using Murz1k.DrinksVendingMachine.Utilities;
using System;
using System.IO;
using System.Web.Mvc;

namespace Murz1k.DrinksVendingMachine.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        private BeverageService _service;
        private CoinService _coinService;

        public AdminController()
        {
            _service = new BeverageService();
            _coinService = new CoinService();
        }
        public ActionResult Index(string secretKey="")
        {
            if(secretKey=="6396482g35ghlh5gl384")
            {
                IoCProvider.TimeSession = DateTime.Now + new TimeSpan(0, 5, 0);
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public void Add(Beverage beverage)
        {
            _service.AddBeverage(beverage);
        }

        public void Edit(int id, Beverage beverage)
        {
            _service.EditBeverage(id, beverage);
        }

        public void Delete(int id)
        {
            var path = _service.GetBeverage(id).ImagePath;
            DeleteImage(path);
            _service.DeleteBeverage(id);
        }

        public void AddCoin(Coin coin)
        {
            _coinService.AddCoin(coin);
        }

        public void EditCoin(int id, Coin coin)
        {
            _coinService.EditCoin(id, coin);
        }
        
        public void DeleteCoin(int id)
        {
            _coinService.DeleteCoin(id);
        }

        private void DeleteImage(string path)
        {
            System.IO.File.Delete(Server.MapPath("~"+path));
        }
        
        public void SaveImage()
        {
            var file = Request.Files[0];
            var stream = file.InputStream;
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
            using (var fileStream = System.IO.File.Create(path))
            {
                stream.CopyTo(fileStream);
            }
        }
    }
}