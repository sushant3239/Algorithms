using System;

namespace Heap.MinHeap
{
    public class MinHeap<T> where T : IComparable
    {
        private readonly int _size = -1;
        private T[] _arr;
        private int _lastIndex;
        private T _defaultValue = default(T);

        public MinHeap(int size)
        {
            _size = size;
            _lastIndex = 0;
            _arr = new T[_size];
            _arr[0] = _defaultValue;
        }

        public void Insert(T item)
        {
            _lastIndex++;  
            var i = _lastIndex - 1;
            _arr[i] = item;
            while(i != 0 && 
                _arr[Parent(i)].CompareTo(_arr[i]) >= 0)
            {
                var parentIndex = Parent(i);
                Swap(i, parentIndex);
                i = parentIndex;
            }
             
        }

        private void Swap(int fromIndex, int toIndex)
        {
            var temp = _arr[toIndex];
            _arr[toIndex] = _arr[fromIndex];
            _arr[fromIndex] = temp;
        }

        private int Parent(int i)
        {
            return i / 2;
        }
    }
}
