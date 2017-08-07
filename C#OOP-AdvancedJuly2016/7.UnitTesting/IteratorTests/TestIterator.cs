namespace IteratorTests
{
    using IteratorExercise;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class TestIterator
    {
        private ListIterator listIterator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.listIterator = new ListIterator();
        }

        [TestMethod]
        public void TestConstructorWithValidNonEmptyParamethers()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho" };
            this.listIterator = new ListIterator(expected);
            CollectionAssert.AreEqual(expected, this.listIterator.Elements, "The given collection are not equal");
        }

        [TestMethod]
        public void TestConstructorWithEmptyCollection()
        {
            List<string> expected = new List<string>();
            this.listIterator = new ListIterator(expected);
            Assert.AreEqual(0, this.listIterator.Elements.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorWithNullCollectionShouldThrowException()
        {
            List<string> expected = new List<string>(null);
            this.listIterator = new ListIterator(expected);
        }

        [TestMethod]
        public void TestOneMoveWithTwoElements()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho" };
            this.listIterator = new ListIterator(expected);
            bool hasMoved = this.listIterator.Move();
            Assert.IsTrue(hasMoved);
        }

        [TestMethod]
        public void TestTwoMovesWithTwoElementsShouldReturnFalse()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho" };
            this.listIterator = new ListIterator(expected);
            this.listIterator.Move();
            bool hasMoved = this.listIterator.Move();
            Assert.IsFalse(hasMoved);
        }

        [TestMethod]
        public void TestOneMoveShouldReturnInternalIndexOne()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho" };
            this.listIterator = new ListIterator(expected);

            int beforeMove = this.listIterator.CurrentIndex;
            this.listIterator.Move();
            int afterMove = this.listIterator.CurrentIndex;

            Assert.AreEqual(0, beforeMove);
            Assert.AreEqual(1, afterMove);
        }

        [TestMethod]
        public void TestTwoMovesShouldReturnInternalIndexTwo()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho", "Ivan" };
            this.listIterator = new ListIterator(expected);

            int beforeMove = this.listIterator.CurrentIndex;
            this.listIterator.Move();
            this.listIterator.Move();
            int afterMove = this.listIterator.CurrentIndex;

            Assert.AreEqual(0, beforeMove);
            Assert.AreEqual(2, afterMove);
        }

        [TestMethod]
        public void TestHasNextWithoutMoveWithTwoElements()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho" };
            this.listIterator = new ListIterator(expected);

            bool hasNext = listIterator.HasNext();
            Assert.IsTrue(hasNext);
        }

        [TestMethod]
        public void TestHasNextWithoutMoveWithOneElementShouldReturnFalse()
        {
            List<string> expected = new List<string>() { "Pesho"};
            this.listIterator = new ListIterator(expected);

            bool hasNext = listIterator.HasNext();
            Assert.IsFalse(hasNext);
        }

        [TestMethod]
        public void TestPrintWithoutMoveShouldReturnZeroElement()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho" };
            this.listIterator = new ListIterator(expected);

            string result = this.listIterator.Print();
            Assert.AreEqual(expected[0], result, "Print doesn't return the desired element!");
        }

        [TestMethod]
        public void TestPrintWithOneMoveShouldReturnFirstElement()
        {
            List<string> expected = new List<string>() { "Pesho", "Gosho" };
            this.listIterator = new ListIterator(expected);
            this.listIterator.Move();
            string result = this.listIterator.Print();
            Assert.AreEqual(expected[1], result, "Print doesn't return the desired element!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPrintOnEmptyCollectionShouldThrowException()
        {
            List<string> expected = new List<string>();
            this.listIterator = new ListIterator(expected);

            string result = this.listIterator.Print();
        }
    }
}
