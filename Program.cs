using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24
{
    class Program
    {
        static void Main()
        {
            // Создание двумерного массива размера 3x4
            int[,] arr = new int[3, 4];
            int count = 0;
            // Заполнение массива рандомными значениями от 1 до 100
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(1, 101);
                }
            }

            // Вывод массива на экран
            Console.WriteLine("Массив:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Поиск седловых точек в массиве
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                // Поиск минимального значения в строке
                int minVal = arr[i, 0];
                int minIndex = 0;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < minVal)
                    {
                        minVal = arr[i, j];
                        minIndex = j;
                    }
                }

                // Проверка, что минимальное значение не повторяется в строке
                bool isSaddlePoint = true;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j != minIndex && arr[i, j] == minVal)
                    {
                        isSaddlePoint = false;
                        break;
                    }
                }

                // Если минимальное значение не повторяется в строке,
                // то проверяем, что оно максимально в столбце
                if (isSaddlePoint)
                {
                    int maxVal = arr[0, minIndex];
                    for (int j = 1; j < arr.GetLength(0); j++)
                    {
                        if (arr[j, minIndex] > maxVal)
                        {
                            maxVal = arr[j, minIndex];
                        }
                    }

                    // Если минимальное значение является максимальным в столбце,
                    // то это седловая точка
                    if (maxVal == minVal)
                    {
                        Console.WriteLine("Седловая точка: ({0}, {1})", i, minIndex);
                        count++;
                    }
                }

            }
            if (count == 0) Console.WriteLine("Седловые точек нет");
            // Ожидание ввода, чтобы консольное окно не закрылось сразу после вывода
            Console.Write("Еще раз? (1-да,0-нет): ");
            int k = Convert.ToInt32(Console.ReadLine());
            if (k == 1)
                Main();
        }
    }
}
