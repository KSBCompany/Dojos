using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    class ExceptionTestClass
    {
        public static void ThisMethodThrowsAnException()
        {
            throw new Exception("I throw this Exception for testing purpose");
        }
    }
}
