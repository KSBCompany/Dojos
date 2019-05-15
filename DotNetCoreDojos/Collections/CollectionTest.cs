using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Collection
{
    public class CollectionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AllElementsOfAMustBeAvailableInB()
        {
            List<string> a = new List<string>() { "a", "b", "c", "d"};
            List<string> b = new List<string>() { "c", "d", "e", "f"};

            var result = b.FindAll(element => a.IndexOf(element) == -1);


            var resultWithLinq = from element in b
                                 where a.IndexOf(element) == -1
                                 select element.ToList();

        }
    }


}