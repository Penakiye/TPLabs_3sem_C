using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsBomber
{
    public partial class FormBomber : Form
    {
        private Bomber bomber;
        public FormBomber()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод отрисовки бомбардировщика
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBomber.Width, pictureBoxBomber.Height);
            Graphics gr = Graphics.FromImage(bmp);
            bomber.DrawBomber(gr);
            pictureBoxBomber.Image = bmp;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bomber = new Bomber(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Green, Color.Brown, true, true, true);
            bomber.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBomber.Width, pictureBoxBomber.Height);
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    bomber.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    bomber.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    bomber.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    bomber.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
