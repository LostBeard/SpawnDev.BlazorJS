using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public class MethodInfoSerializable
        {
            public string ReflectedTypeName { get; set; }
            public string MethodName { get; set; }
            public List<string> ParameterTypes { get; set; }
            public string ReturnType { get; set; }
            public List<string> GenericArguments { get; set; }
        }

        static JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static bool DeserializeMethodSignature(string? methodInfoSerialized, out Type? reflectedType, out MethodInfo? methodInfo)
        {
            reflectedType = null;
            methodInfo = null;
            if (string.IsNullOrEmpty(methodInfoSerialized)) return false;
            var methodInfoSerializable = JsonSerializer.Deserialize<MethodInfoSerializable>(methodInfoSerialized, DefaultJsonSerializerOptions);
            if (methodInfoSerializable == null || string.IsNullOrEmpty(methodInfoSerializable.ReflectedTypeName) || string.IsNullOrEmpty(methodInfoSerializable.MethodName)) return false;
            reflectedType = GetType(methodInfoSerializable.ReflectedTypeName);
            if (reflectedType == null) return false;
            var methodsWithName = reflectedType.GetMethods().Where(o => o.Name == methodInfoSerializable.MethodName);
            MethodInfo? mi = null;
            Type[] genericArguments = new Type[0];
            if (methodInfoSerializable.GenericArguments != null)
            {
                genericArguments = new Type[methodInfoSerializable.GenericArguments.Count];
                for(var i =0; i < genericArguments.Length; i++)
                {
                    var gTypeName = methodInfoSerializable.GenericArguments[i];
                    var gType = GetType(gTypeName);
                    if (gType == null)
                    {
                        throw new Exception("Generic parameter type not found.");
                    }
                    genericArguments[i] = gType;
                }
            }
            foreach (var method in methodsWithName)
            {
                var msi = GetMethodSignatureInfo(method, false);
                if (msi.MethodName == methodInfoSerializable.MethodName 
                    && msi.ParameterTypes.SequenceEqual(methodInfoSerializable.ParameterTypes)
                    && msi.ReturnType == methodInfoSerializable.ReturnType)
                {
                    mi = method;
                    break;
                }
            }
            if (mi != null)
            {
                if (mi.IsGenericMethod)
                {
                    mi = mi.MakeGenericMethod(genericArguments);
                }
                methodInfo = mi;
            }
            return mi != null;
        }

        public static string SerializeMethodSignature(this MethodInfo _this, bool includeGenerics = true)
        {
            var tmp = _this.GetMethodSignatureInfo(includeGenerics);
            var ret = JsonSerializer.Serialize(tmp);
            return ret;
        }

        public static MethodInfoSerializable GetMethodSignatureInfo(this MethodInfo _this, bool includeGenerics = true)
        {
            if (_this.ReflectedType == null) throw new Exception("Cannot serialize MethodInfo without ReflectedType");
            var mi = _this;
            var tmp = new MethodInfoSerializable();
            if (_this.IsConstructedGenericMethod)
            {
                if (includeGenerics)
                {
                    tmp.GenericArguments = _this.GetGenericArguments().Select(o => o.GetFullName()).ToList();
                }
                mi = _this.GetGenericMethodDefinition();
            }
            tmp.MethodName = mi.Name;
            tmp.ReflectedTypeName = _this.ReflectedType.GetFullName();
            tmp.ReturnType = mi.ReturnType.GetFullName();
            tmp.ParameterTypes = mi.GetParameters().Select(o => o.ParameterType.GetFullName()).ToList();
            return tmp;
        }

        static Dictionary<string, Type?> typeCache { get; } = new Dictionary<string, Type>();

        /// <summary>
        /// For whatever reason Type.GetType was failing when trying to find a Type in the same assembly as this class... no idea why. Below code worked when it failed
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        static Type? GetType(string typeName)
        {
            Type? t = null;
            lock (typeCache)
            {
                if (!typeCache.TryGetValue(typeName, out t))
                {
                    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        t = a.GetType(typeName);
                        if (t != null) break;
                    }
                    typeCache[typeName] = t;
                }
            }
            return t;
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
