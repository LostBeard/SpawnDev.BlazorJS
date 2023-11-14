using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// On creation, SerializableMethodInfo extracts the information needed to allow serialization, deserialization, and resolving of a MethodInfo.<br />
    /// </summary>
    public class SerializableMethodInfo
    {
        [JsonIgnore]
        public MethodInfo? MethodInfo
        {
            get
            {
                if (!Resolved) Resolve();
                return _MethodInfo;
            }
        }
        private MethodInfo? _MethodInfo = null;
        private bool Resolved = false;
        /// <summary>
        /// MethodInfo.ReflectedType type name
        /// </summary>
        public string ReflectedTypeName { get; init; } = "";
        /// <summary>
        /// MethodInfo.Name
        /// </summary>
        public string MethodName { get; init; } = "";
        /// <summary>
        /// methodInfo.GetParameters() type names
        /// </summary>
        public List<string> ParameterTypes { get; init; } = new List<string>();
        /// <summary>
        /// MethodInfo.ReturnType type name
        /// </summary>
        public string ReturnType { get; init; } = "";
        /// <summary>
        /// methodInfo.GetGenericArguments() type names
        /// </summary>
        public List<string> GenericArguments { get; init; } = new List<string>();
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SerializableMethodInfo() { }
        /// <summary>
        /// Creates a new instance of SerializableMethodInfo that represents
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <exception cref="Exception"></exception>
        public SerializableMethodInfo(MethodInfo methodInfo)
        {
            var mi = methodInfo;
            if (methodInfo.ReflectedType == null) throw new Exception("Cannot serialize MethodInfo without ReflectedType");
            if (methodInfo.IsConstructedGenericMethod)
            {
                GenericArguments = methodInfo.GetGenericArguments().Select(o => GetTypeName(o)).ToList();
                mi = methodInfo.GetGenericMethodDefinition();
            }
            MethodName = mi.Name;
            ReflectedTypeName = GetTypeName(methodInfo.ReflectedType);
            ReturnType = GetTypeName(mi.ReturnType);
            ParameterTypes = mi.GetParameters().Select(o => GetTypeName(o.ParameterType)).ToList();
            _MethodInfo = methodInfo;
            Resolved = true;
        }
        /// <summary>
        /// Deserializes SerializableMethodInfo instance from string using System.Text.Json<br />
        /// PropertyNameCaseInsensitive = true is used in deserialization
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static SerializableMethodInfo? FromString(string json) => JsonSerializer.Deserialize<SerializableMethodInfo>(json, DefaultJsonSerializerOptions);
        /// <summary>
        /// Serializes SerializableMethodInfo to a string using System.Text.Json
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize(this);

        internal static JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        internal static Dictionary<string, Type?> typeCache { get; } = new Dictionary<string, Type>();
        static string GetTypeName(Type type)
        {
            return string.IsNullOrEmpty(type.FullName) ? type.Name : type.FullName;
        }
        /// <summary>
        /// For whatever reason Type.GetType was failing when trying to find a Type in the same assembly as this class... no idea why. Below code worked when it failed
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        internal static Type? GetType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) return null;
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
        void Resolve()
        {
            MethodInfo? methodInfo = null;
            if (Resolved) return;
            Resolved = true;
            methodInfo = null;
            var reflectedType = GetType(ReflectedTypeName);
            if (reflectedType == null)
            {
                // Reflected type not found
                return;
            }
            var methodsWithName = reflectedType.GetMethods().Where(o => o.Name == MethodName);
            if (!methodsWithName.Any())
            {
                // No method found with this MethodName found in ReflectedType
                return;
            }
            MethodInfo? mi = null;
            foreach (var method in methodsWithName)
            {
                var msi = new SerializableMethodInfo(method);
                if (msi.ReturnType == ReturnType && msi.ParameterTypes.SequenceEqual(ParameterTypes))
                {
                    mi = method;
                    break;
                }
            }
            if (mi == null)
            {
                // No method found that matches the base method signature
                return;
            }
            if (mi.IsGenericMethod)
            {
                if (GenericArguments == null || !GenericArguments.Any())
                {
                    // Generics information in GenericArguments is missing. Resolve not possible.
                    return;
                }
                var genericTypes = new Type[GenericArguments.Count];
                for (var i = 0; i < genericTypes.Length; i++)
                {
                    var gTypeName = GenericArguments[i];
                    var gType = GetType(gTypeName);
                    if (gType == null)
                    {
                        // One of the generic types needed to make the generic method was not found
                        return;
                    }
                    genericTypes[i] = gType;
                }
                methodInfo = mi.MakeGenericMethod(genericTypes);
            }
            else
            {
                methodInfo = mi;
            }
            _MethodInfo = methodInfo;
        }
        /// <summary>
        /// Converts a MethodInfo instance into a string
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static string SerializeMethodInfo(MethodInfo methodInfo) => new SerializableMethodInfo(methodInfo).ToString();
        /// <summary>
        /// Converts a MethodInfo that has been serialized using SerializeMethodInfo into a MethodInfo if serialization is successful or a null otherwise.
        /// </summary>
        /// <param name="serializableMethodInfoJson"></param>
        /// <returns></returns>
        public static MethodInfo? DeserializeMethodInfo(string serializableMethodInfoJson)
        {
            var tmp = FromString(serializableMethodInfoJson);
            return tmp == null ? null : tmp.MethodInfo;
        }
    }
}
