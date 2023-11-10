using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace SpawnDev.BlazorJS.Test.Pages
{
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
