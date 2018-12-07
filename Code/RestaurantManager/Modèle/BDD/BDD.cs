using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace RestaurantManager.Modèle.BDD
{
    public class BDD : IBDD
    {
        /// <summary>
        /// Get Recette de la base de données
        /// </summary>
        public void getRecette()
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Recette", connexion);

                try
                {
                    connexion.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Recupération des valeurs a ensuite stocker dans des variables
                        //0 = ID | 1 = Nom etc...
                        Console.Write(reader[1]);
                        Console.WriteLine(reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Recupere les clients qui ont reserver une table
        /// </summary>
        public void getReservation()
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.ReservationTable", connexion);

                try
                {
                    connexion.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Recupération des valeurs a ensuite stocker dans des variables
                        //0 = ID | 1 = Nom etc...
                        Console.Write(reader[1]);
                        Console.Write(" " + reader[2] + " ");
                        Console.WriteLine(reader[3]);

                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Creer une reservation pour un client
        /// </summary>
        public void setReservation(string Nom, int nbPersonne, int heure)
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO dbo.ReservationTable (NomReservation,NbPersonne,Horaire) " +
                    "VALUES (@nomClient,@nombre,@horaire)", connexion);

                try
                {
                    command.Parameters.Add("@nomClient", SqlDbType.VarChar, 30).Value = Nom;
                    command.Parameters.Add("@nombre", SqlDbType.Int).Value = nbPersonne;
                    command.Parameters.Add("@horaire", SqlDbType.Int).Value = heure;

                    connexion.Open();
                    command.ExecuteNonQuery();
                    connexion.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Met a jour le stock de produits en fonction des commandes
        /// </summary>
        /// <param name="recette">Recette commander</param>
        /// <param name="quantite">Nombre de la recette commander</param>
        public void updateStock(string recette, int quantite = 1)
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                Dictionary<string, int> valeur = new Dictionary<string, int>();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.IngredientRecette WHERE NomRecette = @Nom", connexion);
                command.Parameters.AddWithValue("@Nom", recette);

                connexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    valeur.Add(reader[2].ToString(), (int)reader[3] * quantite);
                }
                reader.Close();

                foreach (var item in valeur)
                {
                    SqlCommand commandUpdate = new SqlCommand("UPDATE StockIngredients SET Stock = Stock - @vStock WHERE Nom = @NomIngredient", connexion);
                    commandUpdate.Parameters.AddWithValue("@vStock", item.Value);
                    commandUpdate.Parameters.AddWithValue("@NomIngredient", item.Key);
                    commandUpdate.ExecuteNonQuery();
                }
                connexion.Close();
            }
        }
    }
}
