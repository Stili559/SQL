namespace ImplementLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LinkedList<T>
    {
        public class Node<T>
        {
            public T Element { get; set; }

            public Node Next { get; set; }

            public Node(T el, Node next = null)
            {
                Element = el;
                Next = next;
            }
        }
        private Node head;
        private Node tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Add(T item)
        {
            Node element = new Node(item);

            if (head == null)
            {
                head = element;
                tail = element;
                count++;
            }
            else
            {
                Node current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = element;
            }
        }

        public int Remove(T item)
        {
            Node current = head;
            Node previous = null;

            int countIndexes = 0;
            bool isFound = false;
            while (current.Next != null)
            {
                if (current.Element.Equals(item))
                {
                    isFound = true;
                    break;
                }

                previous = current;
                current = current.Next;
                countIndexes++;
            }

            if (countIndexes == 0)
            {
                head = current.Next;
                count--;
            }
            else if (tail.Element.Equals(item))
            {
                previous.Next = null;
                tail = previous;
                countIndexes = count - 1;
                count--;
            }
            else if (isFound)
            {
                previous.Next = current.Next;
                count--;
            }
            else
            {
                countIndexes = -1;
            }
            if (count == 0)
            {
                head = null;
                tail = null;
            }

            return countIndexes;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                return new ArgumentOutOfRangeException("invalid index: " + index);
            }

            int currentIndex = 0;

            Node currentNode = head;
            Node previous = null;

            while (currentIndex < index)
            {
                previous = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            count--;

            if (count == 0)
                head = tail = null;
            else if (previous == null)
                head = currentNode.Next;
            else
                previous.Next = currentNode.Next;

            return currentNode.Element;
        }
        public int IndexOf(object item)
        {
            Node current = head;
            int currentIndex = 0;

            while(current.Next != null)
            {
                if (current.Element.Equals(item))
                {
                    return currentIndex;
                }

                current = current.Next;
                currentIndex++;
            }
            return -1;
        }

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            if(index != -1)
            {
                return true;
            }

            return false;
        }

        public T this[int index]
        {
            get
            {
                if(index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                Node currentNode = this.head;
                for(int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Element;
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                Node currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Element = value;
            }
        }     

        public int Count { get => count; set => count = value; }


    }
}