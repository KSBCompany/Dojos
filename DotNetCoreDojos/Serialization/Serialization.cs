using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Serialization
{

    /// <summary>
    /// The class "SerializeThisClass" must be serialized.
    /// But not the list inside the object must be returned.
    /// Only the count of the elements should be returned.
    /// </summary>
    public class CustomJSONSerialization_SerializeElementsInArrayNotTheArray
    {
        [SetUp]
        public void Setup()
        {
        }

        [JsonConverter(typeof(MySpecialSerializer))]
        class SerializeThisClass
        {
            public string _Name;
            public List<int> _ListOfNumbers;
        }

        //NoSpecialSerializer
        class SerializeThisClassAlternative
        {
            public string _Name;

            [JsonIgnore]
            public List<int> _ListOfNumbers;

            public int QueueCount
            {
                get { return _ListOfNumbers.Count; }
            }

        }

        [Test]
        public void CustomSerializerTest()
        {
            SerializeThisClass testObj1 = new SerializeThisClass() { _Name = "a1", _ListOfNumbers = new List<int>() { 1, 2, 3, 4, 5 } };
            SerializeThisClass testObj2 = new SerializeThisClass() { _Name = "a2", _ListOfNumbers = new List<int>() { 7, 8, 9 } };

            List<SerializeThisClass> myList = new List<SerializeThisClass>();
            myList.Add(testObj1);
            myList.Add(testObj2);


            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(myList);
        }

        [Test]
        public void CustomSerializerTestAlternative()
        {
            SerializeThisClassAlternative testObj1 = new SerializeThisClassAlternative() { _Name = "a1", _ListOfNumbers = new List<int>() { 1, 2, 3, 4, 5 } };
            SerializeThisClassAlternative testObj2 = new SerializeThisClassAlternative() { _Name = "a2", _ListOfNumbers = new List<int>() { 7, 8, 9 } };

            List<SerializeThisClassAlternative> myList = new List<SerializeThisClassAlternative>();
            myList.Add(testObj1);
            myList.Add(testObj2);


            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(myList);
        }

        public class MySpecialSerializer : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(SerializeThisClass).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var myObj = value as SerializeThisClass;

                writer.WriteStartObject();

                writer.WritePropertyName("NumberOfElementsInQueue");
                writer.WriteValue(myObj._ListOfNumbers.Count);

                writer.WritePropertyName("_Name");
                writer.WriteValue(myObj._Name);

                writer.WriteEndObject();
            }
        }
    }


}