using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class SinglyLinkedList<T>
    {
        private bool IsEmpty => Count == 0;
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public int Count { get; private set; }

        //public reference addFirst
        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }
        //private addFirst with implementation
        private void AddFirst(Node<T> node)
        {
            //save off current head
            Node<T> tmp = Head;

            Head = node;
            //shifts former head
            Head.Next = tmp;

            Count++;

            if(Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        // if the list is empty we add node to head and increment
        //else we add it to the tail. then set tail equal to node. increment post
        private void AddLast(Node<T> node)
        {
           if(IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            Count++;
        }

        //checks if empty, else we set head equal to next item, if the count is one we also need to set tail to null. decrement
        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;
            if (Count == 1)
                Tail = null;
            Count--;
        }

        //removes from end. checks if empty if our count is 1 head and tail are nulled
        //else we set a current var to the head. iterate through the list
        //post that we set current.next to null and the tail to current.
        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if(Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                var current = Head;
                while(current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
                Count--;
            }
        }
    }
}
