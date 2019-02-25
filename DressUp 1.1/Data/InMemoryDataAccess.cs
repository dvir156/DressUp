using BackEnd.InMemoryDB;
using BeckEnd.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BeckEnd.Data
{
    class InMemoryDataAccess : DataAccess
    {
        InMemoryDataBase db = InMemoryDataBase.Instance;

        public List<Garment<BitmapImage>> getCollection()
        {
            List<Garment<BitmapImage>> pictureCollection = new List<Garment<BitmapImage>>();


            foreach (Garment<FileStream> pic in db.getCollection())
                pictureCollection.Add(new Garment<BitmapImage>(pic.id, pic.name, streamToBitmapImage(pic.garment)));
            return pictureCollection;
        }

        public BitmapImage getGarment(string garName)
        {
            return streamToBitmapImage(db.getGarment(garName).garment);
        }

        private BitmapImage streamToBitmapImage(FileStream stream)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.StreamSource = stream;
            bi.EndInit();

            return bi;
        }
     
        /*
        public void test()
        {
            Garment<FileStream> picture = new Garment<FileStream>(db.getCollection().Count, "6e7723f4-865a-4bfb-ae87-fe753d11b797.png", new FileStream(@"C:\Users\daniel\Desktop\6e7723f4-865a-4bfb-ae87-fe753d11b797.png", FileMode.Open));
            Console.WriteLine(db.uplodePicture(picture, true));
        }
        */
    }
}
