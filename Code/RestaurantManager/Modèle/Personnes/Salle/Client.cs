using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes
{
    public class Client : Personne
    {
        public string Nom { get; set; }
        public Caractere Caractere { get; set; }
        public Gouts Gout { get; set; }
        bool Reservation { get; set; } = false;

        public Client()
        {
            
        }
    }
}
