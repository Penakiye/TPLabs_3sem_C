using System;
using System.Drawing;

namespace WindowsFormsBomber
{
    public class WarPlane : AirTransport
    {
        protected const int warPlaneWidth = 100;
        protected const int warPlaneHeight = 80;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес военного самолета</param>
        /// <param name="mainColor">Основной цвет</param>
        public WarPlane(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public WarPlane(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }
        public override void DrawWarPlane(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(MainColor);
            // двигатели
            g.DrawEllipse(pen, _startPosX + 60, _startPosY + 10, 10, 10);
            g.DrawEllipse(pen, _startPosX + 60, _startPosY + 50, 10, 10);
            g.DrawRectangle(pen, _startPosX + 54, _startPosY + 9, 12, 12);
            g.DrawRectangle(pen, _startPosX + 54, _startPosY + 49, 12, 12);
            g.FillEllipse(br, _startPosX + 60, _startPosY + 10, 10, 10);
            g.FillEllipse(br, _startPosX + 60, _startPosY + 50, 10, 10);
            g.FillRectangle(br, _startPosX + 55, _startPosY + 10, 10, 12);
            g.FillRectangle(br, _startPosX + 55, _startPosY + 50, 10, 12);
            g.DrawLine(pen, _startPosX + 70, _startPosY + 10, _startPosX + 70, _startPosY + 20);
            g.DrawLine(pen, _startPosX + 70, _startPosY + 50, _startPosX + 70, _startPosY + 60);
            // корпус
            g.FillEllipse(br, _startPosX + 20, _startPosY + 30, 70, 10);
            g.FillRectangle(br, _startPosX + 20, _startPosY + 30, 70, 10);
            g.DrawRectangle(pen, _startPosX + 20, _startPosY + 30, 70, 10);
            //крылья
            g.FillRectangle(br, _startPosX + 40, _startPosY, 20, 70);
            g.DrawRectangle(pen, _startPosX + 40, _startPosY, 20, 30);
            g.DrawRectangle(pen, _startPosX + 40, _startPosY + 40, 20, 30);
            // хвост
            g.FillRectangle(br, _startPosX + 80, _startPosY + 10, 10, 50);
            g.DrawRectangle(pen, _startPosX + 80, _startPosY + 10, 10, 20);
            g.DrawRectangle(pen, _startPosX + 80, _startPosY + 40, 10, 20);
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - warPlaneWidth)
                        _startPosX += step;
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                        _startPosX -= step;
                    break;
                case Direction.Up:
                    if (_startPosY - step > 0)
                        _startPosY -= step;
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - warPlaneHeight)
                        _startPosY += step;
                    break;
            }
        }

        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }
    }
}