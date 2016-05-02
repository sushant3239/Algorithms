using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> testList = new DynamicList<int>();
            for (int i = 0; i < 100; i++)
            {
                testList.Add(i);
                Console.WriteLine("added at : " + i.ToString());
            }
            Console.ReadLine();
        }
    }
}
