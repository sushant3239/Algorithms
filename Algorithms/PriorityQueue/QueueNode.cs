using System;

namespace PriorityQueue
{
    public class QueueNode<T>
    {
        public T Data { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        Low, Average, High
    }
}
