using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Modèle.CommandePackage;

namespace RestaurantManager.Modèle.Lieux
{
    public class Table
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Size { get; set; }
        public int IdTable { get; set; }

        public Table(int poxX, int posY, int size)
        {
            this.PosX = poxX;
            this.PosY = posY;
            this.Size = size;
        }

        public override string ToString()
        {
            string nL = Environment.NewLine;
            return "Position X : " + PosX + nL + "Position Y : " + PosY + nL + "Taille : " + Size;
        }

        public Commande CreateCommande(int idClient)
        {
            Commande commande = new Commande(idClient);
            for (int i = 0; i <= NbrPersonne; i++)
            {
                commande.AddEntree(SelectChoix("Entree", NbrPersonne));
            }

            return commande;
        }

    }
}
