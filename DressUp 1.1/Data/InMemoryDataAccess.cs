using BackEnd.InMemoryDB;
using BeckEnd.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckEnd.Data
{
    //class InMemoryDataAccess : DataAccess
    //{
    //    InMemoryDataBase db = InMemoryDataBase.Instance;

    //    public List<Garment<Bitmap>> getCollection()
    //    {
    //        List<Garment<Bitmap>> pictureCollection = new List<Garment<Bitmap>>();
    //        foreach (Garment<FileStream> pic in db.getCollection())
    //            pictureCollection.Add(new Garment<Bitmap>(pic.id, pic.name, new Bitmap(pic.garStream)));
    //        return pictureCollection;
    //    }

    //    public Bitmap getGarment(string garName)
    //    {
    //        return new Bitmap(db.getGarment(garName).garStream);
    //    }
    //    /*
    //    public void test()
    //    {
    //        Garment<FileStream> picture = new Garment<FileStream>(db.getCollection().Count, "6e7723f4-865a-4bfb-ae87-fe753d11b797.png", new FileStream(@"C:\Users\daniel\Desktop\6e7723f4-865a-4bfb-ae87-fe753d11b797.png", FileMode.Open));
    //        Console.WriteLine(db.uplodePicture(picture, true));
    //    }
    //    */
    //}
}
