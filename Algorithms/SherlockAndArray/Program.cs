using System;

namespace SherlockAndArray
{
    class Solution
    {
        static void Main(String[] args)
        {
            var numberOfTests = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTests; i++)
            {
                ProcessAlgorithm();
            }

            Console.Read();
        }

        private static void ProcessAlgorithm()
        {
            var lengthOfArray = Console.ReadLine();
            var arr_temp = Console.ReadLine().Split(' ');
            var arr = Array.ConvertAll(arr_temp, Int32.Parse);

            var found = IsNUmberExists(arr);
            if (found)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool IsNUmberExists(int[] arr)
        {
            var numberFound = false;
            for (var i = 0; i < arr.Length; i++)
            {
                numberFound = ProcessItem(i, arr);
                if (numberFound) break;
            }
            return numberFound;
        }

        private static bool ProcessItem(int itemIndex, int[] arr)
        {
            if (itemIndex == 0 || (itemIndex == arr.Length - 1)) return false;

            var numberAtIndex = arr[itemIndex];
            var sumLeft = CalculateLeft(itemIndex, arr);
            var sumRight = CalculateRight(itemIndex, arr);
            return sumLeft == sumRight;
        }

        private static int CalculateRight(int itemIndex, int[] arr)
        {
            var sum = 0;
            for (var i = itemIndex + 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        private static int CalculateLeft(int itemIndex, int[] arr)
        {
            var sum = 0;
            for (var i = itemIndex - 1; i >= 0; i--)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
}
