using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortAssignment
{
    internal class Program
    {
        public static void QuickSortRecursive(int[] arr)
        {
            QuickSortRecursive(arr, 0, arr.Length - 1);
        }

        private static void QuickSortRecursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);

                QuickSortRecursive(arr, left, pivotIndex - 1);
                QuickSortRecursive(arr, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivotValue = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivotValue)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;

            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
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
            int[] array1 = { 9, -3, 5, 2, 6, 8, -6, 1, 3 };

            Console.WriteLine("Original Array");
            print(array1);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSortRecursive(array1);
            stopwatch.Stop();
            Console.WriteLine("After Quick sort");
            print(array1);
           
            Console.WriteLine($"ArraySize {array1.Length} Time Taken {stopwatch.Elapsed.TotalMilliseconds} milliseconds\n");

            int[] array2 = { 55, 88, 99, 22, 33, 77 };

            Console.WriteLine("Original Array :\n" + string.Join(",", array2));
            stopwatch.Start();
            MergeSort(array2);
            stopwatch.Stop();
            MergeSort(array2);
            Console.WriteLine("\nMergeSorted Array:\n" + string.Join(",", array2));
            
            Console.WriteLine($"\nArraySize {array2.Length} Time Taken {stopwatch.Elapsed.TotalMilliseconds} milliseconds \n");

            Console.ReadKey();

            
        }
    }
}
