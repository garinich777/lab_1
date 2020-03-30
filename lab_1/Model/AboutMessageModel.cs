using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1.Model
{
    static class AboutMessageModel
    {
        public static string GetAboutMessage() =>
            "Lab_1\n" +
            "Лабораторная работа №1\n" +
            "Использование массивов\n" +
            "Написать программу для разделения\n" +
            "массива на два, размером N/2\n" +
            "первый с четными индексами,\n второй с нечетными\n" +
            "Студент группы 484\n" +
            "Осипов Игорь Вадимович\n" +
            "2020 год";
    }
}
