using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Queues
{
    class CircularQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        public int Count => head <= tail ? tail - head : tail - head + _queue.Length;
        private int head;
        private int tail;
        public bool IsEmpty => Count == 0;
        public int Capacity => _queue.Length;

        public CircularQueue()
        {
            const int defaultCapacity = 4;
            _queue = new T[defaultCapacity];
        }

        public CircularQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if(Count == _queue.Length -1)
            {
                int countPriorResize = Count;
                T[] newArray = new T[2 * _queue.Length];
                Array.Copy(_queue, head, newArray, 0, _queue.Length - head);
                Array.Copy(_queue, 0, newArray, _queue.Length - head, tail);
                _queue = newArray;
                head = 0;
                tail = countPriorResize;
            }
            _queue[tail] = item;
            if(tail < _queue.Length -1)
            {
                tail++;
            }
            else
            {
                tail = 0;
            }
        }

        public void Dequeue()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException();
            }

            _queue[head++] = default(T);

            if(IsEmpty)
            {
                head = tail = 0;
            }
            else if (head == _queue.Length)
            {
                head = 0;
            }
        }
        public T Peek()
        {

            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return _queue[head];

        }
        public IEnumerator<T> GetEnumerator()
        {
            if(head <= tail)
            {
                for(int i = head; i < tail; i++)
                {
                    yield return _queue[i];
                }
            }
            else
            {
                for(int i = head; i < _queue.Length; i++)
                {
                    yield return _queue[i];
                }

                for (int i = 0; i < tail; i++)
                {
                    yield return _queue[i];
                }

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
