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

        /// <summary>
        /// By default all callback args are passed as JSCallResultType.Default
        /// The return value from this method tells the JSInterop.serializeToDotNet method that we want to pre-serialize to the format returned before the default serialization (json)
        /// </summary>
        /// <param name="returnType"></param>
        /// <returns></returns>
        //public JSCallResultType FromGenericForCallback(Type returnType)
        //{
        //    var ret = JSCallResultType.Default;
        //    var jsonConverter = JsonSerializerOptions.GetConverter(returnType);
        //    if (jsonConverter is IJSInProcessObjectReferenceConverter)
        //    {
        //        ret = JSCallResultType.JSObjectReference;
        //    }
        //    else
        //    {
        //        ret = FromGenericOrig(returnType);
        //    }
        //    return ret == JSCallResultType.Default ? ret : ret + OverrideFlag;
        //}

        //public JSCallResultType FromGenericForCallback<TResult>()
        //{
        //    var returnType = typeof(TResult);
        //    var ret = JSCallResultType.Default;
        //    var jsonConverter = JsonSerializerOptions.GetConverter(returnType);
        //    if (jsonConverter is IJSInProcessObjectReferenceConverter)
        //    {
        //        ret = JSCallResultType.JSObjectReference;
        //    }
        //    else
        //    {
        //        ret = FromGenericOrig(returnType);
        //    }
        //    return ret == JSCallResultType.Default ? ret : ret + OverrideFlag;
        //}


        /// <summary>
        /// FromGeneric returns the value from the original FromGeneric method unless the default is json and IJSInprocessObjectReference is desired instead
        /// </summary>
        /// <param name="returnType"></param>
        /// <returns></returns>
        public JSCallResultType FromGeneric(Type returnType)
        {
            var resultTypeOrig = FromGenericOrig(returnType);
            if (resultTypeOrig != JSCallResultType.JSObjectReference)
            {
                var jsonConverter = JsonSerializerOptions.GetConverter(returnType);
                if (jsonConverter is IJSObjectAsyncConverter || jsonConverter is IJSInProcessObjectReferenceConverter)
                {
                    resultTypeOrig = JSCallResultType.JSObjectReference + OverrideFlag;
                }
            }
            return resultTypeOrig;
        }

        public JSCallResultType FromGeneric<TResult>()
        {
            var returnType = typeof(TResult);
            var resultTypeOrig = FromGenericOrig(returnType);
            if (resultTypeOrig != JSCallResultType.JSObjectReference)
            {
                var jsonConverter = JsonSerializerOptions.GetConverter(returnType);
                if (jsonConverter is IJSObjectAsyncConverter || jsonConverter is IJSInProcessObjectReferenceConverter)
                {
                    resultTypeOrig = JSCallResultType.JSObjectReference + OverrideFlag;
                }
            }
            return resultTypeOrig;
        }

        private static MethodInfo? FromGenericMethodInfo = null;
        static Dictionary<Type, MethodInfo> FromGenericTypedCache = new Dictionary<Type, MethodInfo>();
        static MethodInfo GetFromGenericTyped(Type type)
        {
            MethodInfo? result;
            if (FromGenericTypedCache.TryGetValue(type, out result)) return result;
            if (FromGenericMethodInfo == null)
            {
                FromGenericMethodInfo = typeof(JSCallResultType).Assembly.GetType("Microsoft.JSInterop.JSCallResultTypeHelper")!.GetMethod("FromGeneric", BindingFlags.Public | BindingFlags.Static);
            }
            result = FromGenericMethodInfo!.MakeGenericMethod(type);
            FromGenericTypedCache[type] = result;
            return result;
        }

        static JSCallResultType FromGenericOrig(Type resultType)
        {
            var fromGenericTyped = GetFromGenericTyped(resultType);
            return (JSCallResultType)fromGenericTyped.Invoke(null, null)!;
        }

        static JSCallResultType FromGenericOrig<TResult>()
        {
            var fromGenericTyped = GetFromGenericTyped(typeof(TResult));
            return (JSCallResultType)fromGenericTyped.Invoke(null, null)!;
        }
    }
}
