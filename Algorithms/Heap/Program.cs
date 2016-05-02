using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new MinHeap.MinHeap<int>(10);
            heap.Insert(15);
            heap.Insert(14);
            heap.Insert(5);
            heap.Insert(17);
            heap.Insert(18);
            heap.Insert(123);
            heap.Insert(11);
            heap.Insert(9);
            heap.Insert(8);
            heap.Insert(28);
            Console.ReadLine();
        }
    }
}
