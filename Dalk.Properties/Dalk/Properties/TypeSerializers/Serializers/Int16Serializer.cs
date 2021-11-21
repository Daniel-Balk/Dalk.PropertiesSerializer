using System;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class Int16Serializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return Int16.Parse(o);
        }

        readonly Type type = typeof(Int16);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return ((Int16)o).ToString();
        }
    }
}