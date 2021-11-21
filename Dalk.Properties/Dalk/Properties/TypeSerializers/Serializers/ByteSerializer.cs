using System;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class ByteSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return byte.Parse(o);
        }

        readonly Type type = typeof(byte);
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
