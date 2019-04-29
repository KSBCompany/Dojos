using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency
{
    class ConcurrencyTestClass
    {
        public static async Task<string> LoadSomethingFromRemoteResourceMock(int sleepSeconds)
        {
            string waitForThisString = await Task.Run<string>(() => 
            {
                for(int i = 0; i < sleepSeconds; i++)
                {
                    System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " Loop-Number " + i);
                    Thread.Sleep(1000);
                }
                
                return "Loading finished.";
            });

            return waitForThisString;
        }
    }
}
