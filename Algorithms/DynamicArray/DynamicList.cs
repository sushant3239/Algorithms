using System;

namespace DynamicArray
{
    public class DynamicList<T>
    {
        private readonly int _initialSizeOfArray = 1;
        private int _currentSizeOfArray;
        private T[] _localArray;
        private int _lastInsertIndex = -1;

        public DynamicList()
        {
            _currentSizeOfArray = _initialSizeOfArray;
            _localArray = new T[_initialSizeOfArray];
        }

        public void Add(T item)
        {
            if (IsListFull())
            {
                var newEmptyArray = CreateNewEmptyArrayWithNewSize();
                PerformCopy(_localArray, newEmptyArray);
                _currentSizeOfArray = newArraySize();
                _localArray = newEmptyArray;           
            }
            _lastInsertIndex++;
            _localArray[_lastInsertIndex] = item;
            
        }

        private int newArraySize()
        {
            return _currentSizeOfArray * 2;
        }

        private void PerformCopy(T[] sourceArray, T[] emptyArray)
        {
            for(int i = 0; i < _currentSizeOfArray; i++)
            {
                emptyArray[i] = sourceArray[i];
            }
        }

        private bool IsListFull()
        {
            return _lastInsertIndex == (_currentSizeOfArray - 1);
        }

        private T[] CreateNewEmptyArrayWithNewSize()
        {
            return new T[newArraySize()];
        }
    }
}
