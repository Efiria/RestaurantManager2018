using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// Offre des méthodes pour lire et mettre à jour le fichier App.config
    /// </summary>
    public static class SettingsReader
    {
        static SettingsReader ()
        {

        }

        /// <summary>
        /// Lit App.config à la clé passé en paramètre et retourne la valeur correspondante
        /// </summary>
        /// <param name="key">La clé d'App.config à lire</param>
        /// <returns>La valeur correspondant à la clé</returns>
        public static string ReadSettings (string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Erreur lors de la lecture de App.config !\n{0}\n{1}\n{2}", ex.Message, ex.Source, ex.TargetSite));
                return "";
            }
        }

        public static string[,] ReadAllSettings ()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                string[,] keysAndValues = new string[appSettings.AllKeys.Length, 2];
                int i = 0;

                foreach (string appSetting in appSettings)
                {
                    keysAndValues[i, 0] = appSetting;
                    keysAndValues[i, 1] = appSettings[appSetting];
                    i++;
                }

                return keysAndValues;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Erreur lors de la lecture de App.config !\n{0}\n{1}\n{2}", ex.Message, ex.Source, ex.TargetSite));
                return null;
            }
        }

        /// <summary>
        /// Remplace la valeur de la clé passée en paramètre par la valeur passée en paramètre
        /// </summary>
        /// <param name="key">La clé à mettre à jour</param>
        /// <param name="value">La nouvelle valeur de la clé</param>
        public static void UpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                /// Si la clé ne correspond à aucune clé du fichier, on lance une nouvelle exception
                if (settings[key] == null)
                {
                    throw new Exception("Clé non trouvé dans App.config");
                }

                /// Sinon, on remplace la valeur de la clé par la valeur désirée
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Erreur dans l'écriture de App.config !\n{0}\n{1}\n{2}", ex.Message, ex.Source, ex.TargetSite));
            }
        }
    }
}
