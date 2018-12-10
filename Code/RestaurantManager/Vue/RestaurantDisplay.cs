using RestaurantManager.Modèle.Lieux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace RestaurantManager.Vue
{
    public partial class RestaurantDisplay : Form
    {
        private int SPRITE_SIZE = Int32.Parse(SettingsReader.ReadSettings("SpriteSize"));
        private Restaurant restaurant;

        public RestaurantDisplay()
        {
            InitializeComponent();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            this.ConsoleLog("====================" + Environment.NewLine + "Début de la simulation" + Environment.NewLine + "====================" + Environment.NewLine);
            restaurant = Restaurant.Instance(this);
        }

        public void Display(Restaurant restaurant)
        {
            foreach (Table[][] carres in restaurant.Salle.Tables)
            {
                foreach (Table[] rangs in carres)
                {
                    foreach (Table table in rangs)
                    {
                        DisplayTable(table);
                    }
                }
            }
        }

        private void DisplayTable(Table table)
        {
            int x = table.PosX;
            int y = table.PosY;

            Bitmap flippedChair = new Bitmap(Properties.Resources.Chaise);
            flippedChair.RotateFlip(RotateFlipType.RotateNoneFlipX);

            for (int i = 0; i < (table.Size / 2); i++)
            {
                CreatePictureBox(Properties.Resources.Chaise, x - 1, y + i, null);
                CreatePictureBox(Properties.Resources.Table, x, y + i, table.ToString());
                Properties.Resources.Chaise.RotateFlip(RotateFlipType.RotateNoneFlipX);
                CreatePictureBox(flippedChair, x + 1, y + i, null);
            }
        }

        //private void DisplayPerson(Personne personne, int x, int y)
        //{
            
        //}

        private void CreatePictureBox(Bitmap bitmap, int x, int y, string onClickMsg)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = bitmap,
                Location = new Point(x * SPRITE_SIZE, y * SPRITE_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Height = SPRITE_SIZE,
                Width = SPRITE_SIZE
            };

            if (onClickMsg != null)
                pictureBox.Click += (Object s, EventArgs eventArgs) => InspectionLog(onClickMsg);

            this.panel1.Controls.Add(pictureBox);
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            Form formConfig = ConfigDisplay.Instance();
            formConfig.Show();
            formConfig.FormClosed += (Object s, FormClosedEventArgs f) => SPRITE_SIZE = Int32.Parse(SettingsReader.ReadSettings("SpriteSize"));
        }

        private void InspectionLog (string msg)
        {
            this.txtBox_Inspection.Text = "INSPECTION :\n" + msg + "\n";
        }

        private void ConsoleLog (string msg)
        {
            this.txtBox_Console.AppendText(msg);
        }
    }
}
