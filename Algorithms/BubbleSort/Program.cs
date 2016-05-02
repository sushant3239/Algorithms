using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 76, 676, 234, 6865, 3445, 3232, 3445, 3 };
            Sort(arr);
            PrintArray(arr);
            Console.ReadLine();
        }

        private static void Sort(int[] arr)
        {
            var length = arr.Count();
            for (int i = 0; i < length; i++)
            {
                var swapped = false;
                for (int j = 0; j < length; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        private static void Swap(int[] arr, int swapToIndex, int swapFromIndex)
        {
            var temp = arr[swapToIndex];
            arr[swapToIndex] = arr[swapFromIndex];
            arr[swapFromIndex] = temp;
        }
        private static void PrintArray(int[] arr)
        {
            var length = arr.Count();
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
