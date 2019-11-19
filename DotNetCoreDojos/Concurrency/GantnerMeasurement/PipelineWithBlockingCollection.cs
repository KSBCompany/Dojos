using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DotNetCoreDojos.Concurrency.GantnerMeasurement;


//https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/how-to-use-arrays-of-blockingcollections

namespace Concurrency
{
    public class PipelineWithBlockingCollection
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StartExample()
        {
            Measurement Gantner = new Measurement();

            Gantner.start();
        }
    }
}