using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace StackQueueWorkshop.Queue
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> head, tail;
        private int size;

        public int Size
        {
            get
            {
                return size;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return size == 0;
            }
        }

        public void Enqueue(T element)
        {
            var node = new Node<T>();
            node.Data = element;

            if (tail == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            size++;
            //var newTail = new Node<T>();
            //newTail.Data = element;

            //var oldTailData = tail.Data;

            //tail = new Node<T>();
            //tail.Data = oldTailData;
            //tail.Next = newTail;
            //size++;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }

            T result = head.Data;

            head = head.Next;

            size--;
            return result;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }
            return head.Data;
        }
    }
}
