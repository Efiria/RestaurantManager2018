using RestaurantManager.Modèle.Personnes.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes
{
    class FabriquePersonne
    {
        public enum TypeP
        {
            Client,
            Employe
        }

        public enum CaracteresClient
        {
            Lent,
            Presse
        }

        public enum RolesEmployes
        {
            MaitreDHotel,
            ChefDeRang,
            Serveur,
            CommisDeSalle,
            ChefDeCuisine,
            Cuisinier,
            CommisDeCuisine,
            Plongeur
        }


        public Personne Create(TypeP type, string[] args)
        {
            if (type == TypeP.Client)
            {
                Client client = new Client(args);

            }
        }
    }
}
