using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    internal class Program
    {
        public static void ShellSort(int[] arr )
        {
            int n = arr.Length;
            int gap = n / 2;
            while ( gap > 0 )
            {
                for ( int i = gap; i < n; i++ )
                {
                    int temp = arr[i];
                    int j = i;
                    while(j >=gap && arr[j-gap]>temp)
                    {
                        arr[j] = arr[j-gap];
                        j-=gap;
                    }
                    arr[j] = temp;
                }
                gap /= 2;
                
            }
        }
        public static void print(int[] arr )
        {
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]+"");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            int[] arr = { 22,55,66,44,88,99,11,33 };
            Console.WriteLine("print array without sort");
            print(arr);
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            ShellSort(arr);
            sw.Stop();
            Console.WriteLine("after shell sort");
            print(arr);
            Console.WriteLine($"arraysize {arr.Length} time taken {sw.Elapsed.TotalMilliseconds} milliseconds");
            Console.ReadKey();
        }
    }
}
