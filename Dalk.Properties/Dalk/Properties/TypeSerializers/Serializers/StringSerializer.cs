using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalk.Properties.TypeSerializers.Serializers
{
    [TypeSerializer]
    internal class StringSerializer : ITypeSerializer
    {
        public object Deserialize(string o)
        {
            return o;
        }

        readonly Type type = typeof(string);
        public Type GetCType()
        {
            return type;
        }

        public string Serialize(object o)
        {
            return (string)o;
        }
    }
}
