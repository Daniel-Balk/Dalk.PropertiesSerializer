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
            Program p = new();
            p.RunTestCode();
        }
        internal void RunTestCode()
        {
            //File.WriteAllText("test.cs",  properties2csharp.ClassGenerator.Generate(File.ReadAllText("test.properties"),"TestClass"));
            string properties = File.ReadAllText("test.properties");
            var @object = Serializer.Deserialize<TestObject>(properties);
            //var @object = new TestObject();
            Console.WriteLine(@object.TestString);
            //properties = Serializer.Serialize(@object);
            //Console.WriteLine(properties);
            //Serializer.LoadTypeSerializersFromAssembly(Assembly.GetAssembly(GetType()));
            //Serializer.AddCustomTypeSerializer(new TestTypeSerializer());
        }
    }
}