using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}