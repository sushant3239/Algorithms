using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10] { 3, 4, 6, 8, 9, 12, 22, 45, 67, 89 };

            while (true)
            {
                var item = Convert.ToInt32(Console.ReadLine());
                var length = arr.Count();
                Console.WriteLine(Search(arr, item, 0, length - 1));
            }
        }

        private static bool Search(int[] arr, int item, int fromIndex = 0, int toIndex = 0)
        {
            if (fromIndex <= toIndex)
            {
                var mid = fromIndex + (toIndex - fromIndex) / 2;
                if (item == arr[mid]) return true;
                if (item < arr[mid]) return Search(arr, item, fromIndex, mid - 1);
                else return Search(arr, item, mid + 1, toIndex);
            }
            return false;
        }
    }
}
