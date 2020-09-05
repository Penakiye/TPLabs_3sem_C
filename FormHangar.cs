using NLog;
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
        /// Форма для добавления
        /// </summary>
        FormWarPlaneConfig form;
        /// <summary>
        /// Количество уровней-ангаров
        /// </summary>
        private const int countLevel = 5;
        /// <summary>
        /// Логгер
        /// </summary>
        private Logger logger;

        public FormHangar()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
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
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGetWarPlane_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
                if (maskedTextBoxPlace.Text != "")
                {
                    try
                    {
                        var warPlane = hangar[listBoxLevels.SelectedIndex] - Convert.ToInt32(maskedTextBoxPlace.Text);
                        Bitmap bmp = new Bitmap(pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        warPlane.SetPosition(5, 5, pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                        warPlane.DrawWarPlane(gr);
                        pictureBoxWarPlane.Image = bmp;
                        logger.Info("Изъят самолет: " + warPlane.ToString() + " с места" + maskedTextBoxPlace.Text);
                        Draw();
                    }
                    catch (HangarNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        logger.Error(ex.Message);
                        Bitmap bmp = new Bitmap(pictureBoxWarPlane.Width, pictureBoxWarPlane.Height);
                        pictureBoxWarPlane.Image = bmp;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Неизвестная ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error(ex.Message);
                    }
                }
        }

        private void listBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Посадить военный самолет"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetWarPlane_Click(object sender, EventArgs e)
        {
            form = new FormWarPlaneConfig();
            form.AddEvent(AddWarPlane);
            form.Show();
        }

        /// <summary>
        /// Метод добавления самолета
        /// </summary>
        /// <param name="warPlane"></param>
        private void AddWarPlane(ITransport warPlane)
        {
            if (warPlane != null && listBoxLevels.SelectedIndex > -1)
            {
                try
                {
                    int place = hangar[listBoxLevels.SelectedIndex] + warPlane;
                    logger.Info("Добавлен самолет " + warPlane.ToString() + " на место " + place);
                    Draw();
                }
                catch (HangarOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                catch (HangarAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    hangar.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    hangar.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                }
                catch (HangarOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                Draw();
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Сортировка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            hangar.Sort();
            Draw();
            logger.Info("Сортировка уровней");
        }
    }
}