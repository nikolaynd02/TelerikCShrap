using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackQueueWorkshop.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] items;
        private T top;

        public int Size
        {
            get
            {
                if(items == null)
                {
                    return 0;
                }
                return items.Length;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if(items == null)
                {
                    return true;
                }
                return items.Length == 0;
            }
        }

        public void Push(T element)
        {
            T[] newItems = new T[Size + 1];
            newItems[0] = element;
            for(int i = 1; i <= Size; i++)
            {
                newItems[i] = items[i - 1];
            }
            items = newItems;
            top = element;
        }

        public T Pop()
        {
            if (items == null)
            {
                throw new InvalidOperationException();
            }
            if (items.Length == 0)
            {
                throw new InvalidOperationException();
            }

            T result = top;
            T[] newItems = new T[Size - 1];

            for(int i = 1;i < Size; i++)
            {
                newItems[i - 1] = items[i];
            }

            items = newItems;
            top = items[0];
            return result;
        }

        public T Peek()
        {
            if (items == null)
            {
                throw new InvalidOperationException();
            }
            if(items.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return top;
        }
    }
}
