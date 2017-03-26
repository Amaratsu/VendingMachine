using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    public class AdminController : Controller
    {
        private BeverageContext db = new BeverageContext();
        // Beverages
        [HttpGet]
        public ViewResult BeveragesIndex()
        {
            return View(db.Beverages);
        }

        [HttpGet]
        public ViewResult EditBeverage(int id)
        {
            Beverage beverage = db.Beverages
                .FirstOrDefault(b => b.Id == id);
            return View(beverage);
        }

        [HttpPost]
        public ActionResult EditBeverage(Beverage beverage, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    beverage.ImageMimeType = image.ContentType;
                    beverage.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(beverage.ImageData, 0, image.ContentLength);
                }
                if (beverage.Id == 0)
                {
                    db.Entry(beverage).State = EntityState.Added;
                    db.SaveChanges();
                    return RedirectToAction("BeveragesIndex");
                }
                db.Entry(beverage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BeveragesIndex");
            }
            else
            {
                return View(beverage);
            }
        }

        public ViewResult CreateBeverage()
        {
            return View("EditBeverage", new Beverage());
        }

        [HttpGet]
        public ActionResult DeleteBeverage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }           
            Beverage beverage = db.Beverages.Find(id);
            if (beverage == null)
            {
                return HttpNotFound();
            }
            return View(beverage);
        }

        [HttpPost, ActionName("DeleteBeverage")]
        public ActionResult DeleteBeverageConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Beverage beverage = db.Beverages.Find(id);
            if (beverage == null)
            {
                return HttpNotFound();
            }
            db.Beverages.Remove(beverage);
            db.SaveChanges();
            return RedirectToAction("BeveragesIndex");
        }

        //Coins
        [HttpGet]
        public ViewResult CoinsIndex()
        {
            return View(db.Coins);
        }

        [HttpGet]
        public ViewResult EditCoin(int id)
        {
            Coin coin = db.Coins
                .FirstOrDefault(c => c.Id == id);
            return View(coin);
        }

        [HttpPost]
        public ActionResult EditCoin(Coin coin)
        {
            if (ModelState.IsValid)
            {
                if (coin.Id <= 0)
                {
                    return HttpNotFound();
                }
                db.Entry(coin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CoinsIndex");
            }
            else
            {
                return View(coin);
            }
        }
    }
}