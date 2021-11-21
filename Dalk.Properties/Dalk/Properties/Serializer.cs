﻿using Dalk.Properties.TypeSerializers;
using System;
using System.Collections.Generic;

namespace Dalk.Properties
{
    /// <summary>
    /// a class with serializing and deserializing properties
    /// </summary>
    public static class Serializer
    {
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
                var nm = c.Name;
                var attrs = c.GetCustomAttributes(typeof(PropertyNameAttribute), true);
                foreach (var a in attrs)
                {
                    try
                    {
                        if (a is PropertyNameAttribute na)
                        {
                            nm = na.Name;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
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
            Dictionary<string, string> kvps = new();
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
                    var nm = c.Name;
                    var attrs = c.GetCustomAttributes(typeof(PropertyNameAttribute), true);
                    foreach (var a in attrs)
                    {
                        try
                        {
                            if (a is PropertyNameAttribute na)
                            {
                                nm = na.Name;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    var snm = name + "." + nm;
                    var sval = "";
                    if (kvps.ContainsKey(snm))
                    {
                        sval = kvps[snm];
                    }
                    var deserialize = SerialRegistry.Deserialize(sval,c.PropertyType, out var can);
                    if (can)
                    {
                        c.SetValue(o, deserialize);
                    }
                    else
                    {
                        c.SetValue(o, GetSubProperty(c.PropertyType, nm));
                    }
                }
                return o;
            }

            var propertyValues = instance.GetType().GetProperties();
            foreach (var c in propertyValues)
            {
                var nm = c.Name;
                var attrs = c.GetCustomAttributes(typeof(PropertyNameAttribute),true);
                foreach (var a in attrs)
                {
                    try
                    {
                        if (a is PropertyNameAttribute na)
                        {
                            nm = na.Name;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                var sval = "";
                if (kvps.ContainsKey(nm))
                {
                    sval = kvps[nm];
                }
                var deserialize = SerialRegistry.Deserialize(sval,c.PropertyType, out var can);
                if (can)
                {
                    c.SetValue(instance, deserialize);
                }
                else
                {
                    c.SetValue(instance, GetSubProperty(c.PropertyType, nm));
                }
            }


            return instance;
        }
    }
}
