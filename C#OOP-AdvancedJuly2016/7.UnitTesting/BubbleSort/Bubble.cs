namespace BubbleSort
{
    using System.Collections.Generic;

    public class Bubble
    {
        public List<int> Sort(List<int> collection)
        {
            for (int i = collection.Count - 1; i > 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (collection[j] > collection[j + 1])
                    {
                        int temp = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = temp;
                    }
                }
            }

            return collection;
        }
    }
}
