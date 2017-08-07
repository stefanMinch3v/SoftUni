using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLinkedList
{
    public class LinkedList<T> : ILinkedList<T>, IEnumerable<T> where T: IComparable<T>
    {

        public Node<T> head;
        public Node<T> tail;
        private int count;

        public LinkedList()
        {
            this.count = 0;
        }

        public void Add(T element)
        {
            if (count == 0)
            {
                head = new Node<T>(element);
            }
            else if (count == 1)
            {
                tail = new Node<T>(element);
                head.next = tail;
                tail.previous = head;
            }
            else
            {
                Node<T> current = new Node<T>(element);
                tail.next = current;
                current.previous = tail;
                tail = current;
            }
            count++;
        }

        public bool Contains(T element)
        {
            foreach (var item in this)
            {
                if (item.CompareTo(element) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;
            foreach (var el in this)
            {
                if (el.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public T Max()
        {
            T max = head.value;
            foreach (var item in this)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public T Min()
        {
            T min = head.value;
            foreach (var item in this)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public void RemoveFirst(T element)
        {
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.value.CompareTo(element) == 0)
                {
                    currentNode.previous.next = currentNode.next;
                    currentNode.next.previous = currentNode.previous;
                    currentNode.next = null;
                    currentNode.previous = null;
                    count--;
                    break;
                }

                currentNode = currentNode.next;

            }
           
        }

        public void Swap(int index, int index2)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                yield return currentNode.value;
                currentNode = currentNode.next;
            }
        }

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }
}
