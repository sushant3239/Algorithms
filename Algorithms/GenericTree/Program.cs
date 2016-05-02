
using GenericTree.Tree;
using System;

namespace GenericTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();

            tree.Add(456);
            tree.Add(345);
            tree.Add(453);
            tree.Add(21);
            tree.Add(347);
            tree.Add(567);
            tree.Add(122);
            tree.Add(23468);
            tree.Add(356);
            tree.Add(768);
            tree.Add(244);
            tree.Add(53);
            tree.Add(23);
            tree.Add(10);

            while (true)
            {
                var item = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(tree.LowestAncestor(item));
            }
        }
    }
}
