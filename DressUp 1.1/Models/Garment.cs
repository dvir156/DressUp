using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckEnd.Models
{
    class Garment<StreamType>
    {
        public int id { get; set; }
        public string name { get; set; }
        public StreamType garment { get; set; }

        public Garment(int id, string name, StreamType gar)
        {
            this.id = id;
            this.name = name;
            this.garment = gar;
        }

    }
}
