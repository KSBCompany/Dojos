using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreDojos.LINQ
{
    public class LinqTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SelectAllPropB1()
        {
            LinqTestClassA A1 = new LinqTestClassA()
            {
                PropA1 = 1,
                PropA2 = new LinqTestClassB()
                {
                    PropB1 = 11,
                    PropB2 = "A1PropB2"
                }
            };

            LinqTestClassA A2 = new LinqTestClassA()
            {
                PropA1 = 2,
                PropA2 = new LinqTestClassB()
                {
                    PropB1 = 22,
                    PropB2 = "A2PropB2"
                }
            };

            LinqTestClassA A3 = new LinqTestClassA()
            {
                PropA1 = 3,
                PropA2 = new LinqTestClassB()
                {
                    PropB1 = 33,
                    PropB2 = "A3PropB2"
                }
            };

            IList<LinqTestClassA> collectionA = new List<LinqTestClassA>();
            collectionA.Add(A1);
            collectionA.Add(A2);
            collectionA.Add(A3);

            var result = from test in collectionA
                          select test.PropA2.PropB2;

        }


        /// <summary>
        /// This demonstrates how a subset of a list can be changed with LINQ.
        /// We create a list of elements of a class which has a bool and a int value.
        /// We want to select only the elements where the bool value is true.
        /// Then we want to iterate over the result and change all values.
        /// With this test, we can see that it is possible to select parts of a list and work with that part.
        /// The changes are then in the original list.
        /// </summary>
        [Test]
        public void UpdateSpecificElements()
        {
            List<BoolIntClass> completeList = new List<BoolIntClass>()
            {
                new BoolIntClass(){boolVal = true, intVal = 1},
                new BoolIntClass(){boolVal = false, intVal = 2},
                new BoolIntClass(){boolVal = true, intVal = 3}
            };

            var filteredList = from current in completeList
                               where current.boolVal
                               select current;

            foreach(var currentListElement in filteredList)
            {
                currentListElement.intVal *= 10;
            }

            Assert.AreEqual(10, completeList[0].intVal);
            Assert.AreEqual(2, completeList[1].intVal);
            Assert.AreEqual(30, completeList[2].intVal);
        }


        /// <summary>
        /// Like the example before, but now the subset of the list must be updated by another list.
        /// This only works when a class is selected. Please see the difference with the next test.
        /// </summary>
        [Test]
        public void UpdateSpecificElementsFromAnotherList()
        {
            List<BoolIntClass> completeList = new List<BoolIntClass>()
            {
                new BoolIntClass(){boolVal = true, intVal = 1},
                new BoolIntClass(){boolVal = false, intVal = 2},
                new BoolIntClass(){boolVal = true, intVal = 3}
            };

            List<int> updatedValues = new List<int>()
            {
                1337,
                42
            };


            var filtered = from current in completeList
                               where current.boolVal
                               select current;

            var FilteredList = filtered.ToList();

            for(int i = 0; i < FilteredList.Count; i++)
            {
                FilteredList[i].intVal = updatedValues[i];
            }

            Assert.AreEqual(1337, completeList[0].intVal);
            Assert.AreEqual(2, completeList[1].intVal);
            Assert.AreEqual(42, completeList[2].intVal);
        }

        /// <summary>
        /// In this test we select the integers in the class. Then the original values are not updated!
        /// </summary>
        [Test]
        public void UpdateSpecificElementsFromAnotherList_ValueType()
        {
            List<BoolIntClass> completeList = new List<BoolIntClass>()
            {
                new BoolIntClass(){boolVal = true, intVal = 1},
                new BoolIntClass(){boolVal = false, intVal = 2},
                new BoolIntClass(){boolVal = true, intVal = 3}
            };

            List<int> updatedValues = new List<int>()
            {
                1337,
                42
            };


            var filtered = from current in completeList
                           where current.boolVal
                           select current.intVal;

            var FilteredList = filtered.ToList();

            for (int i = 0; i < FilteredList.Count; i++)
            {
                FilteredList[i] = updatedValues[i];
            }

            Assert.AreEqual(1, completeList[0].intVal);
            Assert.AreEqual(2, completeList[1].intVal);
            Assert.AreEqual(3, completeList[2].intVal);
        }


        class BoolIntClass
        {
            public bool boolVal { get; set; }
            public int intVal { get; set; }
        }
    }


}