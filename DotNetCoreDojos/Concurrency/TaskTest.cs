using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency
{
    public class TaskTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task StartTwoTasksAndWaitForTheLongerRunning()
        {
            var task1 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(10);
            var task2 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(5);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var response1Value = await task1;

            watch.Stop();


            System.Diagnostics.Debug.WriteLine("Waited for task1, therefore stopwatch measures 10000 -> " + watch.ElapsedMilliseconds);

            Assert.AreEqual(10000, watch.ElapsedMilliseconds, 50);

            //Both tasks are finished.
            Assert.IsTrue(task1.IsCompleted);
            Assert.IsTrue(task2.IsCompleted);
        }

        [Test]
        public async System.Threading.Tasks.Task StartTwoTasksAndWaitForTheOneWhoFinishesEarlier()
        {
            var task1 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(10);
            var task2 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(5);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var response2Value = await task2;

            watch.Stop();

            System.Diagnostics.Debug.WriteLine("Waited for task2, therefore stopwatch measures 5000s -> " + watch.ElapsedMilliseconds);

            Assert.AreEqual(5000, watch.ElapsedMilliseconds, 50);

            //Only task2 is finished, because we wait for it. Task1 needs 10s and isn´t finished.
            Assert.IsFalse(task1.IsCompleted);
            Assert.IsTrue(task2.IsCompleted);
        }


        /// <summary>
        /// Here no async method declaration is necessary, because no await is used.
        /// </summary>
        [Test]
        public void Add3TasksToListAndWaitForAll()
        {
            List<Task<string>> ListOfTasks = new List<Task<string>>();

            var task1 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(6);
            var task2 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(5);
            var task3 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(4);

            ListOfTasks.Add(task1);
            ListOfTasks.Add(task2);
            ListOfTasks.Add(task3);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Task.WaitAll(ListOfTasks.ToArray());

            watch.Stop();

            System.Diagnostics.Debug.WriteLine("The longest task takes 6 seconds, therefore stopwatch measures 6000s -> " + watch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Here we have several tasks. The longest is running 6s but we only wait 5,5 seconds.
        /// </summary>
        [Test]
        public void Add3TasksToListAndWaitForAll_ButOnlyWait5Seconds()
        {
            List<Task<string>> ListOfTasks = new List<Task<string>>();

            var task1 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(6);
            var task2 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(5);
            var task3 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(4);

            ListOfTasks.Add(task1);
            ListOfTasks.Add(task2);
            ListOfTasks.Add(task3);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Task.WaitAll(ListOfTasks.ToArray(), 5500);

            watch.Stop();

            Assert.IsFalse(task1.IsCompleted);
            Assert.IsTrue(task2.IsCompleted);
            Assert.IsTrue(task3.IsCompleted);
        }

        /// <summary>
        /// Wait for Tasks with different return types.
        /// In this example one task returns string the other int.
        /// </summary>
        [Test]
        public void TasksWithDifferentReturnTypes()
        {
            List<Task> ListOfTasks = new List<Task>();

            var task1 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock(1);
            var task2 = ConcurrencyTestClass.LoadSomethingFromRemoteResourceMock_ReturnInt(1);


            ListOfTasks.Add(task1);
            ListOfTasks.Add(task2);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Task.WaitAll(ListOfTasks.ToArray(), 2000);

            watch.Stop();

            //ListOfTasks[0].

            Assert.IsFalse(task1.IsCompleted);
            Assert.IsTrue(task2.IsCompleted);
        }

    }


}