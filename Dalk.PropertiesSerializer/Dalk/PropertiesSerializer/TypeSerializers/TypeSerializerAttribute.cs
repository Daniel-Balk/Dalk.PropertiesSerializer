using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalk.PropertiesSerializer.TypeSerializers
{
    /// <summary>
    /// attribute for marking a class as a type serializer
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class TypeSerializerAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public TypeSerializerAttribute()
        {
        }
    }
}
