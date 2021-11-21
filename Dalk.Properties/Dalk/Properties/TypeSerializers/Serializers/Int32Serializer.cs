using System;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class Int32Serializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return Int32.Parse(o);
        }

        readonly Type type = typeof(Int32);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return ((Int32)o).ToString();
        }
    }
}