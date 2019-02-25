using BeckEnd.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BackEnd.InMemoryDB
{
    interface DataAccess
    {
        List<Garment<BitmapImage>> getCollection();
        BitmapImage getGarment(string garName);
    }
}
