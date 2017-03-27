using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        BeverageContext db = new BeverageContext();
        public ActionResult Index()
        {
            var coin = db.Coins.FirstOrDefault(c=>c.Id == 1);
            if (coin != null)
            {
                ViewBag.StatusButton1 = coin.ButtonStatus1;
                ViewBag.StatusButton2 = coin.ButtonStatus2;
                ViewBag.StatusButton5 = coin.ButtonStatus5;
                ViewBag.StatusButton10 = coin.ButtonStatus10;
            }
            IEnumerable<Beverage> beverages = db.Beverages;
            return View(beverages);
        }

        public FileContentResult GetImage(int id)
        {
            Beverage beverage = db.Beverages
                .FirstOrDefault(b => b.Id == id);
            if (beverage != null)
            {
                return File(beverage.ImageData, beverage.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult SendCoin(int coin)
        {
            if (coin == 1)
            {
                Coin coins = db.Coins.FirstOrDefault(c => c.Id == 1);
                if (coins == null)
                {
                    return HttpNotFound();
                }
                coins.NumberOfCoins1 += 1;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            if (coin == 2)
            {
                Coin coins = db.Coins.FirstOrDefault(c => c.Id == 1);
                if (coins == null)
                {
                    return HttpNotFound();
                }
                coins.NumberOfCoins2 += 1;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            if (coin == 5)
            {
                Coin coins = db.Coins.FirstOrDefault(c => c.Id == 1);
                if (coins == null)
                {
                    return HttpNotFound();
                }
                coins.NumberOfCoins5 += 1;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            if (coin == 10)
            {
                Coin coins = db.Coins.FirstOrDefault(c => c.Id == 1);
                if (coins == null)
                {
                    return HttpNotFound();
                }
                coins.NumberOfCoins10 += 1;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult SendBeverage(int id)
        {
            if (id > 0)
            {
                Beverage beverage = db.Beverages.Find(id);
                if (beverage != null) beverage.Amount -= 1;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult GetSurrender(int surrender)
        {
            Coin coins = db.Coins.FirstOrDefault(c => c.Id == 1);

            while (surrender > 0)
            {
                if (coins != null && (coins.NumberOfCoins10 != 0 && surrender >= 10))
                {
                    coins.NumberOfCoins10 -= 1;
                    surrender -= 10;
                }
                else if (coins != null && (coins.NumberOfCoins5 != 0 && surrender >= 5))
                {
                    coins.NumberOfCoins5 -= 1;
                    surrender -= 5;
                }
                else if (coins != null && (coins.NumberOfCoins2 != 0 && surrender >= 2))
                {
                    coins.NumberOfCoins2 -= 1;
                    surrender -= 2;
                }
                else if (coins != null && (coins.NumberOfCoins1 != 0 && surrender >= 1) )
                {
                    coins.NumberOfCoins1 -= 1;
                    surrender -= 1;
                }              
            }
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}