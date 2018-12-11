using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes.Salle
{
    class Serveur : AEmploye
    {
        public void PainEau()
        {
            Console.WriteLine("Le serveur apporte le pain et l'eau au client");
        }

        public void LivraisonCommandes()
        {
            Console.WriteLine("Le serveur apportes les commandes");
        }

        public void EnleverAssiettes()
        {
            Console.WriteLine("Le serveur débrasse les assiettes");
        }
    }
}
