using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsBomber
{
    public class Hangar<T> where T : class, ITransport
    {
        /// <summary>
        /// Словарь объектов, которые храним
        /// </summary>
        private Dictionary<int, T> _places;
        /// <summary>
        /// Максимальное количество мест в ангаре
        /// </summary>
        private int _maxCount;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int PictureWidth { get; set; }
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int PictureHeight { get; set; }
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private const int _placeSizeWidth = 210;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private const int _placeSizeHeight = 90;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sizes">Количество мест в ангаре</param>
        /// <param name="pictureWidth">Размер ангара - ширина</param>
        /// <param name="pictureHeight">Размер ангара - высота</param>
        public Hangar(int sizes, int pictureWidth, int pictureHeight)
        {
            _maxCount = sizes;
            _places = new Dictionary<int, T>();
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: в ангар добавляется самолет
        /// </summary>
        /// <param name="hangar">ангар</param>
        /// <param name="warPlane">Добавляемый военный самолет</param>
        /// <returns></returns>
        public static int operator +(Hangar<T> hangar, T warPlane)
        {
            if (hangar._places.Count == hangar._maxCount)
                return -1;
            for (int i = 0; i < hangar._maxCount; i++)
                if (hangar.CheckFreePlace(i))
                {
                    hangar._places.Add(i, warPlane);
                    hangar._places[i].SetPosition(5 + i / 5 * _placeSizeWidth + 5, i % 5 * _placeSizeHeight + 15, hangar.PictureWidth, hangar.PictureHeight);
                    return i;
                }
            return -1;
        }

        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: из ангара забираем военный самолет
        /// </summary>
        /// <param name="hangar">ангар</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(Hangar<T> hangar, int index)
        {
            if (!hangar.CheckFreePlace(index))
            {
                T warPlane = hangar._places[index];
                hangar._places.Remove(index);
                return warPlane;
            }
            return null;
        }

        /// <summary>
        /// Метод проверки заполнености парковочного места
        /// </summary>
        /// <param name="index">Номер парковочного места (порядковый номер в массиве)</param>
        /// <returns></returns>
        private bool CheckFreePlace(int index)
        {
            return !_places.ContainsKey(index);
        }

        /// <summary>
        /// Метод отрисовки ангара
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            var keys = _places.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
                _places[keys[i]].DrawWarPlane(g);
        }

        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            //границы парковки
            g.DrawRectangle(pen, 0, 0, (_maxCount / 5) * _placeSizeWidth, 450);
            for (int i = 0; i < _maxCount / 5; i++)
            {//отрисовываем, по 5 мест на линии
                for (int j = 0; j < 5; ++j)
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + 110, j * _placeSizeHeight);
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 450);
            }
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public T this[int ind]
        {
            get
            {
                if (_places.ContainsKey(ind))
                    return _places[ind];
                return null;
            }
            set
            {
                if (CheckFreePlace(ind))
                {
                    _places.Add(ind, value);
                    _places[ind].SetPosition(5 + ind / 5 * _placeSizeWidth + 5, ind % 5
                    * _placeSizeHeight + 15, PictureWidth, PictureHeight);
                }
            }
        }

    }
}