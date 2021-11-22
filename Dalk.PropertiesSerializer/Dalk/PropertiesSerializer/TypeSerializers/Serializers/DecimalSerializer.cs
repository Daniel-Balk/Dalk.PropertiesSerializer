using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class DecimalSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return decimal.Parse(o);
        }

        readonly Type type = typeof(decimal);
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
