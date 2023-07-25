using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        private static void QuickSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                int pivotINdex = Partition(array, left, right);
                QuickSort(array, left, pivotINdex-1);
                QuickSort(array,pivotINdex+1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;

        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            int[] array = { 9, -3, 5, 2, 6, 8, -6, 1, 3 };
            Console.WriteLine("Original Array");
            print(array);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(array);
            stopwatch.Stop();
            Console.WriteLine("After Qucik Sort");
            print(array);
            Console.WriteLine($"ArraySize {array.Length} Time Taken {stopwatch.Elapsed.TotalMilliseconds}");

            Console.ReadKey();
        }
    }
}
