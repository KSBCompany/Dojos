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
            List<string> a = new List<string>() { "c", "d"};
            List<string> b = new List<string>() { "c", "d", "e", "f"};

            var result = b.FindAll(element => a.Contains(element));


            var resultWithLinq = from element in b
                                 where a.Contains(element)
                                 select element.ToList();

        }
    }


}