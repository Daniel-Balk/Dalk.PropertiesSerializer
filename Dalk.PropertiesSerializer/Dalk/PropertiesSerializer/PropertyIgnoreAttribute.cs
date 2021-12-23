using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalk.PropertiesSerializer
{
    /// <summary>
    /// Attribute to ignore properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class PropertyIgnoreAttribute : Attribute
    {
        /// <summary>
        /// should it be ignored
        /// </summary>
        internal bool Ignore { get; set; }
        /// <summary>
        /// contstructor to set ignore
        /// </summary>
        /// <param name="ignore">should ignore</param>
        public PropertyIgnoreAttribute(bool ignore)
        {
            Ignore = ignore;
        }
        
        /// <summary>
        /// constructor to ignore
        /// </summary>
        public PropertyIgnoreAttribute()
        {
            Ignore = true;
        }
    }
}
