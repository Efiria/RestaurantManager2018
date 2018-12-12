using RestaurantManager.Modèle.Lieux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.CommandePackage
{
    public class Commande
    {
        private int IdClient { get; set; }
        private int Etat { get; set; }
        public Salle Salle { get; private set; }
        private List<string> Entree = new List<string>();
        private List<string> Plats = new List<string>();
        private List<string> Desserts = new List<string>();

        public Commande(int idClient, Salle salle)
        {
            IdClient = idClient;
            Salle = salle;
            Etat = 1;
        }

        public int IncrementEtat()
        {
            Etat++;
            return Etat;
        }

        public List<string> AddEntree(List<string> recette)
        {
            foreach (string el in recette)
            {
                this.Salle.Restaurant.CallConsole
                Console.WriteLine("Le Client" + IdClient + " a commande un ou une" + el);
                Entree.Add(el);
            }
            return Entree;
        }

        public List<string> AddPlats(List<string> recette)
        {
            foreach (string el in recette)
            {
                Console.WriteLine("Le Client" + IdClient + " a commande un ou une" + el);
                
                Plats.Add(el);
            }
            return Plats;
        }

        public List<string> AddDessert(List<string> recette)
        {
            foreach (string el in recette)
            {
                Console.WriteLine("Le Client" + IdClient + " a commande un ou une" + el);
                Desserts.Add(el);
            }
            return Desserts;
        }
    }
}
