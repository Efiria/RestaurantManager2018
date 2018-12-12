using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManager.Modèle.BDD;

namespace RestaurantManager
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*BDDControleur controleur = new BDDControleur();
            controleur.setCompta("Burger Vegan");
            //controleur.clearCompta();*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Vue.RestaurantDisplay());

        }
    }
}
