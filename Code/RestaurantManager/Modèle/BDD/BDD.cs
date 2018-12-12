﻿using System;
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
        public List<string> getRecette(string categorie)
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";
            List<string> recettes = new List<string>();

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Recette WHERE Categorie = @Cate", connexion);
                command.Parameters.AddWithValue("@Cate", categorie);

                try
                {
                    connexion.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Recupération des valeurs a ensuite stocker dans des variables
                        //0 = ID | 1 = Nom etc...
                        recettes.Add((string)reader[1]);
                        //Console.WriteLine(reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return recettes;
        }

        /// <summary>
        /// Renvoi le prix d'une recette en int
        /// </summary>
        /// <param name="recette">Nom d'une recette ou l'on veut le prix</param>
        /// <returns>Renvoi le prix d'une recette en int</returns>
        public int getPrice(string recette)
        {
            int prix = 0;

            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Prix FROM dbo.Recette WHERE Nom = @NomRecette", connexion);

                try
                {
                    connexion.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        prix = (int)reader[0];
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return prix;
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
                    commandUpdate.Parameters.AddWithValue("@NomIngredient", item.Key);
                    commandUpdate.Parameters.AddWithValue("@vStock", item.Value);

                    commandUpdate.ExecuteNonQuery();
                }
                connexion.Close();
            }
        }

        /// <summary>
        /// Commande des ingredients pour avoir 50 ingredients dans le stock
        /// </summary>
        public void reStock()
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                Dictionary<string, int> valeur = new Dictionary<string, int>();
                int valeurStock = 40;

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.StockIngredients WHERE Stock < @valeur", connexion);
                command.Parameters.AddWithValue("@valeur", valeurStock);


                connexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    valeur.Add(reader[1].ToString(), (int)reader[2]);
                }
                reader.Close();

                foreach (var item in valeur)
                {
                    SqlCommand commandUpdate = new SqlCommand("UPDATE StockIngredients SET Stock = Stock + @vStock WHERE Nom = @NomIngredient", connexion);
                    commandUpdate.Parameters.AddWithValue("@vStock", valeurStock - item.Value);
                    commandUpdate.Parameters.AddWithValue("@NomIngredient", item.Key);
                    commandUpdate.ExecuteNonQuery();
                }
                connexion.Close();
            }
        }

        /// <summary>
        /// Recupere les etapes lors de la preparation d'une recette
        /// </summary>
        /// <param name="Recette">Recette ou l'on veut avoir les etapes</param>
        public List<string> getEtape(string Recette)
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.EtapeRecette WHERE NomRecette = @Recette ORDER BY NbEtape DESC", connexion);
                command.Parameters.AddWithValue("@Recette", Recette);

                List<string> Etape = new List<string>();

                try
                {
                    connexion.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Recupération des valeurs a ensuite stocker dans des variables
                        //0 = ID | 1 = Nom etc...
                        Console.Write(reader[1]);

                        Etape.Add(reader[3].ToString());

                        Console.Write(reader[3]);
                        Console.WriteLine(reader[4]);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return Etape;
            }
        }

        /// <summary>
        /// Sauvegarde une commande dans la table de comptabilité 
        /// </summary>
        /// <param name="recette">Recette a ajouter</param>
        public void setCompta(string recette)
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("SELECT NomRecette FROM dbo.ComptaCommande WHERE NomRecette = @Nom", connexion);
                command.Parameters.AddWithValue("@Nom", recette);

                connexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();

                    SqlCommand commandUpdate = new SqlCommand("UPDATE ComptaCommande SET Quantite = Quantite + 1 WHERE NomRecette = @nomRecette", connexion);
                    commandUpdate.Parameters.Add("@nomRecette", SqlDbType.VarChar, 50).Value = recette;
                    commandUpdate.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();

                    SqlCommand commandInsert = new SqlCommand("INSERT INTO dbo.ComptaCommande (NomRecette) VALUES (@nomRecette)", connexion);
                    commandInsert.Parameters.Add("@nomRecette", SqlDbType.VarChar, 50).Value = recette;
                    commandInsert.ExecuteNonQuery();
                }
                connexion.Close();
            }
        }

        public int getMoney()
        {
            int Money = 0;
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.ComptaCommande", connexion);

                try
                {
                    connexion.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.Write(reader[1]);

                        Money = Money + (int)reader[0];

                        Console.Write(reader[3]);
                        Console.WriteLine(reader[4]);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return Money;
        }

        public void clearCompta()
        {
            string connectionString = "Data Source=(local);Initial Catalog=RestaurantManagerBDD;Integrated Security=true";

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.ComptaCommande", connexion);

                try
                {
                    connexion.Open();
                    command.ExecuteReader();
                    connexion.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}
