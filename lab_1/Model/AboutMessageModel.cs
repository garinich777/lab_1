using System;

namespace lab_1.Model
{
    static class AboutMessageModel
    {
        public static string GetAboutMessage() =>
            "Lab_1" + Environment.NewLine +
            "Лабораторная работа №1" + Environment.NewLine +
            "Использование массивов" + Environment.NewLine +
            "Написать программу для разделения" + Environment.NewLine +
            "массива на два, размером N/2" + Environment.NewLine +
            "первый с четными индексами,"+ Environment.NewLine + 
            "второй с нечетными" + Environment.NewLine +
            "Студент группы 484" + Environment.NewLine +
            "Осипов Игорь Вадимович" + Environment.NewLine +
            "2020 год";
    }
}
