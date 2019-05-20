using DotNetCoreDojos;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Linq;

namespace CSharpSpecificTests
{
    public class Comparison
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CompareObjects()
        {
            Person a = new Person() { FirstName = "Alice", Age = 20 };
            Person a1 = a;

            Person b = new Person() { FirstName = "Bob", Age = 30 };

            Person identicalToA = new Person() { FirstName = "Alice", Age = 20 };


            Assert.IsTrue(a == a1);
            Assert.IsFalse(a == b);

            Assert.IsTrue(a.Equals(identicalToA));
        }
    }


}