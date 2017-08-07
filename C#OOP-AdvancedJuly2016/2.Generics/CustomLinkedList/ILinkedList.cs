namespace CustomLinkedList
{
    interface ILinkedList<T>
    {
        void Add(T element);
        void RemoveFirst(T element);
        bool Contains(T element);
        void Swap(int index, int index2);
        int CountGreaterThan(T element);
        T Max();
        T Min();
    }
}
