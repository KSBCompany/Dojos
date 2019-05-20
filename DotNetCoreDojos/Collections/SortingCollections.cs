using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GenFu;
using DotNetCoreDojos;

namespace Collection
{
    public class SortingCollections
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Sorting1()
        {
            var people = A.ListOf<Person>();

            var ages = from current in people
                       select current.Age;

            people.Sort((x, y) => x.Age.CompareTo(y.Age));
        }
    }


}