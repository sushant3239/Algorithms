using System;
using System.Diagnostics;

namespace ManagedLinkedList
{
    public class DemoLinkedList<T> where T : IComparable
    {
        public ListNode<T> Head { get; private set; }
        public ListNode<T> Tail { get; private set; }
        private int _count;
        private ListNode<T> CurrentNode;

        public void Add(T item)
        {
            _count++;
            if (Head == null)
            {
                SetFirst(item);
                return;
            }
            AppendToTail(item);
        }

        private void SetFirst(T item)
        {
            Head = new ListNode<T>
            {
                PreviousNode = null,
                NextNode = null,
                Value = item,
            };
            Tail = Head;
        }

        private void AppendToTail(T item)
        {
            var newNode = new ListNode<T>
            {
                PreviousNode = Tail,
                NextNode = null,
                Value = item,
            };
            Tail.NextNode = newNode;
            Tail = newNode;
        }

        public void PrintList()
        {
            CurrentNode = Head;
            while (CurrentNode != null)
            {
                Console.WriteLine(CurrentNode.Value);
                CurrentNode = CurrentNode.NextNode;
            }
            CurrentNode = Head;
        }

        public void Delete(T item)
        {
            var current = Head;
            var previous = current;

            if (current.Value.CompareTo(item) == 0) Head = Head.NextNode;

            while (current != null && current.Value.CompareTo(item) != 0)
            {
                previous = current;
                current = current.NextNode;
            }

            if (current != null) previous.NextNode = current.NextNode;
        }

        public void Swap(T item1, T item2)
        {
            var node1 = FindNode(item1);
            var node2 = FindNode(item2);
            Swap(node1, node2);
        }

        private void Swap(ListNode<T> item1, ListNode<T> item2)
        {
            //if(item1.NextNode == item2)
            //{
            //    item1.PreviousNode.NextNode = item2;
            //    item2.PreviousNode = item1.PreviousNode;
            //    item2.NextNode = item1;
            //    item1.PreviousNode = item2;
            //}
            var tempPrevious = item2.PreviousNode;
            var tempNext = item1.NextNode;

            item2.PreviousNode.NextNode = item1;
            item1.NextNode = item2.NextNode;

            item1.PreviousNode.NextNode = item2;
            item2.NextNode = tempNext;
        }

        private ListNode<T> FindNode(T item)
        {
            var current = Head;
            if (current.Value.CompareTo(item) == 0) return current;

            while (current != null && current.Value.CompareTo(item) != 0)
            {
                current = current.NextNode;
            }
            return current;
        }
    }
}
