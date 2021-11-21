using System;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class DoubleSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return double.Parse(o);
        }

        readonly Type type = typeof(double);
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
