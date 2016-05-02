using System;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(32, Priority.High);
            queue.Enqueue(4, Priority.Low);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue(23, Priority.Low);
            queue.Enqueue(43, Priority.High);
            queue.Enqueue(36);
            queue.Enqueue(36);
            queue.Enqueue(245);
            queue.Enqueue(66);
            queue.Enqueue(436);
            queue.Enqueue(3655, Priority.High);
            queue.Enqueue(3677);

            queue.PrintByPriority();
            Console.ReadLine();
        }
    }
}
