using System;
using System.Data.SqlClient;


namespace RestaurantManager.Modèle.BDD
{
    public class BDD
    {

        /// <summary>
        /// Get Recette de la base de données
        /// </summary>
        public static void getRecette()
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
    }
}
