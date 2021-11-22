using System;

namespace Dalk.PropertiesSerializer
{
    /// <summary>
    /// Attribute for setting custom names for properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class PropertyNameAttribute : Attribute
    {
        readonly string positionalString;
        /// <summary>
        /// constructor for setting the properties name
        /// </summary>
        /// <param name="name">name in serialized string</param>
        public PropertyNameAttribute(string name)
        {
            positionalString = name;
        }
        internal string Name
        {
            get { return positionalString; }
        }
    }
}
