﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.BDD
{
    public interface IBDD
    {
        void getRecette();
        void getReservation();

        void setReservation(string Nom, int nbPersonne, int heure);
    }
}
