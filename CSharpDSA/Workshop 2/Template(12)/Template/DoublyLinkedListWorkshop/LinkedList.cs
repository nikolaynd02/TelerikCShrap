using System;
using System.Collections;

namespace DoublyLinkedListWorkshop
{
    public class LinkedList<T> : IList<T>
    {
        private Node head;
        private Node tail;
        private int size;

        public T Head
        {
            get
            {
                if(head == null)
                {
                    throw new InvalidOperationException();
                }
                return head.Value;
            }
        }

        public T Tail
        {
            get
            {
                if(tail == null)
                {
                    throw new InvalidOperationException();
                }
                return tail.Value;
            }
        }

        public int Count
        {
            get
            {
                return size;
            }
            private set
            {
                size = value;
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new Node(value);

            if(head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                head.Prev = null;
            }
            size++;
        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);
            
            if(tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
                //tail.Next = null;
            }
            size++;
        }

        public void Add(int index, T value)
        {
            var newNode = new Node(value);

            var currentNode = head;

            if(size == index)
            {
                AddLast(value); 
                return;
            }

            if(index >= size || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            for(int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            newNode.Prev = currentNode.Prev;
            newNode.Next = currentNode;

            currentNode.Prev = newNode;

            newNode.Prev.Next = newNode;
            newNode.Next = currentNode;
            size++;
        }

        public T Get(int index)
        {
            if (index >= size || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;
        }

        public int IndexOf(T value)
        {           
            var currentNode = head;

            int indexCounter = 0;

            if (currentNode is null)
            {
                return -1;
            }
            do
            {
                if (currentNode.Value.Equals(value))
                {
                    return indexCounter;
                }
                indexCounter++;
                currentNode = currentNode.Next;

            } while (currentNode is not null);

            return -1;
        }

        public T RemoveFirst()
        {
            if(size == 0)
            {
                throw new InvalidOperationException();
            }

            T result = head.Value;

            head = head.Next;
            
            
            //head.Prev = null;

            size--;

            if(size == 0)
            {
                head = null;
                tail = null;
            }

            return result;
        }

        public T RemoveLast()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }

            T result = tail.Value;

            tail = tail.Prev;

            size--;

            tail.Next = null;

            if (size == 0)
            {
                head = null;
                tail = null;
            }

            return result;
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new ListEnumerator(this.head);
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        // Use private nested class so that LinkedList users
        // don't know about the LinkedList internal structure
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value
            {
                get;
                private set;
            }

            public Node Next
            {
                get;
                set;
            }

            public Node Prev
            {
                get;
                set;
            }
        }

        // List enumerator that enables traversing all nodes of a list in a foreach loop
        private class ListEnumerator : System.Collections.Generic.IEnumerator<T>
        {
            private Node start;
            private Node current;

            internal ListEnumerator(Node head)
            {
                this.start = head;
                this.current = null;
            }

            public T Current
            {
                get
                {
                    if (this.current == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return this.current.Value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = this.start;
                    return true;
                }

                if (current.Next == null)
                {
                    return false;
                }

                current = current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = null;
            }
        }
    }
}