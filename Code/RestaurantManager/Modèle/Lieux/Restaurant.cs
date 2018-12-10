using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using RestaurantManager.Vue;

namespace RestaurantManager.Modèle.Lieux
{
    public class Restaurant
    {
        private static Restaurant _instance;
        static readonly object instanceLock = new object();

        public delegate void DisplayEventHandler(Restaurant restaurantSrc);
        public static event DisplayEventHandler Observable;

        public Salle Salle { get; private set; }
        public Cuisine Cuisine { get; private set; }
        
        private Restaurant(RestaurantDisplay restaurantDisplay)
        {
            Observable += new DisplayEventHandler(restaurantDisplay.Display);
            Salle = new Salle(
                int.Parse(SettingsReader.ReadSettings("nbrCarreParSalle")),
                int.Parse(SettingsReader.ReadSettings("nbrRangParCarre"))
                );
            
            if (Observable != null)
            {
                Observable(this);
            }
        }

        public static Restaurant Instance(RestaurantDisplay restaurantDisplay)
        {
            if (_instance == null)
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Restaurant(restaurantDisplay);
                    }
                }
            }
            return _instance;
        }
    }
}
