using BackEnd.InMemoryDB;
using BeckEnd.Models;
using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

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

        public Model3DGroup getGarment(string garName)
        {
            return streamToModel3DGroup(db.getGarment(garName).garment);
        }

        private Model3DGroup streamToModel3DGroup(FileStream stream)
        {
            return new ObjReader().Read(stream);
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
