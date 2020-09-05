using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsBomber
{
    public partial class FormWarPlaneConfig : Form
    {
        ITransport warPlane = null;

        /// <summary>
        /// Событие
        /// </summary>
        private event warPlaneDelegate eventAddWarPlane;

        public FormWarPlaneConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelGold.MouseDown += panelColor_MouseDown;
            panelGray.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        /// <summary>
        /// Отрисовать военный самолет
        /// </summary>
        private void DrawWarPlane()
        {
            if (warPlane != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                Graphics gr = Graphics.FromImage(bmp);
                warPlane.SetPosition(5, 5, pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                warPlane.DrawWarPlane(gr);
                pictureBoxWarPlane.Image = bmp;
            }
        }

        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(warPlaneDelegate ev)
        {
            if (eventAddWarPlane == null)
                eventAddWarPlane = new warPlaneDelegate(ev);
            else
                eventAddWarPlane += ev;
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelWarPlane_MouseDown(object sender, MouseEventArgs e)
        {
            labelWarPlane.DoDragDrop(labelWarPlane.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBomber_MouseDown(object sender, MouseEventArgs e)
        {
            labelBomber.DoDragDrop(labelBomber.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelWarPlane_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelWarPlane_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Военный самолет":
                    warPlane = new WarPlane(100, 500, Color.White);
                    break;
                case "Бомбардировщик":
                    warPlane = new Bomber(100, 500, Color.White, Color.Black, true, true, true);
                    break;
            }
            DrawWarPlane();
        }

        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            if (warPlane != null)
            {
                warPlane.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawWarPlane();
            }
        }

        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (warPlane != null)
                if (warPlane is Bomber)
                {
                    (warPlane as Bomber).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawWarPlane();
                }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddWarPlane?.Invoke(warPlane);
            Close();
        }
    }
}