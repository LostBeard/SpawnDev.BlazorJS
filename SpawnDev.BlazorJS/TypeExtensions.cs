using System.Reflection;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Static class that contains Type extension methods
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns true if the Type is a Task or ValueTask
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsAsync(this Type type) => type.IsTask() || type.IsValueTask();
        /// <summary>
        /// If the Type is a Task or ValueTask the with a result type, if one, is returned. Else null is returned;
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
    }
}
