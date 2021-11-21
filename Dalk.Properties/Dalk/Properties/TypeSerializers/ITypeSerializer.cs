using System;

namespace Dalk.Properties.TypeSerializers
{
    internal interface ITypeSerializer
    {
        Type GetCType();
        string Serialize(object o);
        object Deserialize(string o);
    }
}