using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Queues
{
    class QueueLinkedList
    {
       
        public class LinkedQueue<T> : IEnumerable<T>
        {

            private readonly LinkedList.SinglyLinkedList<T> _list = new LinkedList.SinglyLinkedList<T>();
            public int Count => _list.Count;
            public bool IsEmpty => Count == 0;
            public void Enqueue(T item)
            {
                _list.AddLast(item);
            }

            public void Dequeue()
            {
                if (IsEmpty)
                    throw new InvalidOperationException();

                _list.RemoveFirst();
            }

            public T Peek()
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return _list.Head.Value;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _list.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
