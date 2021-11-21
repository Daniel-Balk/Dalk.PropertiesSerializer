using Dalk.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var properties = Serializer.Serialize(new TestObject());
            var @object = Serializer.Deserialize<TestObject>(File.ReadAllText("test.properties"));
            Console.WriteLine(@object.TestString);
        }
    }
}