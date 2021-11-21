using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalk.Properties.TypeSerializers
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    internal sealed class TypeSerializerAttribute : Attribute
    {
        public TypeSerializerAttribute()
        {
        }
    }
}
