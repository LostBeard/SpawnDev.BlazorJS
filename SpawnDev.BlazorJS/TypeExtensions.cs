using System.Reflection;

namespace SpawnDev.BlazorJS {
    public static class TypeExtensions {
        public static bool IsAsync(this Type type) => type.IsTask() || type.IsValueTask();
        public static Type? AsyncReturnType(this Type type) => type.IsAsync() ? type.GetGenericArguments().FirstOrDefault() ?? typeof(void) : null;
        public static bool IsTask(this Type type) => typeof(Task).IsAssignableFrom(type);
        public static bool IsValueTask(this Type type) => typeof(ValueTask).IsAssignableFrom(type) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ValueTask<>));

        /// <summary>
        /// Returns the type name. If this is a generic type, appends
        /// the list of generic type arguments between angle brackets.
        /// (Does not account for embedded / inner generic arguments.)
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        public static string GetFormattedName(this Type type)
        {
            try
            {
                if (type.IsGenericType)
                {
                    var name = type.Name.Contains("`") ? type.Name : type.DeclaringType.Name;
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
                case "Int32": return "int";
                case "UInt32": return "uint";
                case "Int16": return "short";
                case "UInt16": return "ushort";
                case "Int64": return "long";
                case "UInt64": return "ulong";
                case "Void": return "void";
                case "Single": return "float";
                case "Double": return "double";
            }
            return type.Name;
        }
        public static string GetFullName(this Type type)
        {
            return string.IsNullOrEmpty(type.FullName) ? type.Name : type.FullName;
        }
        public static string GetFormattedName(this MethodInfo mi)
        {
            try
            {
                if (mi.IsGenericMethod)
                {
                    var name = mi.Name;
                    var generics = mi.GetGenericArguments();
                    string genericArguments = generics.Select(x => x.GetFormattedName()).Aggregate((x1, x2) => $"{x1}, {x2}");
                    return $"{name}<{genericArguments}>";
                }
            }
            catch (Exception ex)
            {
                var nmt = true;
            }
            return mi.Name;
        }

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
    }
}
