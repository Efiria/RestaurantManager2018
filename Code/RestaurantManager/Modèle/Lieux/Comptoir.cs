using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Lieux
{
    public class Comptoir
    {
        private static Comptoir _instance;
        static readonly object instanceLock = new object();

        private Comptoir()
        {

        }

        public static Comptoir Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Comptoir();
                        }
                    }
                }
                return _instance;
            }
        }

        void ComptoirCommandePrete()
        {
            Dictionary<string, int> valeur = new Dictionary<string, int>();
            foreach (var item in valeur)
            {
                //item.Key = string
                // item.Value = int

            }
        }
            void comparaison()
            {
                while (commande != comptoir)
                {

                }
            }
        }
    }

