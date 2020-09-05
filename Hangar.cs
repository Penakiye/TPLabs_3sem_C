using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsBomber
{
    public class Hangar<T> : IEnumerator<T>, IEnumerable<T>, IComparable<Hangar<T>>
        where T : class, ITransport
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
        /// Текущий элемент для вывода через IEnumerator
        /// </summary>
        private int _currentIndex;

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
            _currentIndex = -1;
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
        }

        /// <summary>
        /// Получить порядковое место в ангаре
        /// </summary>
        public int GetKey
        {
            get
            {
                return _places.Keys.ToList()[_currentIndex];
            }
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
                throw new HangarOverflowException();
            if (hangar._places.ContainsValue(warPlane))
                throw new HangarAlreadyHaveException();
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
            throw new HangarNotFoundException(index);
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
            foreach (var warPlane in _places)
                warPlane.Value.DrawWarPlane(g);
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
                throw new HangarNotFoundException(ind);
            }
            set
            {
                if (CheckFreePlace(ind))
                {
                    _places.Add(ind, value);
                    _places[ind].SetPosition(5 + ind / 5 * _placeSizeWidth + 5, ind % 5
                    * _placeSizeHeight + 15, PictureWidth, PictureHeight);
                }
                else
                {
                    throw new HangarOccupiedPlaceException(ind);
                }
            }
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для получения текущего элемента
        /// </summary>
        public T Current
        {
            get
            {
                return _places[_places.Keys.ToList()[_currentIndex]];
            }
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для получения текущего элемента
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary>
        /// Метод интерфейса IEnumerator, вызываемый при удалении объекта
        /// </summary>
        public void Dispose()
        {
            _places.Clear();
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для перехода к следующему элементу или началу коллекции
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_currentIndex + 1 >= _places.Count)
            {
                Reset();
                return false;
            }
            _currentIndex++;
            return true;
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для сброса и возврата к началу коллекции
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
        }

        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Метод интерфейса IComparable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Hangar<T> other)
        {
            if (_places.Count > other._places.Count)
                return -1;
            else if (_places.Count < other._places.Count)
                return 1;
            else if (_places.Count > 0)
            {
                var thisKeys = _places.Keys.ToList();
                var otherKeys = other._places.Keys.ToList();
                for (int i = 0; i < _places.Count; ++i)
                {
                    if (_places[thisKeys[i]] is WarPlane && other._places[otherKeys[i]] is Bomber)
                        return 1;
                    if (_places[thisKeys[i]] is WarPlane && other._places[otherKeys[i]] is Bomber)
                        return -1;
                    if (_places[thisKeys[i]] is WarPlane && other._places[otherKeys[i]] is WarPlane)
                        return (_places[thisKeys[i]] is WarPlane).CompareTo(other._places[otherKeys[i]] is WarPlane);
                    if (_places[thisKeys[i]] is Bomber && other._places[otherKeys[i]] is Bomber)
                        return (_places[thisKeys[i]] is Bomber).CompareTo(other._places[otherKeys[i]] is Bomber);
                }
            }
            return 0;
        }
    }
}