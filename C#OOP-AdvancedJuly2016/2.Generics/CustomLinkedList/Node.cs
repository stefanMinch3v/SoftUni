using System;

namespace CustomLinkedList
{
    public class Node<T> 
    {
        public T value;
        public Node<T> previous;
        public Node<T> next;

        public Node(T value)
        {
            this.value = value;
        }
    }
}
