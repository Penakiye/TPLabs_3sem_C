using System.Collections.Generic;

namespace WindowsFormsBomber
{
    /// <summary>
    /// Класс-хранилище ангаров
    /// </summary>
    public class MultiLevelHangar
    {
        /// <summary>
        /// Список с уровнями ангаров
        /// </summary>
        List<Hangar<ITransport>> hangarStages;

        /// <summary>
        /// Сколько мест на каждом уровне
        /// </summary>
        private const int countPlaces = 20;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countStages">Количество уровеней ангаров</param>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public MultiLevelHangar(int countStages, int pictureWidth, int pictureHeight)
        {
            hangarStages = new List<Hangar<ITransport>>();
            for (int i = 0; i < countStages; ++i)
                hangarStages.Add(new Hangar<ITransport>(countPlaces, pictureWidth, pictureHeight));
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Hangar<ITransport> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < hangarStages.Count)
                    return hangarStages[ind];
                return null;
            }
        }
    }
}