using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace SpawnDev.BlazorJS.Test.Pages
{
    public static class TypeExtensions
    {
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
            } catch (Exception ex)
            {
                var nmt = true;
            }
            switch (type.Name)
            {
                case "String": return "string";
                case "Object": return "object";
                case "Int32": return "int";
                case "UInt32": return "uint";
                case "Int64": return "long";
                case "UInt64": return "ulong";
                case "Void": return "void";
                case "Single": return "float";
                case "Double": return "double";
            }
            return type.Name;
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
            var ret = new List<Type>   ();
            var dtype = type.BaseType;
            while(dtype != null)
            {
                ret.Add(dtype);
                dtype = dtype.BaseType;
            }
            return ret;
        }
    }
    public partial class JSObjectTypeInfo
    {
        [Parameter]
        public string? Name { get; set; } = null;
        public string TypeName => Type == null ? "" : Type.Name;
        public Type? Type { get; set; }
        public bool ShowTypeList => Type == null;

        public List<Type> JSObjectTypes { get; set; } = new List<Type>();

        string JSObjectsTypeNamePrefix = "SpawnDev.BlazorJS.JSObjects.";

        string ParameterInfoToString(ParameterInfo o)
        {
            var ret = $"{o.ParameterType.GetFormattedName()} {o.Name}";
            if (o.HasDefaultValue)
            {
                ret += $" = {o.DefaultValue}";
            }
            return ret;
        }
        //string ReturnTypeToString(Type o)
        //{
        //    return o.GetFormattedName();
        //}
        protected override void OnInitialized()
        {
            JSObjectTypes = typeof(JSObject).Assembly.GetTypes().Where(o => o.FullName != null && o.FullName.StartsWith(JSObjectsTypeNamePrefix) && typeof(JSObject).IsAssignableFrom(o)).ToList();
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            Type = JSObjectTypes.Where(o => o.FullName != null && o.FullName.Equals($"{JSObjectsTypeNamePrefix}{Name}", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            base.OnParametersSet();
        }

        string JSObjectInfoHref(Type type)
        {
            var name = JSObjectShortName(type);
            return $"JSObjectTypeInfo/{name}";
        }
        string JSObjectShortName(Type type)
        {
            return type == null || type.FullName == null || !type.FullName.StartsWith(JSObjectsTypeNamePrefix) ? "" : type.FullName.Substring(JSObjectsTypeNamePrefix.Length);
        }
    }
}
