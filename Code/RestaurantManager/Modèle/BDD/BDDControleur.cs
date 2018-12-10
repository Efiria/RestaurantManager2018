using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Modèle.BDD;

namespace RestaurantManager.Modèle.BDD
{
    class BDDControleur
    {
        IBDD Bdd = new BDD();
        
        public void getReservation()
        {
            Bdd.getReservation();
        }

        public void setReservation(string Nom, int nbPersonne, int Heure)
        {
            Bdd.setReservation(Nom, nbPersonne, Heure);
        }

        public void updateStock(string recette, int quantite = 1)
        {
            Bdd.updateStock(recette, quantite);
        }

        public void getRecette()
        {
            Bdd.getRecette();
        }

        public void reStock(string Recette)
        {
            Bdd.reStock(Recette);
        }

    }
}
