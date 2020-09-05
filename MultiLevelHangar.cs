using System;
using System.Collections.Generic;
using System.IO;

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
        /// Ширина окна отрисовки
        /// </summary>
        private int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int pictureHeight;
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
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
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

        /// <summary>
        /// Сохранение информации по самолетам в ангарах в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                //Записываем количество уровней
                sw.WriteLine("CountLeveles:" + hangarStages.Count);
                foreach (var level in hangarStages)
                {
                    //Начинаем уровень
                    sw.WriteLine("Level");
                    for (int i = 0; i < countPlaces; i++)
                    {
                        var plane = level[i];
                        if (plane != null)
                        {
                            //если место не пустое, то записываем тип самолета
                            if (plane.GetType().Name == "WarPlane")
                                sw.Write(i + ":WarPlane:");
                            if (plane.GetType().Name == "Bomber")
                                sw.Write(i + ":Bomber:");
                            sw.WriteLine(plane);
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Загрузка информации по самолетам в ангарах из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
                return false;
            ITransport warPlane;
            int counter = -1;
            int count;
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                if (line.Contains("CountLeveles"))
                {
                    count = Convert.ToInt32(line.Split(':')[1]);
                    if (hangarStages != null)
                        hangarStages.Clear();
                }
                else
                    return false;
                while ((line = sr.ReadLine()) != null)
                {
                    line.Replace("\r", "");
                    warPlane = null;
                    if (line == "Level")
                    {
                        //начинаем новый уровень
                        counter++;
                        hangarStages.Add(new Hangar<ITransport>(countPlaces, pictureWidth, pictureHeight));
                        continue;
                    }
                    if (string.IsNullOrEmpty(line))
                        continue;
                    if (line.Split(':')[1] == "WarPlane")
                        warPlane = new WarPlane(line.Split(':')[2]);
                    else if (line.Split(':')[1] == "Bomber")
                        warPlane = new Bomber(line.Split(':')[2]);
                    hangarStages[counter][Convert.ToInt32(line.Split(':')[0])] = warPlane;
                }
            }
            return true;
        }
    }
}