using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class UInt16Serializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return UInt16.Parse(o);
        }

        readonly Type type = typeof(UInt16);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return ((UInt16)o).ToString();
        }
    }
}