using System.Drawing;

namespace WindowsFormsBomber
{
    public abstract class AirTransport : ITransport
    {
        protected float _startPosX;
        protected float _startPosY;
        protected int _pictureWidth;
        protected int _pictureHeight;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { protected set; get; }

        /// <summary>
        /// Вес военного самолета
        /// </summary>
        public float Weight { protected set; get; }

        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color MainColor { protected set; get; }

        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public abstract void DrawWarPlane(Graphics g);
        public abstract void MoveTransport(Direction direction);
    }
}
