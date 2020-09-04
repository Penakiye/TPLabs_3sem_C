using System;
using System.Drawing;

namespace WindowsFormsBomber
{
    class Bomber : WarPlane
    {
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
             : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Spire = spire;
            Bombs = bombs;
            Emblem = emblem;
        }

        public override void DrawWarPlane(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            if (Spire)
            {
                Brush brSpire = new SolidBrush(DopColor);
                g.FillEllipse(brSpire, _startPosX, _startPosY + 33, 50, 4);
                g.DrawEllipse(pen, _startPosX, _startPosY + 33, 50, 4);
            }

            base.DrawWarPlane(g);

            if (Emblem)
            {
                Brush emblem = new SolidBrush(DopColor);
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
