﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dalk.Properties.TypeSerializers
{
    internal static class SerialRegistry
    {
        public static List<ITypeSerializer> Serializers { get; set; } = new();
        static bool su = false;
        private static void Setup()
        {
            if (!su)
            {
                var asm = Assembly.GetAssembly(typeof(SerialRegistry));
                foreach (var t in asm.GetTypes())
                {
                    var tst = t.GetCustomAttributes(typeof(TypeSerializerAttribute));
                    if (tst != null)
                    {
                        var ts = tst.ToList();
                        if (ts.Count > 0)
                        {
                            var o = Activator.CreateInstance(t);
                            Serializers.Add((ITypeSerializer)o);
                        }
                    }
                }
                su = true;
            }
        }
        public static string Serialize(string name, object o, out bool can)
        {
            Setup();
            ITypeSerializer ser = null;
            foreach (var v in Serializers)
            {
                if (o.GetType() == v.GetCType())
                    ser = v;
            }
            if(ser == null)
            {
                can = false;
                return "";
            }
            else
            {
                can = true;
                return name + "=" + ser.Serialize(o);
            }
        }
        public static object Deserialize(string o, Type t, out bool can)
        {
            Setup();
            ITypeSerializer ser = null;
            foreach (var v in Serializers)
            {
                if (t == v.GetCType())
                    ser = v;
            }
            if(ser == null)
            {
                can = false;
                return "";
            }
            else
            {
                can = true;
                return ser.Deserialize(o);
            }
        }
    }
}
