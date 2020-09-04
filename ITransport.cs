using System.Drawing;

namespace WindowsFormsBomber
{
    interface ITransport
    {
        /// <summary>
        /// Установка позиции транспорта
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        void SetPosition(int x, int y, int width, int height);
        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        /// <param name="direction">Направление</param>
        void MoveTransport(Direction direction);
        /// <summary>
        /// Отрисовка транспорта
        /// </summary>
        /// <param name="g"></param>
        void DrawWarPlane(Graphics g);
    }
}
