using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Lieux
{
    public class Salle
    {
        public Table[][][] Tables { get; private set; }

        public Salle(int nbrCarre, int nbrRangParCarre)
        {
            Tables = new Table[nbrCarre][][];
            for (int i = 0; i < nbrCarre; i++)
            {
                Tables[i] = new Table[nbrRangParCarre][];
                for (int j = 0; j < nbrRangParCarre; j++)
                {
                    Tables[i][j] = new Table[4];
                    for (int k = 0; k < 4; k++)
                    {
                        Tables[i][j][k] = new Table((i * 17) + ((k + 1) * 4), j * 5, 8);
                    }
                }
            }
        }
    }
}
