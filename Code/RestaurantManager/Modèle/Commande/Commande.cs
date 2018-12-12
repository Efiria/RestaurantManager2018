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

        private List<string> Entree = new List<string>();
        private List<string> Plats = new List<string>();
        private List<string> Desserts = new List<string>();

        public Commande(int idClient)
        {
            IdClient = idClient;
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
                Console.WriteLine("Le Client" + IdClient + " a commande un ou une" + el);
                Entree.Add(el);
            }
            return Entree;
        }
    }
}
