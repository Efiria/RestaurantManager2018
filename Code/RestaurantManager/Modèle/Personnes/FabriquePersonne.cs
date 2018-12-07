using RestaurantManager.Modèle.Personnes.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes
{
    public class FabriquePersonne
    {
        Object[] var = { "test", } ; 


        public Personne CreatePersonne(TypeP type, Roles role, Object[] args)
        {
            if (type == TypeP.Client)
            {
                Client client = new Client();

                return client;

            }
            else if (type == TypeP.Employe)
            {
                switch (role)
                {
                    case Roles.ChefDeCuisine:
                        break;
                }
            }

            return null;
        }
        
    }
}
