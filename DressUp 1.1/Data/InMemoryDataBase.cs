
using BeckEnd.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.InMemoryDB
{
    class InMemoryDataBase
    {
        private static InMemoryDataBase db = null;
        public static InMemoryDataBase Instance
        {
            get
            {
                if (db == null)
                    db = new InMemoryDataBase();
                return db;
            }
        }
        private const string containing_folder = @"C:\Users\dvir1\source\repos\DressUp 1.1\DressUp 1.1\DB";
        private List<Garment<FileStream>> collectionPreview = new List<Garment<FileStream>>();
        private Dictionary<string, Garment<FileStream>> collection = new Dictionary<string, Garment<FileStream>>();

        private InMemoryDataBase()
        {
            DirectoryInfo d = new DirectoryInfo(containing_folder + @"\3D");
            FileInfo[] Files = d.GetFiles("*");
            foreach (FileInfo file in Files)
                collection.Add(file.Name, new Garment<FileStream>(collection.Count(), file.Name, File.Open(containing_folder + @"\3D\" + file.Name, FileMode.Open)));

            d = new DirectoryInfo(containing_folder + @"\2D");
            Files = d.GetFiles("*");
            foreach (FileInfo file in Files)
                collectionPreview.Add(new Garment<FileStream>(collection.Count(), file.Name, File.Open(containing_folder + @"\2D\" + file.Name, FileMode.Open)));
        }

        public List<Garment<FileStream>> getCollection()
        {
            return collectionPreview;
        }

        public Garment<FileStream> getGarment(string name)
        {
            return collection[name];
        }
        /*
        public string uplodePicture(Garment<FileStream> file,bool size)
        {
            FileStream fs;
            if (size)
                fs = File.Create(path + @"\3DModels\"+file.name);
            else
                fs = File.Create(path + @"\PreviewModel\" + file.name);
            StreamReader sr = new StreamReader(file.garStream);
            StreamWriter sw = new StreamWriter(fs);
            string data = sr.ReadToEnd();
            sw.Write(data, 0, data.Length); 
            return "uplodePicture";
        }
        */
    }
}
