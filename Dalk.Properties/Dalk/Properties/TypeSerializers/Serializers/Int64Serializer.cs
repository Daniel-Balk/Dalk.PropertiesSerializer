using System;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class Int64Serializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return Int64.Parse(o);
        }

        readonly Type type = typeof(Int64);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return ((Int64)o).ToString();
        }
    }
}