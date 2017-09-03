using System;
using System.Collections;
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
            var hash = new Hashtable();
            foreach (var item in arr){
                if (!hash.Contains(item))
                    hash.Add(item, 0);
            }
            foreach (var item in arr)
            {
                var s = searchSum - item;
                if (hash.Contains(s))
                {
                    Console.WriteLine("{0} {1}", s, item);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 , 5, 8, 46, 34, 32, 8 };
            var s = string.Join(",", arr);
            Console.WriteLine("массив " + s+" из "+arr.Length.ToString()+" элементов");
            calcSum(arr,9);
            Console.ReadLine();
            
        }
    }
}
