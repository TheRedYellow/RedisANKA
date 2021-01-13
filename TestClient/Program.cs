
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace TestClient
{
    class Program
    {

        static void Main(string[] args)
        {
            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints =
                {
                    { "redis0", 6379 },
                    { "redis1", 6380 }
                },
                //CommandMap = CommandMap.Create(new HashSet<string>
                //    { // EXCLUDE a few commands
                //        "INFO", "CONFIG", "CLUSTER",
                //        "PING", "ECHO", "CLIENT"
                //    }, available: false),
                KeepAlive = 180,
                Password = ""
            };

            var conn = ConnectionMultiplexer.Connect(config);

            IDatabase db = conn.GetDatabase();
            db.StringSet("name","danko");

            Console.ReadKey();

        }
    }
}
