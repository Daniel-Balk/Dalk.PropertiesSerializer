using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class IntPtrSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return IntPtr.Parse(o);
        }

        readonly Type type = typeof(IntPtr);
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
