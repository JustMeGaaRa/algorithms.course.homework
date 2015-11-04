using System;
using System.Collections;
using System.Collections.Generic;

namespace hamstr
{
    public class DataStructures
    {
        public class BinaryMaxHeap<TKey> : IEnumerable<TKey> where TKey : IComparable<TKey>
        {
            private readonly TKey[] _items;

            private int _currentSize;

            public BinaryMaxHeap(int capacity)
            {
                _items = new TKey[capacity];
            }

            public int CurrentSize => _currentSize;

            public void Add(TKey item)
            {
                if (_currentSize == _items.Length)
                {
                    throw new InvalidOperationException("Heap capacity exceeded. Cannot add new item.");
                }

                _items[_currentSize] = item;
                _currentSize++;
                BubbleUp(_currentSize - 1);
            }

            public TKey Peek()
            {
                if (_currentSize == 0)
                {
                    throw new InvalidOperationException("Cannot peek when the heap is empty.");
                }

                return _items[0];
            }

            public TKey RemoveMax()
            {
                if (_currentSize == 0)
                {
                    throw new InvalidOperationException("Cannot remove when the heap is empty.");
                }

                TKey min = _items[0];
                Swap(0, _currentSize - 1);
                _currentSize--;
                BubbleDown(0);

                return min;
            }

            public IEnumerator<TKey> GetEnumerator()
            {
                for (int i = 0; i < _currentSize; i++)
                {
                    yield return _items[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private void BubbleUp(int index)
            {
                while (CompareAndSwapWithParentIfNecessary(index))
                {
                    index = GetParentIndex(index);
                }
            }

            private void BubbleDown(int index)
            {
                if (!HasChildren(index))
                {
                    return;
                }

                int bestChildIndex = GetBestChildIndex(index);
                if (CompareAndSwapWithParentIfNecessary(bestChildIndex))
                {
                    BubbleDown(bestChildIndex);
                }
            }

            private bool CompareAndSwapWithParentIfNecessary(int childIndex)
            {
                if (childIndex == 0)
                {
                    return false;
                }

                int parentIndex = GetParentIndex(childIndex);
                if (GetBestIndex(parentIndex, childIndex) == childIndex)
                {
                    Swap(parentIndex, childIndex);
                    return true;
                }
                return false;
            }

            private int GetBestIndex(int index1, int index2)
            {
                bool item1IsBetter = _items[index1].CompareTo(_items[index2]) > 0;
                return item1IsBetter ? index1 : index2;
            }

            private int GetBestChildIndex(int parentIndex)
            {
                int leftChildIndex = GetLeftChildIndex(parentIndex);
                int rightChildIndex = GetRightChildIndex(parentIndex);

                if (ItemExists(rightChildIndex))
                {
                    return GetBestIndex(leftChildIndex, rightChildIndex);
                }

                return leftChildIndex;
            }

            private bool HasChildren(int index)
            {
                return ItemExists(GetLeftChildIndex(index));
            }

            private bool ItemExists(int index)
            {
                return index < _currentSize;
            }

            private void Swap(int index1, int index2)
            {
                TKey temp = _items[index1];
                _items[index1] = _items[index2];
                _items[index2] = temp;
            }

            private int GetParentIndex(int childIndex)
            {
                return (childIndex - 1) / 2;
            }

            private int GetLeftChildIndex(int parentIndex)
            {
                return 2 * parentIndex + 1;
            }

            private int GetRightChildIndex(int parentIndex)
            {
                return 2 * parentIndex + 2;
            }
        }
    }
}
