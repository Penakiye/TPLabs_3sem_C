using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsBomber
{
    public partial class FormHangar : Form
    {
        /// <summary>
        /// Объект от класса-ангара
        /// </summary>
        Hangar<ITransport> hangar;

        public FormHangar()
        {
            InitializeComponent();
            hangar = new Hangar<ITransport>(20, pictureBoxHangar.Width, pictureBoxHangar.Height);
            Draw();
        }

        /// <summary>
        /// Метод отрисовки ангара
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxHangar.Width, pictureBoxHangar.Height);
            Graphics gr = Graphics.FromImage(bmp);
            hangar.Draw(gr);
            pictureBoxHangar.Image = bmp;
        }

        /// <summary>
        /// Обработка нажатия кнопки "Посадить военный самолет"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetWarPlane_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var warPlane = new WarPlane(100, 1000, dialog.Color);
                int place = hangar + warPlane;
                Draw();
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Посадить бомбардировщик"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetBomber_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var bomber = new Bomber(100, 1000, dialog.Color, dialogDop.Color, true, true, true);
                    int place = hangar + bomber;
                    Draw();
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGetWarPlane_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxPlace.Text != "")
            {
                var warPlane = hangar - Convert.ToInt32(maskedTextBoxPlace.Text);
                if (warPlane != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    warPlane.SetPosition(5, 5, pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                    warPlane.DrawWarPlane(gr);
                    pictureBoxWarPlane.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                    pictureBoxWarPlane.Image = bmp;
                }
                Draw();
            }
        }
    }
}
