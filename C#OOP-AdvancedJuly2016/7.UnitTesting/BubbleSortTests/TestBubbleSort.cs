namespace BubbleSortTests
{
    using BubbleSort;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class TestBubbleSort
    {
        private Bubble bubble;
        private List<int> collection;

        [TestInitialize]
        public void Initialize()
        {
            this.collection = new List<int>();
            this.bubble = new Bubble();
        }

        [TestMethod]
        public void TestShouldSortCollectionInAscendingOrder()
        {
            this.collection = new List<int>() {40, 2, 5, 15, 17, 4, 3, 1, 56, 19, 20, 44 };
            var sortedCollection = bubble.Sort(collection);
            this.collection.Sort();
            CollectionAssert.AreEqual(this.collection, sortedCollection);
        }
        
    }
}
