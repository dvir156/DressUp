using BeckEnd.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace BackEnd.InMemoryDB
{
    interface DataAccess
    {
        List<Garment<BitmapImage>> getCollection();
        Model3DGroup getGarment(string garName);
    }
}
