// import the serializer classes
using Dalk.PropertiesSerializer;
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
            var @object = Serializer.Deserialize<TestObject>(File.ReadAllText("test.properties"));
            var properties = Serializer.Serialize(@object);
        }
    }
}