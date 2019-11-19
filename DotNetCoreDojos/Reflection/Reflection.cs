using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Reflection
{
    public class Reflection
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReflectionTest()
        {
            List<MyValue> storage = new List<MyValue>();

            storage.Add(new MyValue() { Name= "Head", Value= 42});
            storage.Add(new MyValue() { Name = "Flow", Value = 1337 });

            CalculationHydraulicPower calc = new CalculationHydraulicPower(storage);

            calc.ExecuteCalculation();

        }

    }

    class CalculationHydraulicPower
    {
        double input_Head { get; set; }
        double input_Flow { get; set; }

        private double output_power;


        List<MyValue> storage;

        public CalculationHydraulicPower(List<MyValue> storage)
        {
            this.storage = storage;
        }

        public void ExecuteCalculation()
        {
            Type type = typeof(CalculationHydraulicPower);

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if(property.Name.Contains("input_"))
                {
                    string variableName = property.Name.Substring(property.Name.LastIndexOf("_") + 1);

                    var result = (from current in storage
                                  where current.Name == variableName
                                  select current.Value).First();

                    property.SetValue(this, result);
                }
            }

            storage.Add(new MyValue() { Name = "Phyd", Value = 42 * input_Flow * input_Head });
        }
    }

    class MyValue
    {
        public string Name { get; set; }

        public double Value { get; set; }
    }
}