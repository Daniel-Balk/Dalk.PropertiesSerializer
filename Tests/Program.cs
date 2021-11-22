// import the serializer classes
using Dalk.PropertiesSerializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunTestCode();
        }
        internal void RunTestCode()
        {
            string properties = File.ReadAllText("test.properties");
            var @object = Serializer.Deserialize<TestObject>(properties);
            properties = Serializer.Serialize(@object);
            Serializer.LoadTypeSerializersFromAssembly(Assembly.GetAssembly(GetType()));
            Serializer.AddCustomTypeSerializer(new TestTypeSerializer());
        }
    }
}