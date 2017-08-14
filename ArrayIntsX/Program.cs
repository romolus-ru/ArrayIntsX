using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayIntsX
{
    class Program
    {
        /// <summary>
        /// Простое решение. Двойной цикл и считаем сумму
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="searchSum"></param>
        static void calcSum(int[] arr, int searchSum)
        {
            for (int i = 0; i < arr.Length-1; i++){
                for (int j = i+1; j < arr.Length; j++){
                    if (arr[i] + arr[j] == searchSum){
                        Console.WriteLine(" {0} {1}  ({2}+{3}={4})", i, j, arr[i], arr[j], searchSum);
                    }
                }
            }
        }

        /// <summary>
        /// Стартовый метод рекурсии
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="searchSum"></param>
        static void calcSumMore(int[] arr, int searchSum)
        {
            calcSumMoreRecursion(new List<int>(), 0, arr, searchSum);
        }

        /// <summary>
        /// Рекурсивно ищет сумму из всех имеющихся элементов чтоб получилась нужная сумма 
        /// </summary>
        /// <param name="listRecSum">Список сохраненных элементов</param>
        /// <param name="curPoint">Текущий элемент разделения. после этого номера элемента остальные элементы попадают в ресурсию</param>
        /// <param name="arr">изначальный массив</param>
        /// <param name="searchSum">Искомая сумма</param>
        static void calcSumMoreRecursion(List<int> listRecSum, int curPoint, int[] arr, int searchSum)
        {
            if (curPoint >= arr.Length) return;// прерываем рекурсию когда нечего прибавлять, а суммы не достигли
            calcSumMoreRecursion(new List<int>(listRecSum), curPoint + 1, arr, searchSum);// пропускаем текущий элемент
            listRecSum.Add(arr[curPoint]);// прибавляем текущий элемент и далее считаем вместе с ним
            var sum1 = listRecSum.Sum();
            for (int i = curPoint+1; i < arr.Length; i++){
                if (sum1 + arr[i] > searchSum){
                    // превысили - завершаем рекурсию
                    continue;
                }
                if (sum1 + arr[i] == searchSum){
                    // выводим и завершаем ветвь
                    Console.WriteLine("     {0} {1} {2} ",i,curPoint,sum1);
                    ShowValues(listRecSum, arr[i]);
                    continue;
                }
                var listRecSum1 = new List<int>(listRecSum);// копия массива с суммой
                calcSumMoreRecursion(listRecSum1, curPoint + 1, arr, searchSum);
            }
        }

        private static void ShowValues(List<int> listRecSum, int v)
        {
            Console.WriteLine("" + string.Join("+", listRecSum) + "+" + v.ToString());
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 , 5, 8, 46, 34, 32, 8 };
            var s = string.Join(",", arr);
            Console.WriteLine("массив " + s+" из "+arr.Length.ToString()+" элементов");
            calcSum(arr,9);
            //calcSumMore(arr, 9);
            Console.ReadLine();
            
        }
    }
}
