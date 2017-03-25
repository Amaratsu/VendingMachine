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
    }
}