using System;

namespace WindowsFormsBomber
{
    /// <summary>
    /// Класс-ошибка "Если не найден самолет по определенному месту"
    /// </summary>
    public class HangarNotFoundException : Exception
    {
        public HangarNotFoundException(int i) : base("Не найден самолет по месту " + i)
        { }
    }
}
