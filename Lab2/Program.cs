using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        class Class
        {
            static void Main()
            {
                Task66();
                Task73();
                Task92();
                Task129();
                Task190();
            }

            /// <summary>
            /// 66.Найти произведение всех элементов массива целых чисел, меньших 0.
            /// </summary>
            static void Task66()
            {
                int[] numbers = GenerateRandomArray(10, -10, 10);
                int product = FindProductOfNegativeNumbers(numbers);
                Console.WriteLine("Массив чисел:");
                Console.WriteLine(string.Join(", ", numbers));
                Console.WriteLine($"Произведение отрицательных чисел: {product}");
                Console.ReadLine();
            }

            static int[] GenerateRandomArray(int length, int minValue, int maxValue)
            {
                Random random = new Random();
                int[] array = new int[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = random.Next(minValue, maxValue + 1);
                }
                return array;
            }

            static int FindProductOfNegativeNumbers(int[] array)
            {
                int product = 1;
                foreach (int number in array)
                {
                    if (number < 0)
                    {
                        product *= number;
                    }
                }
                return product;
            }
            /// <summary>
            /// 73.Даны последовательность вещественных чисел а1, a2, ..., а15, упорядоченная по возрастанию, и число n, не равное ни одному из чисел последовательности. Найти элемент последовательности (его порядковый номер и значение), ближайший к n.
            /// </summary>
            static void Task73()
            {
                double[] sequence = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0 };
                Console.Write("Введите число n: ");
                double n = double.Parse(Console.ReadLine());
                FindClosestElement(sequence, n, out int closestIndex, out double closestValue);
                Console.WriteLine("Порядковый номер ближайшего элемента: " + closestIndex);
                Console.WriteLine("Значение ближайшего элемента: " + closestValue);
                Console.ReadLine();
            }

            static void FindClosestElement(double[] sequence, double n, out int closestIndex, out double closestValue)
            {
                closestIndex = -1;
                closestValue = double.MaxValue;
                double minDiff = double.MaxValue;

                int left = 0;
                int right = sequence.Length - 1;

                while (left <= right)
                {
                    int middle = left + (right - left) / 2;
                    double diff = Math.Abs(sequence[middle] - n);
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        closestIndex = middle;
                        closestValue = sequence[middle];
                    }
                    if (sequence[middle] < n)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            /// <summary>
            /// 92.Удалить k-й элемент массива целых чисел A(50).
            /// </summary>
            static void Task92()
            {
                int[] A = new int[50]; 
                int k;

                Console.Write("Введите индекс элемента для удаления (0-49): ");
                if (int.TryParse(Console.ReadLine(), out k) && k >= 0 && k < A.Length)
                {
                    Random random = new Random();
                    for (int i = 0; i < A.Length; i++)
                    {
                        A[i] = random.Next(1, 101); 
                    }

                    Console.WriteLine("Исходный массив:");
                    Console.WriteLine(string.Join(", ", A));

                    RemoveElementAtIndex(ref A, k);

                    Console.WriteLine("Массив после удаления элемента:");
                    Console.WriteLine(string.Join(", ", A));
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите индекс от 0 до 49.");
                }
                Console.ReadLine();
            }

            static void RemoveElementAtIndex(ref int[] array, int index)
            {
                if (index < 0 || index >= array.Length)
                {
                    Console.WriteLine("Индекс находится за пределами границ массива.");
                    return;
                }

                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[array.Length - 1] = 0;
            }
        }
        /// <summary>
        ///129.Дана последовательность вещественных чисел а1 ≤ а2 ≤ ... ≤ аn. Вставить в нее вещественное число b так, чтобы последовательность осталась неубывающей.
        /// </summary>
        static void Task129()
        {
            double[] a = new double[50]; 
            double b; 

            Console.Write("Введите вещественное число для вставки: ");
            if (double.TryParse(Console.ReadLine(), out b))
            {
                Random random = new Random();
                a[0] = random.Next(1, 11); 
                for (int i = 1; i < a.Length; i++)
                {
                    a[i] = a[i - 1] + random.NextDouble(); 
                }

                Console.WriteLine("Исходная неубывающая последовательность:");
                Console.WriteLine(string.Join(", ", a));

                InsertIntoSortedArray(ref a, b);

                Console.WriteLine("Последовательность после вставки элемента:");
                Console.WriteLine(string.Join(", ", a));
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите вещественное число.");
            }
            Console.ReadLine();
        }

        static void InsertIntoSortedArray(ref double[] array, double element)
        {
            int indexToInsert = 0;

            while (indexToInsert < array.Length && array[indexToInsert] <= element)
            {
                indexToInsert++;
            }

            double[] newArray = new double[array.Length + 1];

            Array.Copy(array, newArray, indexToInsert);
          
            newArray[indexToInsert] = element;

            Array.Copy(array, indexToInsert, newArray, indexToInsert + 1, array.Length - indexToInsert);

            array = newArray;
        }
        /// <summary>
        /// 190.Дан массив из n четырехзначных натуральных чисел. Вывести на экран только те, у которых сумма первых двух цифр равна сумме двух последних.
        /// </summary>
        static void Task190()
        {
            int n = 10; 
            int[] numbers = GenerateRandomFourDigitNumbers(n);

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(", ", numbers));

            bool foundNumbers = false; 

            Console.WriteLine("Четырехзначные числа, у которых сумма первых двух цифр равна сумме двух последних:");

            foreach (int number in numbers)
            {
                if (IsSumOfFirstTwoDigitsEqualSumOfLastTwoDigits(number))
                {
                    Console.WriteLine(number);
                    foundNumbers = true;
                }
            }

            if (!foundNumbers)
            {
                Console.WriteLine("Подходящие числа не найдены.");
            }
            Console.ReadLine();
        }

        static int[] GenerateRandomFourDigitNumbers(int count)
        {
            Random random = new Random();
            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next(1000, 10000); 
            }

            return numbers;
        }

        static bool IsSumOfFirstTwoDigitsEqualSumOfLastTwoDigits(int number)
        {
            int thousands = number / 1000;
            int hundreds = (number / 100) % 10;
            int tens = (number / 10) % 10;
            int ones = number % 10;
            return (thousands + hundreds) == (tens + ones);
        }
    }
}














