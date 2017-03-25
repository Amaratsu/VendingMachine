using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class BeverageDbInitializer : DropCreateDatabaseAlways<BeverageContext>
    {
        private string _pathToFolderWithImages;

        public BeverageDbInitializer(string pathToFolderWithImages) : base()
        {
            _pathToFolderWithImages = pathToFolderWithImages;
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }

        protected override void Seed(BeverageContext db)
        {
            db.Beverages.Add(new Beverage
            {
                Name = "Спрайт",
                Price = 3,
                ImageData = GetFile(Path.Combine(_pathToFolderWithImages, "sprite.png")),
                ImageMimeType = "png",
                Amount = 5
            });
            db.Beverages.Add(new Beverage
            {
                Name = "Кока-кола",
                Price = 4,
                ImageData = GetFile(Path.Combine(_pathToFolderWithImages, "coca-cola.png")),
                ImageMimeType = "png",
                Amount = 7
            });
            db.Beverages.Add(new Beverage
            {
                Name = "Пепси",
                Price = 5,
                ImageData = GetFile(Path.Combine(_pathToFolderWithImages, "pepsi.png")),
                ImageMimeType = "png",
                Amount = 0
            });

            db.Coins.Add(new Coin
            {
                Id = 1,
                NumberOfCoins1 = 15,
                NumberOfCoins2 = 7,
                NumberOfCoins5 = 8,
                NumberOfCoins10 = 4
            });
            base.Seed(db);
        }
    }
}