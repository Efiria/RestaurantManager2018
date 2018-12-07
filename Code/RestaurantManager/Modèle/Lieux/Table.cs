using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Lieux
{
    public class Table
    {
        int PosX { get; set; }
        int PosY { get; set; }
        public int Size { get; set; }

        public Table(int size)
        {
            this.Size = size;
        }

    }
}
