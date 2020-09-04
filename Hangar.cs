using System.Drawing;

namespace WindowsFormsBomber
{
    public class Hangar<T> where T : class, ITransport
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private T[] _places;
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
            _places = new T[sizes];
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            for (int i = 0; i < _places.Length; i++)
                _places[i] = null;
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="hangar">ангар</param>
        /// <param name="warPlane">Добавляемый военный самолет</param>
        /// <returns></returns>
        public static int operator +(Hangar<T> hangar, T warPlane)
        {
            for (int i = 0; i < hangar._places.Length; i++)
                if (hangar.CheckFreePlace(i))
                {
                    hangar._places[i] = warPlane;
                    hangar._places[i].SetPosition(5 + i / 5 * _placeSizeWidth + 5,
                    i % 5 * _placeSizeHeight + 15, hangar.PictureWidth, hangar.PictureHeight);
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
            if (index < 0 || index > hangar._places.Length)
                return null;
            if (!hangar.CheckFreePlace(index))
            {
                T warPlane = hangar._places[index];
                hangar._places[index] = null;
                return warPlane;
            }
            return null;
        }
        /// <summary>
        /// Метод проверки заполнености парковочного места (ячейки массива)
        /// </summary>
        /// <param name="index">Номер парковочного места (порядковый номер в массиве)</param>
        /// <returns></returns>
        private bool CheckFreePlace(int index)
        {
            return _places[index] == null;
        }

        /// <summary>
        /// Метод отрисовки ангара
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
                if (!CheckFreePlace(i)) //если место не пустое
                    _places[i].DrawWarPlane(g);
        }
        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            //границы ангара
            g.DrawRectangle(pen, 0, 0, (_places.Length / 5) * _placeSizeWidth, 450);
            for (int i = 0; i < _places.Length / 5; i++)
            {
                //отрисовываем, по 5 мест на линии
                for (int j = 0; j < 5; ++j)
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + 110, j * _placeSizeHeight);
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 450);
            }
        }
    }
}