using Murz1k.DrinksVendingMachine.Models;
using Murz1k.DrinksVendingMachine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Murz1k.DrinksVendingMachine.Services
{
    public class BeverageService
    {
        private DrinksVendingContext _context;

        public BeverageService()
        {
            _context = IoCProvider.GetComponent<DrinksVendingContext>();
        }

        public void AddBeverage(Beverage beverage)
        {
            _context.Beverages.Add(beverage);
            //_context.SaveChanges();
        }

        public void EditBeverage(int id, Beverage beverage)
        {
            var item = _context.Beverages.Find(id);
            item.Count = beverage.Count;
            item.ImagePath = beverage.ImagePath;
            item.Price = beverage.Price;
            item.Title = beverage.Title;
            //_context.SaveChanges();
        }

        public void DeleteBeverage(int id)
        {
            _context.Beverages.Remove(_context.Beverages.Find(id));
            //_context.SaveChanges();
        }

        public Beverage GetBeverage(int id)
        {
            return _context.Beverages.Find(id);
        }

        public IEnumerable<Beverage> GetAllBeverage()
        {
            return _context.Beverages;
        }

        public void SaveData()
        {
            _context.SaveChanges();
        }
    }
}