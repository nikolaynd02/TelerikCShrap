using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] items;
        private T tail;

        public int Size
        {
            get
            {
                if (items == null)
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
                if (items == null)
                {
                    return true;
                }
                return items.Length == 0;
            }
        }

        public void Enqueue(T element)
        {
            var newItems = new T[Size + 1];
            newItems[newItems.Length - 1] = element;
            for(var i = 0; i < Size; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
            tail = element;
        }

        public T Dequeue()
        {
            if (items == null)
            {
                throw new InvalidOperationException();
            }
            if (items.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var newItems = new T[Size - 1];
            var result = items[0];

            for(var i = 1;i < Size; i++)
            {
                newItems[i-1] = items[i];
            }
            items = newItems;
            return result;
        }

        public T Peek()
        {
            if (items == null)
            {
                throw new InvalidOperationException();
            }
            if (items.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return items[0];
        }
    }
}
