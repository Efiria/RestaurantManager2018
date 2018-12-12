using RestaurantManager.Modèle.Personnes;
using RestaurantManager.Modèle.Personnes.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace RestaurantManager.Modèle.Lieux
{
    public class Salle
    {
        private readonly int TABLE_SIZE = 8;

        public Restaurant Restaurant { get; private set; }

        public Table[][][] Tables { get; private set; }
        public List<Client> Clients { get; private set; } = new List<Client>();
        public List<AEmploye> Employes { get; private set; } = new List<AEmploye>();

        private MaitreDHotel MaitreDHotel { get; set; }

        private static System.Timers.Timer aTimer;
        private readonly Random random = new Random();

        private int CapaciteMax { get; set; }
        private bool PauseEnabled { get; set; }

        private FabriquePersonne fabriquePersonne;
        
        /// <summary>
        /// Génère une nouvelle salle de restaurant
        /// </summary>
        /// <param name="nbrCarre">Le nombre de carrés dans la salle</param>
        /// <param name="nbrRangParCarre">Le nombre de rangs par carré</param>
        /// <param name="nbrTableParRang">Le nombre de tables par rang</param>
        public Salle(Restaurant restaurant, int nbrCarre, int nbrRangParCarre, int nbrTableParRang)
        {
            this.Restaurant = restaurant;

            Tables = new Table[nbrCarre][][];
            for (int i = 0; i < nbrCarre; i++)
            {
                Tables[i] = new Table[nbrRangParCarre][];
                for (int j = 0; j < nbrRangParCarre; j++)
                {
                    Tables[i][j] = new Table[nbrTableParRang];
                    for (int k = 0; k < nbrTableParRang; k++)
                    {
                        Tables[i][j][k] = new Table((i * 9) + ((k + 1) * 4), j * 5, TABLE_SIZE);
                    }
                }
            }
            CapaciteMax = nbrCarre * nbrRangParCarre * nbrTableParRang * 4;

            fabriquePersonne = new FabriquePersonne();

            MaitreDHotel = fabriquePersonne.CreateEmploye(Roles.MaitreDHotel) as MaitreDHotel;
            Employes.Add(MaitreDHotel);


            SetTimer();
        }

        public void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            NewClient();
        }

        /// <summary>
        /// Génère un nouveau groupe de clients
        /// </summary>
        public void NewClient ()
        {
            if (Clients.Count < this.CapaciteMax && !PauseEnabled)
            {
                int placesRestantes = this.CapaciteMax - this.Clients.Count;
                int nbrOfClients = (placesRestantes > 8) ? this.random.Next(1, 8) : this.random.Next(1, placesRestantes);

                List<Client> clients = new List<Client>();

                for (int i = 0; i < nbrOfClients; i++)
                {
                    Client client = fabriquePersonne.CreateClient(Caractere.Presse);
                    client.Id = this.Clients.Count;
                    this.Clients.Add(client);

                    clients.Add(client);
                }
                this.Restaurant.CallConsole(nbrOfClients + " clients sont entrés sur " + CapaciteMax + " (" + this.Clients.Count + "/" + CapaciteMax + ")");
                MaitreDHotel.AssignToTable(this, clients);
                this.Restaurant.CallDisplay();
            }
        }

        public void Pause()
        {
            this.PauseEnabled = !this.PauseEnabled;
        }
    }
}