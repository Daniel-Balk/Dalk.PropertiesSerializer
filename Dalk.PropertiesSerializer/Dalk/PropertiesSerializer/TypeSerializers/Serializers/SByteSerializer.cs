using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class SByteSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return sbyte.Parse(o);
        }

        readonly Type type = typeof(sbyte);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return o.ToString();
        }
    }
}
