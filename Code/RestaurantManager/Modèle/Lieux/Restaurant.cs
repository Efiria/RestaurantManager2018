using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Vue;

namespace RestaurantManager.Modèle.Lieux
{
    public class Restaurant
    {
        private static Restaurant _instance;
        static readonly object instanceLock = new object();
        
        private Restaurant()
        {

        }

        public static Restaurant Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Restaurant();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
