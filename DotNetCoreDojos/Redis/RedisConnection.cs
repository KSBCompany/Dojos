using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Threading;

namespace Redis
{
    public class RedisConnectionTest
    {
        [SetUp]
        public void Setup()
        {
            // DockerClient client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();

            
        }


        /// <summary>
        /// The test only works if a redis is available. This can be started with a docker run command:
        /// docker run --name dojoredis -p 6379:6379 -d redis
        /// </summary>
        [Test]
        public void ConnectToRedisStoreValueAndLoadItAgain()
        {
            ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost:6379");

            IDatabase db = multiplexer.GetDatabase();

            string testkey = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();
            string testvalue = DateTime.Now.ToLongTimeString();

            db.StringSet(testkey, testvalue);

            string result = db.StringGet(testkey);

            Assert.Fail();
        }

        /// <summary>
        /// The test only works if a redis is available. This can be started with a docker run command:
        /// docker run --name dojoredis -p 6379:6379 -d redis
        /// </summary>
        [Test]
        public void ConnectToRedisStoreValueWithExpireTimeAndLoadItAgainAfterTheValueIsExpired()
        {
            ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost:6379");

            IDatabase db = multiplexer.GetDatabase();

            string testkey = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();
            string testvalue = DateTime.Now.ToLongTimeString();

            db.StringSet(testkey, testvalue, new TimeSpan(0, 0, 5));

            Thread.Sleep(4000);

            // Here The value is available, because the lifetime is 5s and only 4s are elapsed.
            var resultBeforeLifetimeIsExpired = db.StringGet(testkey);

            Thread.Sleep(2000);

            // Here The value is not available, because the lifetime is 5s and in sum 6s are elapsed.
            var resultAfterLifetimeIsExpired = db.StringGet(testkey);

            Assert.IsTrue(resultBeforeLifetimeIsExpired.HasValue);

            Assert.IsFalse(resultAfterLifetimeIsExpired.HasValue);
        }

        /// <summary>
        /// The test only works if a redis is available. This can be started with a docker run command:
        /// docker run --name dojoredis -p 6379:6379 -d redis
        /// 
        /// Start a portainer container and watch the statistics (memory, CPU-usage and NetWork)
        /// You should see that the memory an cache value increase to approx. 750MB.
        /// After 60 seconds the values decrease, because redis clease the expired data.
        /// </summary>
        [Test]
        public void TestWithALotOfData()
        {
            ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost:6379");

            IDatabase db = multiplexer.GetDatabase();

            string testkey = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();
            string testvalue = DateTime.Now.ToLongTimeString();


            for (int i = 0; i < 50000; i++)
            {
                // Store a big string
                db.StringSet(i.ToString(), @"suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf
                                            suhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslfsuhdfkjshndfkjsafdsjfdsndfsnfsjdflsjfdljslf"
                        , new TimeSpan(0, 0, 60));

            }

            //On my machine it took 50s to get here.
            int testbreakpoint = 1337;
        }
    }
}