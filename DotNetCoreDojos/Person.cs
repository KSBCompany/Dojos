using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreDojos
{
    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Person other = (Person)obj;

            return (Age == other.Age && FirstName == other.FirstName);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
    }
}
