using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public static class MethodInfoExtension
    {
        static UInt64 CalculateHash(string read)
        {
            UInt64 hashedValue = 3074457345618258791ul;
            for (int i = 0; i < read.Length; i++)
            {
                hashedValue += read[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }
        static UInt64 CalculateHash(string read, bool lowTolerance)
        {
            UInt64 hashedValue = 0;
            int i = 0;
            ulong multiplier = 1;
            while (i < read.Length)
            {
                hashedValue += read[i] * multiplier;
                multiplier *= 37;
                if (lowTolerance) i += 2;
                else i++;
            }
            return hashedValue;
        }
        public static UInt64 GetMethodSignatureHash(this MethodInfo _this)
        {
            var sig = _this.GetMethodSignature();
            var hash = CalculateHash(sig);
            return hash;
        }
        public static string GetMethodSignature(this MethodInfo _this)
        {
            var parameterTypes = _this.GetParameters().Select(o => o.ParameterType.GetFormattedName());
            var strBuilder = new StringBuilder();
            if (_this.IsPublic)
                strBuilder.Append("public ");
            else if (_this.IsPrivate)
                strBuilder.Append("private ");
            else if (_this.IsAssembly)
                strBuilder.Append("internal ");
            if (_this.IsFamily)
                strBuilder.Append("protected ");
            if (_this.IsStatic)
                strBuilder.Append("static ");
            return $"{strBuilder.ToString()}{_this.ReturnType.GetFormattedName()} {_this.Name}({string.Join(", ", parameterTypes)})";
        }
        public static MethodInfo? GetMethodFromSignature(this Type _this, string key)
        {
            if (!key.Contains(" "))
            {
                // if key does not contain a space it is assumed that it is just the method name, and that it is public instance
                var methods = _this.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (MethodInfo item in methods)
                {
                    var sig = item.GetMethodSignature();
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
