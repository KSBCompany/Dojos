using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace PumpTest
{
    public class DataStructureTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FilterMeasurementsByLabel()
        {
            List<Measurement> measurements = new List<Measurement>();

            var newMeasurement = new Measurement() { Name = "first" };
            newMeasurement.labels.Add("labelA");
            newMeasurement.labels.Add("labelB");

            measurements.Add(newMeasurement);

            newMeasurement = new Measurement() { Name = "second" };
            newMeasurement.labels.Add("tiger");
            newMeasurement.labels.Add("bird");

            measurements.Add(newMeasurement);

            newMeasurement = new Measurement() { Name = "third" };
            newMeasurement.labels.Add("labelC");
            newMeasurement.labels.Add("labelD");

            measurements.Add(newMeasurement);

            var filteredMeasurements = from current in measurements
                                       where current.labels.Contains("tiger")
                                       select current;


        }
    }



    class Project
    {
        public string Name { get; set; }
    }

    class Measurement : ILabelable
    {
        public string Name { get; set; }

        public List<string> labels = new List<string>();

        public IEnumerable<string> GetLabels()
        {
            throw new System.NotImplementedException();
        }
    }

    interface ILabelable
    {
        IEnumerable<string> GetLabels();
    }


}