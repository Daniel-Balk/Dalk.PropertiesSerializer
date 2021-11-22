using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class UInt32Serializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return UInt32.Parse(o);
        }

        readonly Type type = typeof(UInt32);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return ((UInt32)o).ToString();
        }
    }
}