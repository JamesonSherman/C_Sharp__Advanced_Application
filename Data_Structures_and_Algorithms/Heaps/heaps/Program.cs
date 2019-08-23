using System;
using System.Collections.Generic;
/*
 * insert O(log(n)) 
 * remove max\min O(log(n))
 * peek O(1)
 * 
 * */
namespace heaps
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] heap;
        public int Count { get; private set; }
        public bool IsFull => Count == heap.Length;
        public bool IsEmpty => Count == 0;

        public void Insert(T value)
        {
            if(IsFull)
            {
                var newHeap = new T[heap.Length * 2];
                Array.Copy(sourceArray: heap, sourceIndex: 0, destinationArray: newHeap, destinationIndex: 0,length: heap.Length);
                heap = newHeap;

            }
            heap[Count] = value;
            Swim(Count);

            Count++;
        }

        //pushes values up in the array
        private void Swim(int IndexofSwimmingItem)
        {
            T newValue = heap[IndexofSwimmingItem];
            while(IndexofSwimmingItem > 0 && IsParentLess(IndexofSwimmingItem))
            {
                heap[IndexofSwimmingItem] = GetParent(IndexofSwimmingItem);
                IndexofSwimmingItem = ParentIndex(IndexofSwimmingItem);
            }
            heap[IndexofSwimmingItem] = newValue;

            bool IsParentLess(int swimmingItemIndex)
            {
                return newValue.CompareTo(GetParent(swimmingItemIndex)) > 0;
            }
        }

        public IEnumerable<T> Values()
        {
            for(var i = 0; i <Count; i++)
            {
                yield return heap[i];
            }
        }

        private T GetParent(int index)
        {
            return heap[ParentIndex(index)];
        }

        private int ParentIndex (int index)
        {
            return (index - 1) / 2;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return heap[0];
        }

        //removes root value
        public T Remove()
        {
            return Remove(0);
        }

        public T Remove(int index)
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            T removedVal = heap[index];
            heap[index] = heap[Count - 1];
            if (index == 0 || heap[index].CompareTo(GetParent(index)) < 0)
            {
                Sink(index,Count-1);
            }
            else
            {
                Swim(index);
            }

            Count--;
            return removedVal;
        }

        

        private int LeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        private int RightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private void Exchange(int leftIndex, int rightIndex)
        {
            T tmp = heap[leftIndex];
            heap[leftIndex] = heap[rightIndex];
            heap[rightIndex] = tmp;
        }

        public MaxHeap():this(DefaultCapacity)
        {

        }

        private MaxHeap(int capacity)
        {
            heap = new T[capacity];
        }


        //pushes values down in array to bottom
        private void Sink(int indexofSinkingItem, int lastHeapIndex)
        {
            while (indexofSinkingItem <= lastHeapIndex)
            {
                int leftChildIndex = LeftChildIndex(indexofSinkingItem);
                int rightChildIndex = RightChildIndex(indexofSinkingItem);

                if (leftChildIndex > lastHeapIndex)
                    break;

                int childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);
                if (SinkingIsLessThan(childIndexToSwap))
                {
                    Exchange(indexofSinkingItem, childIndexToSwap);
                }
                else
                {
                    break;
                }
                indexofSinkingItem = childIndexToSwap;
            }

            bool SinkingIsLessThan(int childToSwap)
            {
                return heap[indexofSinkingItem].CompareTo(heap[childToSwap]) < 0;
            }



            int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex)
            {
                int childToSwap;
                if (rightChildIndex > lastHeapIndex)
                {
                    childToSwap = leftChildIndex;
                }
                else
                {
                    int compareTo = heap[leftChildIndex].CompareTo(heap[rightChildIndex]);

                    childToSwap = (compareTo > 0 ? leftChildIndex : rightChildIndex);
                }

                return childToSwap;
            }
        }


        //heap sort
        public void Sort()
        {
            int lastHeapIndex = Count - 1;
            for(int i = 0; i <lastHeapIndex; i++)
            {
                Exchange(0, lastHeapIndex - i);
                Sink(0, lastHeapIndex - i - 1);
            }
        }
    }
}
