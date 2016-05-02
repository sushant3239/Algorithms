using System;

namespace ManagedLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var demoList = new DemoLinkedList<int>();

            for (int i = 0; i < 15; i++)
            {
                demoList.Add(i);
            }
            while (true)
            {
                var item1 = Convert.ToInt32(Console.ReadLine());
                var item2 = Convert.ToInt32(Console.ReadLine());
                demoList.Swap(item1, item2);
                Console.WriteLine("List items =================================");
                demoList.PrintList();
            }
            Console.ReadLine();
        }
    }
}
