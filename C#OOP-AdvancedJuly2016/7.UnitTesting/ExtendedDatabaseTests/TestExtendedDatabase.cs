namespace ExtendedDatabaseTests
{
    using ExtendedDatabase;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class TestExtendedDatabase
    {
        ExtendedDatabaseClass dbTestObject;

        [TestInitialize]
        public void TestInitialize()
        {
            this.dbTestObject = new ExtendedDatabaseClass(new Person[]
            {
                new Person("Pesho", 55),
                new Person("Gosho", 45),
                new Person("Ivan", 46)
            });
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
            for (int i = 0; i < dbTestObject.Persons.Length; i++)
            {
                if (dbTestObject.Persons[i] != null)
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
            Person[] expectedPersons = new Person[]
            {
                new Person("Gosho", 11),
                new Person("Pesho", 41)
            };

            dbTestObject = new ExtendedDatabaseClass(expectedPersons);
            CollectionAssert.AreEqual(expectedPersons, dbTestObject.Persons);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestConstructorWithMoreParamethersThanMaxCapacityShouldThrowException()
        {
            dbTestObject = new ExtendedDatabaseClass(new Person[]
            {
                new Person("Gosho", 1),
                new Person("Gosho1", 2),
                new Person("Gosho2", 3),
                new Person("Gosho3", 4),
                new Person("Gosho4", 5),
                new Person("Gosho5", 6),
                new Person("Gosho6", 7),
                new Person("Gosho7", 8),
                new Person("Gosho8", 9),
                new Person("Gosho9", 10),
                new Person("Gosho10", 11),
                new Person("Gosho11", 12),
                new Person("Gosho12", 13),
                new Person("Gosho13", 14),
                new Person("Gosho14", 15),
                new Person("Gosho15", 16),
                new Person("Gosho16", 17),
            });
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestAddMoreElementsThanMaxCapacityShouldThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                dbTestObject.Add(new Person($"Ivan{i}", i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemoveFromEmptyPositionsShouldThrowException()
        {
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
        }

        [TestMethod]
        public void TestConstructorCurrentParamethers()
        {
            CollectionAssert.AreEqual(new Person[] 
            {
                new Person("Pesho", 55),
                new Person("Gosho", 45),
                new Person("Ivan", 46)
            },
            dbTestObject.Persons);
        }

        [TestMethod]
        public void TestAddOneElement()
        {
            var person = new Person("Peshev", 235);
            dbTestObject.Add(person);
            Assert.AreEqual(person, dbTestObject.Persons[dbTestObject.Count - 1]);
        }

        [TestMethod]
        public void TestCountOfAddedSeveralElements()
        {
            dbTestObject.Add(new Person("Peshev", 2315));
            dbTestObject.Add(new Person("Peshev2", 2135));
            dbTestObject.Add(new Person("Peshev3", 4235));
            dbTestObject.Add(new Person("Peshev4", 6235));
            Assert.AreEqual(7, dbTestObject.Count);
        }

        [TestMethod]
        public void TestRemoveOneElement()
        {
            dbTestObject.Remove();
            Assert.AreEqual(2, dbTestObject.Count);
        }

        [TestMethod]
        public void TestRemoveSeveralElements()
        {
            dbTestObject.Remove();
            dbTestObject.Remove();
            dbTestObject.Remove();
            Assert.AreEqual(0, dbTestObject.Count);
        }

        [TestMethod]
        public void TestRemoveTwoElementsAndCompareTheExistingOne()
        {
            dbTestObject.Remove();
            dbTestObject.Remove();
            CollectionAssert.AreEqual(new Person[] {new Person("Pesho", 55) }, dbTestObject.Persons);
        }

        [TestMethod]
        public void TestExactlySixteenElements()
        {
            List<Person> expected = new List<Person>(new Person[] 
            {
                new Person("Pesho", 55),
                new Person("Gosho", 45),
                new Person("Ivan", 46)
            });
            for (int i = 0; i < 11; i++)
            {
                dbTestObject.Add(new Person($"Krasio{i}", i));
                expected.Add(new Person($"Krasio{i}", i));
            }

            CollectionAssert.AreEqual(expected, dbTestObject.Persons);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestForExistingUsernameShouldThrowException()
        {
            dbTestObject.Add(new Person("Gosho", 325));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestForExistingIdShouldThrowException()
        {
            dbTestObject.Add(new Person("Stamat", 46));
        }

        [TestMethod]
        public void TestFindByIdValidParamethers()
        {
            Person expected = new Person("Ivan", 46);
            Person actual = dbTestObject.FindById(46);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByIdThatDoesntExistSholdThrowException()
        {
            dbTestObject.FindById(834);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByIdNegativeIdShouldThrowException()
        {
            dbTestObject.FindById(-10);
        }

        [TestMethod]
        public void TestFindByUsernameValidParamethers()
        {
            Person expected = new Person("Gosho", 45);
            Person actual = dbTestObject.FindByUsername("Gosho");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByUsernameThatDoesntExistShouldThrowException()
        {
            dbTestObject.FindByUsername("Stamat");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByUsernameNullParameterShouldThrow()
        {
            dbTestObject.FindByUsername(null);
        }
    }
}
