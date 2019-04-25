using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Threading;

namespace Exceptions
{
    public class ExceptionsBasics
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ThrowAnExceptionAndCatchIt()
        {
            try
            {
                ExceptionTestClass.ThisMethodThrowsAnException();
            }
            catch(Exception e)
            {
                int DoICatchTheException1 = 1;
            }
            catch
            {
                int DoICatchTheException2 = 1;
            }
            finally
            {
                int AtTheEndThisIsExecuted = 1;
            }
        }
    }
}