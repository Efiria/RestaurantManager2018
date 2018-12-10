using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes
{
    public abstract class AClient
    {
        public string Nom { get; set; }
        public Caractere Caractere { get; set; }
        public Gouts Gout { get; set; }
        bool Reservation { get; set; } = false;


    }
}
