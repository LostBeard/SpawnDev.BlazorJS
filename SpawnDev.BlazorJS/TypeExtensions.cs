using System.Collections;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Static class that contains Type extension methods
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns a List of ClassMemberJsonInfo for properties and fields that may be included during serialization and deserialization
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<ClassMemberJsonInfo> GetTypeJsonProperties(this Type t)
        {
            // check
            var ret = new List<ClassMemberJsonInfo>();
            var props = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var prop in props)
            {
                var jsonIgnoreAttr = prop.GetCustomAttribute<JsonIgnoreAttribute>(true);
                if (jsonIgnoreAttr != null && jsonIgnoreAttr.Condition == JsonIgnoreCondition.Always) continue;
                var isPublic = prop.GetAccessors(false).Length > 0;
                var jsonPropNameAttr = prop.GetCustomAttribute<JsonPropertyNameAttribute>(true);
                var include = jsonPropNameAttr != null || Attribute.IsDefined(prop, typeof(JsonIncludeAttribute));
                if (!include && !isPublic) continue;
                var p = new ClassMemberJsonInfo(prop);
                p.JsonIgnoreAttribute = jsonIgnoreAttr;
                p.JsonPropertyNameAttribute = jsonPropNameAttr;
                ret.Add(p);
            }
            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var prop in fields)
            {
                var jsonIgnoreAttr = prop.GetCustomAttribute<JsonIgnoreAttribute>(true);
                if (jsonIgnoreAttr != null && jsonIgnoreAttr.Condition == JsonIgnoreCondition.Always) continue;
                var jsonPropNameAttr = prop.GetCustomAttribute<JsonPropertyNameAttribute>(true);
                var include = jsonPropNameAttr != null || Attribute.IsDefined(prop, typeof(JsonIncludeAttribute));
                if (!include) continue;
                var p = new ClassMemberJsonInfo(prop);
                p.JsonIgnoreAttribute = jsonIgnoreAttr;
                p.JsonPropertyNameAttribute = jsonPropNameAttr;
                ret.Add(p);
            }
            return ret!;
        }
        static Dictionary<Type, object?> TypeDefaultsCache { get; } = new Dictionary<Type, object?>();
        static object? GetDefault<T>() => default(T);
        /// <summary>
        /// Returns the default value of the specified type
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object? GetDefaultValue(this Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }
        /// <summary>
        /// type == typeof(void)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsVoid(this Type type) => type == typeof(void);
        /// <summary>
        /// Returns true if the Type is a Task or ValueTask
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsAsync(this Type type) => type.IsTask() || type.IsValueTask();
        /// <summary>
        /// If the Type is a Task or ValueTask the with a result type, it is returned. Otherwise null is returned;
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type? AsyncReturnType(this Type type) => type.IsAsync() ? type.GetGenericArguments().FirstOrDefault() ?? typeof(void) : null;
        /// <summary>
        /// Returns true is the type is assignable to Task
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsTask(this Type type) => typeof(Task).IsAssignableFrom(type);
        /// <summary>
        /// Return true if the type is a ValueTask, or it's generic definition is ValueTask&lt;&gt;
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsValueTask(this Type type) => typeof(ValueTask).IsAssignableFrom(type) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ValueTask<>));
        /// <summary>
        /// Returns true if the type is a generic typed version of ValueTask&lt;&gt;<br />
        /// Ex. ValueTask&lt;string&gt; would return true
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsValueTaskTyped(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ValueTask<>);
        /// <summary>
        /// Returns true if the type is a generic typed version of Task&lt;&gt;<br />
        /// Ex. Task&lt;string&gt; would return true
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsTaskTyped(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>);
        /// <summary>
        /// Returns the type name formatted to better resemble the type as it would be written in C# code.<br />
        /// Formatting may not be accurate.<br />
        /// Implementation may change.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String</returns>
        public static string GetFormattedName(this Type type)
        {
            try
            {
                if (type.IsGenericType)
                {
                    var name = type.Name.Contains("`") ? type.Name : (type.DeclaringType?.Name ?? "");
                    if (name.Contains("`"))
                    {
                        var generics = type.GetGenericArguments();
                        string genericArguments = generics.Select(x => x.GetFormattedName()).Aggregate((x1, x2) => $"{x1}, {x2}");
                        return $"{name.Substring(0, name.IndexOf("`"))}<{genericArguments}>";
                    }
                }
            }
            catch (Exception ex)
            {
                var nmt = true;
            }
            switch (type.Name)
            {
                case "String": return "string";
                case "Object": return "object";
                case "Byte": return "byte";
                case "Int16": return "short";
                case "UInt16": return "ushort";
                case "Int32": return "int";
                case "UInt32": return "uint";
                case "Int64": return "long";
                case "UInt64": return "ulong";
                case "Void": return "void";
                case "Single": return "float";
                case "Double": return "double";
                case "Boolean": return "bool";
            }
            return type.Name;
        }
        /// <summary>
        /// Returns the Type's FullName if available, else it returns the Type Name.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFullName(this Type type)
        {
            return string.IsNullOrEmpty(type.FullName) ? type.Name : type.FullName;
        }
        /// <summary>
        /// Returns the most descriptive name for this Type falling back to less descriptive if needed.<br />
        /// AssemblyQualifiedName, FullName, then Name
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetBestName(this Type type)
        {
            return !string.IsNullOrEmpty(type.AssemblyQualifiedName) ? type.AssemblyQualifiedName : (!string.IsNullOrEmpty(type.FullName) ? type.FullName : type.Name);
        }
        /// <summary>
        /// Returns a List of type's inherited types.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Type> GetBaseTypes(this Type type)
        {
            var ret = new List<Type>();
            var dtype = type.BaseType;
            while (dtype != null)
            {
                ret.Add(dtype);
                dtype = dtype.BaseType;
            }
            return ret;
        }

        /// <summary>
        /// Looks for the type by name in current domain assemblies.<br />
        /// can be called with the Type.QualifiedTypeName or Type.FullName
        /// </summary>
        /// <param name="typeName">The QualifiedTypeName or FullName of the Type</param>
        /// <param name="useCache">Return the cached result if found</param>
        /// <returns></returns>
        public static Type? GetType(string? typeName, bool useCache = true)
        {
            if (string.IsNullOrEmpty(typeName)) return null;
            Type? t;
            if (!useCache || !typeCache.TryGetValue(typeName, out t))
            {
                t = Type.GetType(typeName);
                if (t == null)
                {
                    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        t = a.GetType(typeName);
                        if (t != null) break;
                    }
                }
                typeCache[typeName] = t;
            }
            return t;
        }
        static Dictionary<string, Type?> typeCache { get; } = new Dictionary<string, Type?>();

        /// <summary>
        /// Returns methods that match the given parameters<br />
        /// Default binding flags:<br />
        /// BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="methodName"></param>
        /// <param name="parameterCount"></param>
        /// <param name="bindingFlags"></param>
        /// <param name="allowGeneric"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<MethodInfo> FindAllMethods(this Type classType, string methodName, int parameterCount, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static, bool allowGeneric = false)
        {
            return classType
            .FindAllMethods(methodName, bindingFlags, allowGeneric).Where(m =>
            {
                var methodParams = m.GetParameters();
                var maxParamCount = methodParams.Count();
                var minParamCount = methodParams.Where(o => !o.HasDefaultValue).Count();
                return parameterCount <= maxParamCount && parameterCount >= minParamCount;
            })
            .ToList();
        }
        /// <summary>
        /// Returns methods that match the given parameters<br />
        /// Default binding flags:<br />
        /// BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="methodName"></param>
        /// <param name="bindingFlags"></param>
        /// <param name="allowGeneric"></param>
        /// <returns></returns>
        public static List<MethodInfo> FindAllMethods(this Type classType, string methodName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static, bool allowGeneric = false)
        {
            return classType
            .GetMethods(bindingFlags)
            .Where(m => m.Name == methodName)
            .Where(m => allowGeneric || !m.IsGenericMethod)
            .ToList();
        }
        /// <summary>
        /// Checks if a type is IEnumerable and returns its element type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>The element type of the IEnumerable, or null if it's not an IEnumerable of T (excluding string).</returns>
        public static Type? GetEnumerableElementType(this Type type)
        {
            // Ignore strings as they are also IEnumerable<char> but usually treated as a scalar type
            if (type == typeof(string))
            {
                return null;
            }

            // 1. Check if the type itself is a generic IEnumerable<T>
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return type.GetGenericArguments()[0];
            }

            // 2. Check if the type implements any generic IEnumerable<T> interface
            var genericIEnumerable = type.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            if (genericIEnumerable != null)
            {
                return genericIEnumerable.GetGenericArguments()[0];
            }

            // 3. Check for the non-generic IEnumerable (returns object as the element type)
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                return typeof(object);
            }

            return null;
        }
    }
}
