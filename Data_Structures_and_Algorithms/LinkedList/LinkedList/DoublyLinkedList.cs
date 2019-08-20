using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class DoublyLinkedList<T>
    {
        public int Counter { get;  private set; }
        public bool IsEmpty => Counter == 0;

        public DoublyLinkedNode<T> Head { get; private set; }
        public DoublyLinkedNode<T> Tail { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedNode<T>(value));
        }

        private void AddFirst(DoublyLinkedNode<T> node)
        {
            //save off the head
            DoublyLinkedNode<T> temp = Head;
            //points head to node
            Head = node;

            //insert rest of list behind the head
            Head.Next = temp;

            if(IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                //update previous refrence of the former head
                temp.Previous = Head;
            }
            Counter++;
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedNode<T>(value));
        }
        //adds to the last part of the doubly linked list. if its empty head and tail are the node
        //else we need to set tail to the next node. node previous is now tail
        //and now our tail is the node itself.
        private void AddLast(DoublyLinkedNode<T> node)
        {
            if(IsEmpty)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                //just sets the tail next to the node. 
                //previous was old tail
                //new tail is the node
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            Counter++;
        }

        //head is now head next decrement. simple edge cases if its empty afterwards
        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            //shift head
            Head = Head.Next;
            Counter--;

            if (IsEmpty)
                Tail = null;
            else
                Head.Previous = null;
        }
        //removes if counter is 1 head and tail become null
        //else we get the next pointer from the previous tails link and null it
        //afterwards we then set the tail to tail previous
        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if(Counter == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Previous.Next = null;
                Tail = Tail.Previous; //shift the tail (now it is former node)
            }
            Counter--;
        }

    }
}
