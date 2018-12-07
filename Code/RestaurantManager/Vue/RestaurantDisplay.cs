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

        public RestaurantDisplay()
        {
            InitializeComponent();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            PictureBox pictureBox = new PictureBox
            {
                Image = Properties.Resources.MaitreDHotel,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            pictureBox.Height = pictureBox.Width = SPRITE_SIZE;
            
            this.panel1.Controls.Add(pictureBox);

            Object[,] args = new Object[10, 10];

            args[1, 3] = new Table(2);
            args[1, 5] = new Table(6);
            args[5, 3] = new Table(10);
            Display(args);
        }

        public void Display(Object[,] map)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i,j] != null)
                    {
                        if (map[i, j] is Table)
                        {
                            DisplayTable(map[i, j] as Table, i, j);
                        }
                        //else if (map[i, j] is Personne)
                        //{
                        //    DisplayPerson(map[i, j] as Personne, i, j);
                        //}
                    }
                }
            }
        }

        private void DisplayTable(Table table, int x, int y)
        {
            Bitmap flippedChair = new Bitmap(Properties.Resources.Chaise);
            flippedChair.RotateFlip(RotateFlipType.RotateNoneFlipX);

            for (int i = 0; i < (table.Size / 2); i++)
            {
                CreatePictureBox(Properties.Resources.Chaise, x - 1, y + i);
                CreatePictureBox(Properties.Resources.Table, x, y + i);
                Properties.Resources.Chaise.RotateFlip(RotateFlipType.RotateNoneFlipX);
                CreatePictureBox(flippedChair, x + 1, y + i);
            }
        }

        //private void DisplayPerson(Personne personne, int x, int y)
        //{
            
        //}

        private void CreatePictureBox(Bitmap bitmap, int x, int y)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = bitmap,
                Location = new Point(x * SPRITE_SIZE, y * SPRITE_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pictureBox.Height = pictureBox.Width = SPRITE_SIZE;
            this.panel1.Controls.Add(pictureBox);
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            Form formConfig = ConfigDisplay.Instance();
            formConfig.Show();
            formConfig.FormClosed += (Object s, FormClosedEventArgs f) => SPRITE_SIZE = Int32.Parse(SettingsReader.ReadSettings("SpriteSize"));
        }
    }
}
