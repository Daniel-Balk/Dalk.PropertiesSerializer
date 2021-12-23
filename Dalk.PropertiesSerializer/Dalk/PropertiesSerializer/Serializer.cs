using Dalk.PropertiesSerializer.TypeSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dalk.PropertiesSerializer
{
    /// <summary>
    /// a class with serializing and deserializing properties
    /// </summary>
    public static class Serializer
    {
        private static void IgnoreAndName(out bool ignore, out string name, PropertyInfo c)
        {
            var iignore = false;
            c.GetAccessors(true).ToList().ForEach(x =>
            {
                if(x.IsStatic)
                    iignore = true;
            });
            if (!c.CanWrite)
                iignore = true;
            var iname = c.Name;
            var attrs1 = c.GetCustomAttributes(typeof(PropertyNameAttribute), true);
            var attrs2 = c.GetCustomAttributes(typeof(PropertyIgnoreAttribute), true);
            var attrs = attrs1.Concat(attrs2).ToList();
            foreach (var a in attrs)
            {
                try
                {
                    if (a is PropertyNameAttribute na)
                    {
                        iname = na.Name;
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (a is PropertyIgnoreAttribute ia)
                    {
                        if (ia.Ignore)
                            iignore = true;
                    }
                }
                catch (Exception)
                {

                }
            }

            ignore = iignore;
            name = iname;
        }
        /// <summary>
        /// serialize an object to a properties string
        /// </summary>
        /// <param name="o">object to serialize</param>
        /// <returns>the object serialized as a string</returns>
        public static string Serialize(object o)
        {
            string prt = "";
            void Add(string l)
            {
                prt += l + "\n";
            }
            var propertyValues = o.GetType().GetProperties();
            foreach (var c in propertyValues)
            {
                IgnoreAndName(out bool ignore, out string nm, c);
                if (!ignore)
                {
                    var vl = c.GetValue(o);
                    var ln = SerialRegistry.Serialize(nm, vl, out bool can);
                    if (can)
                    {
                        Add(ln);
                    }
                    else
                    {
                        var t = Serialize(vl);
                        var lns = AddPrefix(t, nm + ".");
                        Add(lns);
                    }
                }
            }


            prt = prt.Remove(prt.Length - 1);
            return prt;
        }

        private static string AddPrefix(string t, string nm)
        {
            string prt = "";
            void Add(string l)
            {
                prt += l + "\n";
            }
            foreach (var ln in t.Split('\n'))
            {
                Add(nm + ln);
            }

            prt = prt.Remove(prt.Length - 1);
            return prt;
        }

        /// <summary>
        /// deserializes from a string to an object
        /// </summary>
        /// <typeparam name="T">type of the object</typeparam>
        /// <param name="properties">string to deserialize</param>
        /// <returns>deserialized string as T</returns>
        public static T Deserialize<T>(string properties)
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            var prop = properties.Replace("\r\n", "\n");
            var lines = prop.Split('\n');
            Dictionary<string, string> kvps = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("#"))
                {

                }
                else if (string.IsNullOrWhiteSpace(line))
                {

                }
                else if (!line.Contains("="))
                {

                }
                else
                {
                    var eqp = line.IndexOf('=');
                    var key = line.Remove(eqp);
                    var value = line.Remove(0, eqp + 1);
                    kvps[key] = value;
                }
            }

            object GetSubProperty(Type t, string name)
            {
                var o = Activator.CreateInstance(t);
                var propertyValues = t.GetProperties();
                foreach (var c in propertyValues)
                {
                    IgnoreAndName(out bool ignore, out string nm, c);

                    if (!ignore)
                        try
                        {
                            var snm = name + "." + nm;
                            var sval = "";
                            if (kvps.ContainsKey(snm))
                            {
                                sval = kvps[snm];
                            }
                            var deserialize = SerialRegistry.Deserialize(sval, c.PropertyType, out var can);
                            if (can)
                            {
                                c.SetValue(o, deserialize);
                            }
                            else
                            {
                                c.SetValue(o, GetSubProperty(c.PropertyType, nm));
                            }
                        }
                        catch (Exception)
                        {

                        }
                }
                return o;
            }

            var propertyValuesx = instance.GetType().GetProperties();
            foreach (var c in propertyValuesx)
            {
                IgnoreAndName(out bool ignore, out string nm, c);
                if (!ignore)
                    try
                    {
                        var sval = "";
                        if (kvps.ContainsKey(nm))
                        {
                            sval = kvps[nm];
                        }
                        var deserialize = SerialRegistry.Deserialize(sval, c.PropertyType, out var can);
                        if (can)
                        {
                            c.SetValue(instance, deserialize);
                        }
                        else
                        {
                            c.SetValue(instance, GetSubProperty(c.PropertyType, nm));
                        }
                    }
                    catch (Exception)
                    {

                    }
            }


            return instance;
        }

        /// <summary>
        /// scans an assembly for type serializers
        /// </summary>
        /// <param name="asm">assembly to scan</param>
        public static void LoadTypeSerializersFromAssembly(Assembly asm) => SerialRegistry.LoadTypeSerializersFromAssembly(asm);

        /// <summary>
        /// adds a type serializer to the serializers
        /// </summary>
        /// <param name="serializer">type serializer to add</param>
        public static void AddCustomTypeSerializer(ITypeSerializer serializer) => SerialRegistry.AddSerializer(serializer);
    }
}
