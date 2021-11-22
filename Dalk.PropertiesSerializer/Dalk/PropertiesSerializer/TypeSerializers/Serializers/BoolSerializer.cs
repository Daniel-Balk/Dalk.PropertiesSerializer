using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class BoolSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return bool.Parse(o);
        }

        readonly Type type = typeof(bool);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return o.ToString().ToLower();
        }
    }
}
