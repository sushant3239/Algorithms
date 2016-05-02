using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class PriorityQueue<T>
    {
        private List<QueueNode<T>> _items;

        public PriorityQueue()
        {
            _items = new List<QueueNode<T>>();
        }

        public void Enqueue(T item, Priority priority = Priority.Average)
        {
            var size = _items.Count;
            if (size == 0)
            {
                _items.Add(CraeteNewNode(item, priority));
                return;
            };
            var current = size;
            _items.Add(CraeteNewNode(item, priority));


            while (current > 0)
            {
                var parent = (current - 1) / 2;
                if (IsHighPriorityNode(_items[current].Priority, _items[parent].Priority))
                {
                    Swap(current, Parent(current));
                    current = Parent(current);
                }
                else break;
            }
        }

        private void Swap(int current, int other)
        {
            var temp = _items[other];
            _items[other] = _items[current];
            _items[current] = temp;
        }

        private int Parent(int index)
        {
            return index / 2;
        }

        private QueueNode<T> CraeteNewNode(T item, Priority priority)
        {
            return new QueueNode<T> { Data = item, Priority = priority, };
        }

        private bool IsHighPriorityNode(Priority currentPriority, Priority otherPriority)
        {
            if ((currentPriority == Priority.High && (otherPriority == Priority.Average || otherPriority == Priority.Low))
                || (currentPriority == Priority.Average && otherPriority == Priority.Low)) return true;
            return false;
        }

        public void PrintByPriority()
        {
            var current = 1;
            while (current <= _items.Count / 2)
            {
                var leftChild = (current - 1) * 2;
                var rightChild = leftChild + 1;
                Console.WriteLine(_items[leftChild].Data);
                Console.WriteLine(_items[rightChild].Data);
                current++;
            }
        }

        public void LevelOrderTraversal()
        {
            var queue = new Queue<QueueNode<T>>();
            var current = 0;
            queue.Enqueue(_items[0]);
            current = 1;
            while (current < _items.Count && queue.Count > 0)
            {
                var dqueuedItem = queue.Dequeue();
                Console.WriteLine(dqueuedItem.Data);
                var currentChildIndex = current * 2;
                queue.Enqueue(_items[current]);
                if (currentChildIndex < _items.Count)
                {
                    queue.Enqueue(_items[currentChildIndex]);
                    queue.Enqueue(_items[currentChildIndex + 1]);
                }
                else
                {
                    foreach (var item in queue)
                    {
                        Console.WriteLine(item.Data);
                    }
                }
                current = currentChildIndex;
            }
        }
    }
}
