using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsBomber
{
    public partial class FormWarPlane : Form
    {
        private ITransport warTransport;

        public FormWarPlane()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
            Graphics gr = Graphics.FromImage(bmp);
            warTransport.DrawWarPlane(gr);
            pictureBoxWarPlane.Image = bmp;
        }

        private void ButtonCreateWarPlane_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            warTransport = new WarPlane(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Green);
            warTransport.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
            Draw();
        }

        private void ButtonCreateBomber_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            warTransport = new Bomber(rnd.Next(100, 300), rnd.Next(100, 300), Color.Green, Color.Yellow, true, true, true);
            warTransport.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
            Draw();
        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    warTransport.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    warTransport.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    warTransport.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    warTransport.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
