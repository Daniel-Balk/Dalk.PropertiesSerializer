using System;

namespace Dalk.PropertiesSerializer.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class DateTimeSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return DateTime.Parse(o);
        }

        readonly Type type = typeof(DateTime);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return ((DateTime)o).ToString();
        }
    }
}
