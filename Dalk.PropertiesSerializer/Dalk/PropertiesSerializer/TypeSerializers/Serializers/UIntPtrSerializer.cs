using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class UIntPtrSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return UIntPtr.Parse(o);
        }

        readonly Type type = typeof(UIntPtr);
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
