using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace Queues
{
    class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _head;
        private int _tail;
        public int Count => _tail - _head;
        //lambda expression for creation an instance of count if it is empty
        public bool IsEmpty => Count == 0;

        //peeks at head item of queue
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            return _queue[_head];
        }

        //first constructor for default capacity and setting the queue
        // the inital capacity is set to 4
        public ArrayQueue()
        {
            const int defaultCapacity = 4;
            _queue = new T[defaultCapacity];
        }

        // update of capacity setting queue to a new capacity
        public ArrayQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        // enqueue items
        public void Enqueue(T item)
        {
            //checks if the length is at current max capacity
            //if so we then increase size of the queue by count* 2
            //copy values and set our queue equal to larger queue
            if(_queue.Length == _tail)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_queue, largerArray, Count);
                _queue = largerArray;
            }
            //afterwards we set our item to the now newly allocated new size
            _queue[_tail++] = item;
        }

      

        //dequeues ALL items
        public void Dequeue()
        {
            //our head check if the queue is empty
            if (IsEmpty)
                throw new InvalidOperationException();
            //sets the default head to a default unassigned value (our ADT)
            _queue[_head++] = default(T);

            //if is empty is true then head and tail go to zero
            if (IsEmpty)
                _head = _tail = 0;
        }


        //enumration definition that yields all queue values
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = _head; i <_tail; i++)
            {
                yield return _queue[i];
            }
        }

        //IEnumerator constructor for calling GetEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
