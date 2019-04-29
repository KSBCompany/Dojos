using NUnit.Framework;
using System.Collections.Concurrent;
using System.Linq;

namespace CSharpSpecificTests
{
    public class ConcurrentQueueTest
    {
        [SetUp]
        public void Setup()
        {
        }


        /// <summary>
        /// Write a lot of strings with "aaaa" into queue.
        /// Write one string with "bbbb" into queue
        /// </summary>
        [Test]
        public void CheckIfAnElementIsAlreadyInTheQueue()
        {
            ConcurrentQueue<string> concurrentQueue = new ConcurrentQueue<string>();

            string a = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string b = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

            for (int i = 0; i < 20000; i++)
            {
                concurrentQueue.Enqueue(a);
            }

            concurrentQueue.Enqueue(b);

            for (int i = 0; i < 20000; i++)
            {
                concurrentQueue.Enqueue(a);
            }

            bool found = concurrentQueue.Any(element => element == b);

            Assert.IsTrue(found);
        }
    }


}