using System;
using System.Drawing;

namespace WindowsFormsBomber
{
    class Bomber : WarPlane, IComparable<Bomber>, IEquatable<Bomber>
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

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес военного самолета</param>
        /// <param name="mainColor">Основной цвет</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="spire">Признак наличия шпиля</param>
        /// <param name="bombs">Признак наличия бомб</param>
        /// <param name="emblem">Признак наличия эмблемы</param>
        public Bomber(int maxSpeed, float weight, Color mainColor, Color dopColor, bool spire, bool bombs, bool emblem)
            : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Spire = spire;
            Bombs = bombs;
            Emblem = emblem;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public Bomber(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 7)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Spire = Convert.ToBoolean(strs[4]);
                Emblem = Convert.ToBoolean(strs[5]);
                Bombs = Convert.ToBoolean(strs[6]);
            }
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

        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + Spire + ";" + Bombs + ";" + Emblem;
        }

        /// <summary>
        /// Метод интерфейса IComparable для класса Bomber
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Bomber other)
        {
            var res = (this as WarPlane).CompareTo(other as WarPlane);
            if (res != 0)
                return res;
            if (DopColor != other.DopColor)
                DopColor.Name.CompareTo(other.DopColor.Name);
            if (Spire != other.Spire)
                return Spire.CompareTo(other.Spire);
            if (Emblem != other.Emblem)
                return Emblem.CompareTo(other.Emblem);
            if (Bombs != other.Bombs)
                return Bombs.CompareTo(other.Bombs);
            return 0;
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса Bomber
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Bomber other)
        {
            var res = (this as WarPlane).Equals(other as WarPlane);
            if (!res)
                return res;
            if (GetType().Name != other.GetType().Name)
                return false;
            if (DopColor != other.DopColor)
                return false;
            if (Spire != other.Spire)
                return false;
            if (Emblem != other.Emblem)
                return false;
            if (Bombs != other.Bombs)
                return false;
            return true;
        }

        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Bomber warPlaneObj))
                return false;
            else
                return Equals(warPlaneObj);
        }

        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}