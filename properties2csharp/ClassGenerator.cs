using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace properties2csharp
{
    public static class ClassGenerator
    {
        public static Configuration Configuration { get; set; } = new();
        public static string Generate(string propertiesInput, string name)
        {
            string GenForTp(string properties, string nm)
            {
                string s = "";
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
                List<GenProperty> props = new();
                Dictionary<string, string> customTypes = new();
                string GetName(string b)
                {
                    var r = new StringBuilder(b);
                    r[0] = r[0].ToString().ToUpper().ToCharArray()[0];
                    while (r.ToString().Contains("_"))
                    {
                        var i = r.ToString().IndexOf('_');
                        r[i + 1] = r[i + 1].ToString().ToUpper().ToCharArray()[0];
                        r.Remove(i, 1);
                    }
                    return r.ToString();
                }
                Regex ints = new(@"^[0-9]+$");
                string GetType(string val)
                {
                    string r = Configuration.ObjectType;
                    if (ints.Match(val).Success)
                        r = Configuration.NumberType;
                    if (val.ToLower() == "true")
                        r = "bool";
                    if (val.ToLower() == "false")
                        r = "bool";
                    return r;
                }
                void AddLineAsProp(KeyValuePair<string, string> ln)
                {
                    GenProperty prop = new()
                    {
                        Name = ln.Key,
                        PropertyName = GetName(ln.Key),
                        Type = GetType(ln.Value)
                    };
                    props.Add(prop);
                }
                string AsStr(Dictionary<string, string> d)
                {
                    string str = "";
                    foreach (var kvp in d)
                    {
                        str += kvp.Key + "=" + kvp.Value + "\n";
                    }
                    str = str.Remove(str.Length - 1);
                    return str;
                }
                void AddLineAsPropWithTypeName(KeyValuePair<string, string> ln, string tn)
                {
                    GenProperty prop = new()
                    {
                        Name = ln.Key,
                        PropertyName = GetName(ln.Key),
                        Type = tn
                    };
                    props.Add(prop);
                }
                foreach (var l in kvps)
                {
                    var k = l.Key;
                    if (k.Contains('.'))
                    {
                        int i = k.IndexOf('.');
                        var tns = k.Remove(i);
                        var tn = GetName(tns);
                        CollectStarting(kvps, tns + ".", out var use, out var _);
                        if (!customTypes.ContainsKey(tn))
                        {
                            customTypes[tn] = GenForTp(AsStr(use), tn);
                            AddLineAsPropWithTypeName(new KeyValuePair<string, string>(tns, ""), tn);
                        }
                    }
                    else
                    {
                        AddLineAsProp(l);
                    }
                }
                s += $"public class {nm}\n";
                s += "{\n";
                foreach (var p in props)
                {
                    if (p.Name != p.PropertyName)
                        s += $"    [PropertyName(\"{p.Name}\")]\n";
                    s += $"    public {p.Type} {p.PropertyName} ";
                    s += "{ get; set; }\n\n";
                }
                s += "}\n";

                foreach (var c in customTypes)
                {
                    s += c.Value + "\n";
                }
                return s;
            }
            return "using Dalk.PropertiesSerializer;\n\n" + GenForTp(propertiesInput, name);
        }


        private static void CollectStarting(Dictionary<string, string> dict, string startString, out Dictionary<string, string> starting, out Dictionary<string, string> other)
        {
            Dictionary<string, string> st = new();
            Dictionary<string, string> ot = new();
            foreach (var c in dict)
            {
                if (c.Key.StartsWith(startString))
                {
                    st.Add(c.Key.Remove(0, startString.Length), c.Value);
                }
                else
                {
                    ot.Add(c.Key, c.Value);
                }
            }
            starting = st;
            other = ot;
        }
    }
}
