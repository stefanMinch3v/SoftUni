using System;
using System.Collections.Generic;

namespace Database
{
    public class DatabaseClass
    {
        private const int MaxCapacity = 16;
        private int[] numbers;
        private int currentIndex;

        public DatabaseClass(int[] nums)
        {
            this.Numbers = nums;
        }

        public int[] Numbers
        {
            get
            {
                List<int> nums = new List<int>();
                for (int i = 0; i < this.currentIndex; i++)
                {
                    nums.Add(numbers[i]);
                }

                return nums.ToArray();
            }
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException("The collection must be between 1 and 16 elements!");
                }

                this.numbers = new int[MaxCapacity];

                for (int i = 0; i < value.Length; i++)
                {
                    this.numbers[i] = value[i];
                }

                this.currentIndex = value.Length;
            }
        }

        /// <summary>
        /// The length of the array (16 elements fixed!)
        /// </summary>
        public int Capacity { get { return MaxCapacity; } }

        /// <summary>
        /// The numbers of elements in the array out of 16
        /// </summary>
        public int Count { get { return this.currentIndex; } }

        public void Remove()
        {
            //numbers[numbers.Length - 1] = 0;
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.numbers[currentIndex] = 0;
            currentIndex--;
        }

        public void Add(int num)
        {
            if (this.currentIndex == MaxCapacity)
            {
                throw new IndexOutOfRangeException("You've reach the max capacity and cannot add more elements!");
            }

            this.numbers[currentIndex] = num;
            currentIndex++;
        }
    }
}
