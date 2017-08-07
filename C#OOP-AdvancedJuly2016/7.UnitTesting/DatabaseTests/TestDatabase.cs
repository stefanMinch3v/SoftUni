namespace DatabaseTests
{
    using Database;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class TestDatabase
    {
        DatabaseClass dbTestObject;

        [TestInitialize]
        public void TestInitialize()
        {
            dbTestObject = new DatabaseClass(new int[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void TestDBCapacity()
        {
            Assert.AreEqual(16, dbTestObject.Capacity, "DB capacity is not 16");
        }

        [TestMethod]
        public void TestDatabaseCapacity()
        {
            Assert.AreEqual(16, dbTestObject.Capacity);
        }

        [TestMethod]
        public void TestDatabaseCount()
        {
            //Arrange
            int counter = 0;
            //Act
            for (int i = 0; i < dbTestObject.Numbers.Length; i++)
            {
                if (dbTestObject.Numbers[i] != 0)
                {
                    counter++;
                }
            }
            //Assert
            Assert.AreEqual(counter, dbTestObject.Count);
        }

        [TestMethod]
        public void TestConstructorForValidParamethers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            dbTestObject = new DatabaseClass(numbers);
            CollectionAssert.AreEqual(numbers, dbTestObject.Numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestConstructorWithMoreParamethersThanMaxCapacity()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            dbTestObject = new DatabaseClass(numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestAddMoreElementsThanMaxCapacity()
        {
            for (int i = 0; i < 20; i++)
            {
                dbTestObject.Add(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemoveFromEmptyPositions()
        {
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
        }

        [TestMethod]
        public void TestConstructorCurrentParamethers()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, dbTestObject.Numbers);
        }

        [TestMethod]
        public void TestAddOneElement()
        {
            dbTestObject.Add(55);
            Assert.AreEqual(55, dbTestObject.Numbers[dbTestObject.Count - 1]);
        }

        [TestMethod]
        public void TestCountOfAddedSeveralElements()
        {
            dbTestObject.Add(2);
            dbTestObject.Add(145);
            dbTestObject.Add(11);
            dbTestObject.Add(127);
            Assert.AreEqual(9, dbTestObject.Count);
        }

        [TestMethod]
        public void TestRemoveOneElement()
        {
            dbTestObject.Remove();
            Assert.AreEqual(4, dbTestObject.Count);
        }

        [TestMethod]
        public void TestRemoveSeveralElements()
        {
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
            Assert.AreEqual(2, dbTestObject.Count);
        }

        [TestMethod]
        public void TestExactlySixteenElements()
        {
            List<int> expected = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            for (int i = 0; i < 11; i++)
            {
                dbTestObject.Add(i);
                expected.Add(i);
            }

            CollectionAssert.AreEqual(expected, dbTestObject.Numbers);
        }
    }
}
