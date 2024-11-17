using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// This class is used to determine if the JSCallResultType that the JSRuntime call will use needs to be overridden
    /// If the value needs to be overridden, the new value is returned with 128 added to the new JSCallResultType
    /// </summary>
    internal class JSRuntimeSerializerOptionsInfo
    {
        const int OverrideFlag = 128;
        public JsonSerializerOptions JsonSerializerOptions { get; private set; }
        public IJSRuntime JSRuntime { get; private set; }
        static PropertyInfo jsRuntimeJsonSerializerOptionsProp = typeof(JSRuntime).GetProperty("JsonSerializerOptions", BindingFlags.NonPublic | BindingFlags.Instance)!;
        public JSRuntimeSerializerOptionsInfo(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
            JsonSerializerOptions = (JsonSerializerOptions)jsRuntimeJsonSerializerOptionsProp.GetValue(jsRuntime)!;
        }
        public JSCallResultType FromGenericForCallback(Type returnType)
        {
            var ret = JSCallResultType.Default;
            var jsonConverter = JsonSerializerOptions.GetConverter(returnType);
            if (jsonConverter is IJSObjectAsyncConverter || jsonConverter is IJSInProcessObjectReferenceConverter)
            {
                ret = JSCallResultType.JSObjectReference;
            }
            else
            {
                ret = FromGenericOrig(returnType);
            }
            return ret == JSCallResultType.Default ? ret : ret + OverrideFlag;
        }
        /// <summary>
        /// FromGeneric returns the value from the original FromGeneric method unless the default is json and IJSInprocessObjectReference is desired instead
        /// </summary>
        /// <param name="returnType"></param>
        /// <returns></returns>
        public JSCallResultType FromGeneric(Type returnType)
        {
            var resultType = FromGenericOrig(returnType);
            if (resultType != JSCallResultType.JSObjectReference)
            {
                var jsonConverter = JsonSerializerOptions.GetConverter(returnType);
                if (jsonConverter is IJSObjectAsyncConverter || jsonConverter is IJSInProcessObjectReferenceConverter)
                {
                    resultType = JSCallResultType.JSObjectReference + OverrideFlag;
                }
            }
            return resultType;
        }
        /// <summary>
        /// FromGeneric returns the value from the original FromGeneric method unless the default is json and IJSInprocessObjectReference is desired instead
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public JSCallResultType FromGeneric<TResult>() => FromGeneric(typeof(TResult));
        private static MethodInfo? FromGenericMethodInfo = null;
        static Dictionary<Type, MethodInfo> FromGenericTypedCache = new Dictionary<Type, MethodInfo>();
        static MethodInfo GetFromGenericTyped(Type type)
        {
            if (FromGenericTypedCache.TryGetValue(type, out var result)) return result;
            FromGenericMethodInfo ??= typeof(JSCallResultType).Assembly.GetType("Microsoft.JSInterop.JSCallResultTypeHelper")!.GetMethod("FromGeneric", BindingFlags.Public | BindingFlags.Static);
            result = FromGenericMethodInfo!.MakeGenericMethod(type);
            FromGenericTypedCache[type] = result;
            return result;
        }
        static JSCallResultType FromGenericOrig(Type resultType)
        {
            var fromGenericTyped = GetFromGenericTyped(resultType);
            return (JSCallResultType)fromGenericTyped.Invoke(null, null)!;
        }
    }
}
