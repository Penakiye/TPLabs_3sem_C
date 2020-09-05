using System;

namespace WindowsFormsBomber
{
    /// <summary>
    /// Класс-ошибка "Если в ангаре уже заняты все места"
    /// </summary>
    public class HangarOverflowException : Exception
    {
        public HangarOverflowException() : base("В ангаре нет свободных мест")
        { }
    }
}
