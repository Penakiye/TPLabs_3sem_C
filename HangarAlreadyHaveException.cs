using System;

namespace WindowsFormsBomber
{
    /// <summary>
    /// Класс-ошибка "Если в ангаре уже есть военный самолет с такими же характеристиками"
    /// </summary>
    public class HangarAlreadyHaveException : Exception
    {
        public HangarAlreadyHaveException() : base("В ангаре уже есть такой военный самолет")
        { }
    }
}
