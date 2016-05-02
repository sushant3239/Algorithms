using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.WhenAll(TestTask(), TestTask(), TestTask4(), TestTask3(), TestTask2(), TestTask1());
            task.ContinueWith(SomeAction);
            Console.Read();
        }

        private static void SomeAction(Task obj)
        {
           
        }

        private async static Task TestTask()
        {
            await Task.Delay(1000);
        }

        private async static Task TestTask1()
        {
            await Task.Delay(1000);
            throw new IndexOutOfRangeException();
        }
        private async static Task TestTask2()
        {
            await Task.Delay(1000);
            throw new InvalidOperationException();
        }
        private async static Task TestTask3()
        {
            await Task.Delay(1000);
            throw new InvalidProgramException();
        }
        private async static Task TestTask4()
        {
            await Task.Delay(1000);
            throw new InvalidTimeZoneException();
        }
    }
}
