using System.Reflection;
using System.Text.Json;

namespace SpawnDev.BlazorJS
{
    public class SerializableMethodInfo
    {
        public string ReflectedTypeName { get; set; } = "";
        public string MethodName { get; set; } = "";
        public List<string> ParameterTypes { get; set; } = new List<string>();
        public string ReturnType { get; set; } = "";
        public List<string> GenericArguments { get; set; } = new List<string>();
        public SerializableMethodInfo() { }
        public SerializableMethodInfo(MethodInfo methodInfo, bool includeGenerics = true)
        {
            var mi = methodInfo;
            if (methodInfo.ReflectedType == null) throw new Exception("Cannot serialize MethodInfo without ReflectedType");
            if (methodInfo.IsConstructedGenericMethod)
            {
                if (includeGenerics)
                {
                    GenericArguments = methodInfo.GetGenericArguments().Select(o => o.GetFullName()).ToList();
                }
                mi = methodInfo.GetGenericMethodDefinition();
            }
            MethodName = mi.Name;
            ReflectedTypeName = methodInfo.ReflectedType.GetFullName();
            ReturnType = mi.ReturnType.GetFullName();
            ParameterTypes = mi.GetParameters().Select(o => o.ParameterType.GetFullName()).ToList();
        }

        public static SerializableMethodInfo? FromString(string serializedMIS)
        {
            return JsonSerializer.Deserialize<SerializableMethodInfo>(serializedMIS, DefaultJsonSerializerOptions);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        internal static JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        internal static Dictionary<string, Type?> typeCache { get; } = new Dictionary<string, Type>();

        /// <summary>
        /// For whatever reason Type.GetType was failing when trying to find a Type in the same assembly as this class... no idea why. Below code worked when it failed
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        internal static Type? GetType(string typeName)
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

        public MethodInfo? Resolve() => Resolve(out var t, out var m) ? m : null;
        public bool Resolve(out Type? reflectedType, out MethodInfo? methodInfo)
        {
            reflectedType = null;
            methodInfo = null;
            var methodInfoSerializable = this;
            if (methodInfoSerializable == null || string.IsNullOrEmpty(methodInfoSerializable.ReflectedTypeName) || string.IsNullOrEmpty(methodInfoSerializable.MethodName)) return false;
            reflectedType = GetType(methodInfoSerializable.ReflectedTypeName);
            if (reflectedType == null) return false;
            var methodsWithName = reflectedType.GetMethods().Where(o => o.Name == methodInfoSerializable.MethodName);
            MethodInfo? mi = null;
            foreach (var method in methodsWithName)
            {
                var msi = new SerializableMethodInfo(method, false);
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
                Type[] genericArguments = new Type[0];
                if (methodInfoSerializable.GenericArguments != null)
                {
                    genericArguments = new Type[methodInfoSerializable.GenericArguments.Count];
                    for (var i = 0; i < genericArguments.Length; i++)
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
                if (mi.IsGenericMethod && genericArguments.Length > 0)
                {
                    mi = mi.MakeGenericMethod(genericArguments);
                }
                methodInfo = mi;
            }
            return mi != null;
        }
    }
}
