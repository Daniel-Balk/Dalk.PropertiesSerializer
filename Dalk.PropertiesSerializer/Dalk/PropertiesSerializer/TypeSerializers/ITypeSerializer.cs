using System;

namespace Dalk.PropertiesSerializer.TypeSerializers
{
    /// <summary>
    /// interface for type serializers
    /// </summary>
    public interface ITypeSerializer
    {
        /// <summary>
        /// get the type the class serializes
        /// </summary>
        /// <returns>type the class serializes</returns>
        Type GetCType();
        /// <summary>
        /// serialize the object to a string
        /// </summary>
        /// <param name="o">object to serialize</param>
        /// <returns>object as a string</returns>
        string Serialize(object o);
        /// <summary>
        /// deserialize the string to an object
        /// </summary>
        /// <param name="o">string to deserialize</param>
        /// <returns>string as object of the type</returns>
        object Deserialize(string o);
    }
}