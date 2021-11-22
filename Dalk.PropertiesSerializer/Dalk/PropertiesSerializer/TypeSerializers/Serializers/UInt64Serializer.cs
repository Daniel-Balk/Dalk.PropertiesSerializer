using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class UInt64Serializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return UInt64.Parse(o);
        }

        readonly Type type = typeof(UInt64);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return ((UInt64)o).ToString();
        }
    }
}