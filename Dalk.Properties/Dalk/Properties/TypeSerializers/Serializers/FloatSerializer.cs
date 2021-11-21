using System;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class FloadSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return float.Parse(o);
        }

        readonly Type type = typeof(float);
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
