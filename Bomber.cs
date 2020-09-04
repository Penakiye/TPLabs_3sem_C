using System;
using System.Drawing;

namespace WindowsFormsBomber
{
    class Bomber
    {
        /// <summary>
        /// Начальная координата x отрисовки
        /// </summary>
        private float _startPosX;

        /// <summary>
        /// Начальная координата y отрисовки
        /// </summary>
        private float _startPosY;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;

        /// <summary>
        /// Ширина отрисовки бомбардировщика
        /// </summary>
        private const int bomberWidth = 100;

        /// <summary>
        /// Ширина отрисовки бомбардировщика
        /// </summary>
        private const int bomberHeight = 80;

        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }

        /// <summary>
        /// Вес бомбардировщика
        /// </summary>
        public float Weight { private set; get; }

        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color MainColor { private set; get; }

        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Признак наличия шпиля
        /// </summary>
        public bool Spire { private set; get; }

        /// <summary>
        /// Признак наличия бомб
        /// </summary>
        public bool Bombs { private set; get; }

        /// <summary>
        /// Признак наличия эмблемы
        /// </summary>
        public bool Emblem { private set; get; }

        public Bomber(int maxSpeed, float weight, Color mainColor, Color dopColor, bool spire, bool bombs, bool emblem)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Spire = spire;
            Bombs = bombs;
            Emblem = emblem;
        }

        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - bomberWidth)
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
                    if (_startPosY + step < _pictureHeight - bomberHeight)
                        _startPosY += step;
                    break;
            }
        }

        public void DrawBomber(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            if (Spire)
            {
                Brush brSpire = new SolidBrush(DopColor);
                g.FillEllipse(brSpire, _startPosX, _startPosY + 33, 50, 4);
                g.DrawEllipse(pen, _startPosX, _startPosY + 33, 50, 4);
            }
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
            if (Emblem)
            {
                Brush emblem = new SolidBrush(Color.Red);
                g.FillEllipse(emblem, _startPosX + 45, _startPosY + 50, 10, 10);
                g.DrawEllipse(pen, _startPosX + 45, _startPosY + 50, 10, 10);

                g.FillEllipse(emblem, _startPosX + 45, _startPosY + 10, 10, 10);
                g.DrawEllipse(pen, _startPosX + 45, _startPosY + 10, 10, 10);
            }
            if (Bombs)
            {
                Brush brGray = new SolidBrush(Color.DarkGray);
                int i = 0;
                int j = 0;
                while (i < 6)
                {
                    g.FillEllipse(brGray, _startPosX + 30, _startPosY + j, 10, 10);
                    g.DrawEllipse(pen, _startPosX + 30, _startPosY + j, 10, 10);
                    i++;
                    j += 10;
                    if (i == 3)
                    {
                        j += 10;
                    }
                }
            }
        }
    }
}
