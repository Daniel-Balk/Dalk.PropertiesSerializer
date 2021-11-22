using TestType = System.Int32;
using System;
using Dalk.PropertiesSerializer.TypeSerializers;

[TypeSerializer]
public class TestTypeSerializer : ITypeSerializer
{
    public object Deserialize(string o) => TestType.Parse(o);

    Type type = typeof(TestType);
    public Type GetCType() => type;

    public string Serialize(object o) => o.ToString();
}