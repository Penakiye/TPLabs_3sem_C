using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsBomber
{
    public partial class FormHangar : Form
    {
        /// <summary>
        /// Объект от класса многоуровневого ангара
        /// </summary>
        MultiLevelHangar hangar;
        /// <summary>
        /// Количество уровней-ангаров
        /// </summary>
        private const int countLevel = 5;

        public FormHangar()
        {
            InitializeComponent();
            hangar = new MultiLevelHangar(countLevel, pictureBoxHangar.Width, pictureBoxHangar.Height);
            //заполнение listBox
            for (int i = 0; i < countLevel; i++)
                listBoxLevels.Items.Add("Уровень " + (i + 1));
            listBoxLevels.SelectedIndex = 0;
        }

        /// <summary>
        /// Метод отрисовки ангара
        /// </summary>
        private void Draw()
        {
            if (listBoxLevels.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox 
                Bitmap bmp = new Bitmap(pictureBoxHangar.Width, pictureBoxHangar.Height);
                Graphics gr = Graphics.FromImage(bmp);
                hangar[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBoxHangar.Image = bmp;
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Посадить военный самолет"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetWarPlane_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var warPlane = new WarPlane(100, 1000, dialog.Color);
                    int place = hangar[listBoxLevels.SelectedIndex] + warPlane;
                    if (place == -1)
                        MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Draw();
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Посадить бомбардировщик"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetBomber_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var bomber = new Bomber(100, 1000, dialog.Color, dialogDop.Color, true, true, true);
                        int place = hangar[listBoxLevels.SelectedIndex] + bomber;
                        if (place == -1)
                            MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Draw();
                    }
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
            if (listBoxLevels.SelectedIndex > -1)
            {
                if (maskedTextBoxPlace.Text != "")
                {
                    var warPlane = hangar[listBoxLevels.SelectedIndex] - Convert.ToInt32(maskedTextBoxPlace.Text);
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

        private void listBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
