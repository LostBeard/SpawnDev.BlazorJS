using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public static class MethodInfoExtension
    {
        static ulong CalculateHash(string read)
        {
            ulong hashedValue = 3074457345618258791ul;
            for (int i = 0; i < read.Length; i++)
            {
                hashedValue += read[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }
        public static ulong GetMethodSignatureHash(this MethodInfo _this)
        {
            var sig = _this.GetMethodSignature();
            var hash = CalculateHash(sig);
            return hash;
        }

        public static SerializableMethodInfo GetSerializableMethodInfo(this MethodInfo _this, bool includeGenerics = true)
        {
            return new SerializableMethodInfo(_this, includeGenerics);
        }

        public static string GetMethodSignature(this MethodInfo _this, bool includeNames = false)
        {
            string ret;
            var mi = _this;
            if (_this.IsGenericMethod)
            {
                mi = mi.GetGenericMethodDefinition();
            }
            var strBuilder = new StringBuilder();
            if (mi.IsPublic)
                strBuilder.Append("public ");
            else if (mi.IsPrivate)
                strBuilder.Append("private ");
            else if (mi.IsAssembly)
                strBuilder.Append("internal ");
            if (mi.IsFamily)
                strBuilder.Append("protected ");
            if (mi.IsStatic)
                strBuilder.Append("static ");
            if (includeNames)
            {
                var parameterInfos = mi.GetParameters();
                var paramStrings = new List<string>();
                foreach (var parameterInfo in parameterInfos)
                {
                    paramStrings.Add($"{parameterInfo.ParameterType.GetFormattedName()} {parameterInfo.Name}");
                }
                strBuilder.Append($"{mi.ReturnType.GetFormattedName()} {mi.Name}({string.Join(", ", paramStrings)})");
                ret = strBuilder.ToString();
            }
            else
            {
                var parameterTypes = mi.GetParameters().Select(o => o.ParameterType.GetFormattedName());
                ret = $"{strBuilder.ToString()}{mi.ReturnType.GetFormattedName()} {mi.Name}({string.Join(", ", parameterTypes)})";
            }
#if DEBUG
            Console.WriteLine($"GetMethodSignature: {ret}");
#endif
            return ret;
        }

        public static MethodInfo? GetMethodFromSignature(this Type _this, string key, bool includeNames = false)
        {
            if (!key.Contains(" "))
            {
                // if key does not contain a space it is assumed that it is just the method name, and that it is public instance
                var methods = _this.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (MethodInfo item in methods)
                {
                    var sig = item.GetMethodSignature(includeNames);
                    if (sig == key)
                    {
                        return item;
                    }
                }
            }
            else
            {
                var methods = _this.GetMethods();
                foreach (MethodInfo item in methods)
                {
                    var sig = item.GetMethodSignature();
                    if (sig == key)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public static MethodInfo? GetMethodFromSignature(this Type _this, UInt64 key)
        {
            var methods = _this.GetMethods();
            foreach (MethodInfo item in methods)
            {
                var sig = item.GetMethodSignatureHash();
                if (sig == key)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
