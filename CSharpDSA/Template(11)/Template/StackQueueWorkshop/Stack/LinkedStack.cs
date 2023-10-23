using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Stack
{
    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> top;
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

        public void Push(T element)
        {
            var newNode = new Node<T>();
            newNode.Data = element;
            newNode.Next = top;
            size++;
            top = newNode;
        }

        public T Pop()
        {
            if(size == 0)
            {
                throw new InvalidOperationException();
            }
            var newTop = top.Next;
            var result = top.Data;
            top = newTop;
            size--;
            return result;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }
            return top.Data;
        }
    }
}
