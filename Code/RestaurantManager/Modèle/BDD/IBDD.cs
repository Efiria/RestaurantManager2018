﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.BDD
{
    public interface IBDD
    {
        List<string> getRecette();
        void getReservation();
        void setReservation(string Nom, int nbPersonne, int heure);
        void updateStock(string recette, int quantite = 1);
        void reStock();
        void getEtape(string Recette);
    }
}
