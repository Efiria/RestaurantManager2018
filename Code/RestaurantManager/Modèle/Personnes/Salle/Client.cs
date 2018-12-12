using RestaurantManager.Modèle.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes
{
    public class Client : Personne
    {
        public int Id { get; set; }
        public Caractere Caractere { get; set; }
        public Gouts Gout { get; set; }
        bool Reservation { get; set; } = false;

        public Client()
        {
            
        }

        public override string ToString()
        {
            string nL = Environment.NewLine;
            return "Caractère : " + Caractere + nL + "Gout : " + Gout + nL + "Reservation : " + Reservation + nL;
        }


        public List<string> SelectChoix(string categorie)
        {
            Random rnd = new Random();
            BDDControleur bdd = new BDDControleur();
            List<string> returnList = new List<string>();
            
                var list = bdd.getRecette(categorie);
                int index = rnd.Next(list.Count);
                string choix = list[index];
                returnList.Add(choix);

            return returnList;
        }

    }
}
