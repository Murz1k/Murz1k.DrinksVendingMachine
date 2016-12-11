using Murz1k.DrinksVendingMachine.Models;
using Murz1k.DrinksVendingMachine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Murz1k.DrinksVendingMachine.Services
{
    public class CoinService
    {
        private DrinksVendingContext _context;

        public CoinService()
        {
            _context = IoCProvider.GetComponent<DrinksVendingContext>();
        }

        public void AddCoin (Coin coin)
        {
            _context.Coins.Add(coin);
        }

        public void DeleteCoin(int id)
        {
            _context.Coins.Remove(_context.Coins.Find(id));
        }

        public void EditCoin(int id, Coin coin)
        {
            var item = _context.Coins.Find(id);
            item.Count = coin.Count;
            item.IsLocked = coin.IsLocked;
            item.Value = coin.Value;
        }

        public IEnumerable<Coin> GetAllCoins()
        {
            return _context.Coins.OrderBy(coin=>coin.Value);
        }
    }
}