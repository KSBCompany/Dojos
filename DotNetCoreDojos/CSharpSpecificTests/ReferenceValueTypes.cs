using NUnit.Framework;
using System.Collections.Concurrent;
using System.Linq;

namespace CSharpSpecificTests
{
    public class ReferenceValueTypes
    {
        [SetUp]
        public void Setup()
        {
        }

        /// Classes are reference types (like pointers) to objects on the heap.
        [Test]
        public void ExampleReferenceType()
        {
            Student a = new Student() { Age = 1, Name = "StudentA" };

            Student b = a;

            Assert.AreEqual("StudentA", b.Name);

            b.Name = "StudentB";

            Assert.AreEqual("StudentB", a.Name);

            Change(a);

            Assert.AreEqual("Superman", b.Name);
        }

        /// Structs are value types.
        [Test]
        public void ExampleValueType()
        {
            StudentStruct a = new StudentStruct() { Age = 1, Name = "StudentA" };

            StudentStruct b = a;

            Assert.AreEqual("StudentA", b.Name);

            b.Name = "StudentB";

            //See the difference to the class example!
            Assert.AreEqual("StudentA", a.Name);

            //See the difference to the class example!
            Change(a);

            //See the difference to the class example!
            Assert.AreEqual("StudentA", a.Name);
        }

        [Test]
        public void ExampleValueType_integer()
        {
            int i = 1;

            Change(i);

            Assert.AreEqual(1, i);

            Change(ref i);

            Assert.AreEqual(2, i);
        }


        /// <summary>
        /// String is a reference type (string are in heap and immutable)
        /// In heap because of size (stack is limited)
        /// Immutable behause of multithreading.
        /// </summary>
        [Test]
        public void Example_string()
        {
            string orig = "orig";

            Change(orig);

            Assert.AreEqual("orig", orig);
        }

        public void Change(Student s)
        {
            s.Age = 100;
            s.Name = "Superman";
        }

        public void Change(StudentStruct s)
        {
            s.Age = 100;
            s.Name = "Superman";
        }

        public void Change(int i)
        {
            i = 2;
        }

        public void Change(ref int i)
        {
            i = 2;
        }

        public void Change(string str)
        {
            str = "changed";
        }


        public class Student
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        public struct StudentStruct
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }


}