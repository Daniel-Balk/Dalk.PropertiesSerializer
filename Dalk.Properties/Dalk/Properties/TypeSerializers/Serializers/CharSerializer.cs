using System;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class CharSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return char.Parse(o);
        }

        readonly Type type = typeof(char);
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
