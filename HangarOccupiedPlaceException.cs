using System;

namespace WindowsFormsBomber
{
    /// <summary>
    /// Класс-ошибка "Если место, на которое хотим поставить самолет уже занято"
    /// </summary>
    public class HangarOccupiedPlaceException : Exception
    {
        public HangarOccupiedPlaceException(int i) : base("На месте " + i + " уже стоит самолет")
        { }
    }
}
