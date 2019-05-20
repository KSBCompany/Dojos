using NUnit.Framework;
using GenFu;
using AutoMapper;

namespace Automapper
{
    public class Automapper
    {
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceClass1, DestinationClass1>();
            });
            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            mapper = configuration.CreateMapper();
        }

        [Test]
        public void AutomapperTest1()
        {
            SourceClass1 source = A.New<SourceClass1>();

            var destination = mapper.Map<DestinationClass1>(source);
        }

        [Test]
        public void AutomapperTest2()
        {
            SourceClass1 source = A.New<SourceClass1>();

            var destination = mapper.Map<DestinationClass1>(source);
        }
    }


    public class SourceClass1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class DestinationClass1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}