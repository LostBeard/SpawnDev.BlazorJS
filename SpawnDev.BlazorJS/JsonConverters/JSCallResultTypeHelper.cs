using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JsonConverters
{
    internal class JSCallResultTypeHelperOverride
    {
        private static MethodInfo? FromGenericMethodInfo = null;
        static Dictionary<Type, MethodInfo> FromGenericTypedCache = new Dictionary<Type, MethodInfo>();
        static MethodInfo GetFromGenericTyped(Type type)
        {
            MethodInfo result;
            if (FromGenericTypedCache.TryGetValue(type, out result)) return result;
            if (FromGenericMethodInfo == null)
            {
                FromGenericMethodInfo = typeof(JSCallResultType).Assembly.GetType("Microsoft.JSInterop.JSCallResultTypeHelper").GetMethod("FromGeneric", BindingFlags.Public | BindingFlags.Static);
            }
            result = FromGenericMethodInfo.MakeGenericMethod(type);
            FromGenericTypedCache[type] = result;
            return result;
        }

        public static JSCallResultType FromGeneric(Type returnType) {
            var jsonConverter = JS.RuntimeJsonSerializerOptions.GetConverter(returnType);
            var resultTypeOrig = FromGenericOrig(returnType);
            var jsReturnTypeOverride = JSCallResultType.Default;
            var overrideIt = false;
            if (jsonConverter is IJSInProcessObjectReferenceConverter jsonConverterV2) {
                jsReturnTypeOverride = jsonConverterV2.JSCallResultType;
                if (resultTypeOrig != jsReturnTypeOverride) {
                    jsReturnTypeOverride += 128;
                }
            }
            return jsReturnTypeOverride;
        }

        public static JSCallResultType FromGeneric<TResult>()
        {
            var returnType = typeof(TResult);
            var jsonConverter = JS.RuntimeJsonSerializerOptions.GetConverter(returnType);
            var resultTypeOrig = FromGenericOrig<TResult>();
            var jsReturnTypeOverride = JSCallResultType.Default;
            var overrideIt = false;
            if (jsonConverter is IJSInProcessObjectReferenceConverter jsonConverterV2)
            {
                jsReturnTypeOverride = jsonConverterV2.JSCallResultType;
                if (resultTypeOrig != jsReturnTypeOverride) {
                    jsReturnTypeOverride += 128;
                }
            }
            return jsReturnTypeOverride;
        }

        public static JSCallResultType FromGenericOrig(Type resultType)
        {
            var fromGenericTyped = GetFromGenericTyped(resultType);
            return (JSCallResultType)fromGenericTyped.Invoke(null, null);
        }
        public static JSCallResultType FromGenericOrig<TResult>()
        {
            var fromGenericTyped = GetFromGenericTyped(typeof(TResult));
            return (JSCallResultType)fromGenericTyped.Invoke(null, null);
        }

        //private static readonly Assembly _currentAssembly = typeof(JSCallResultType).Assembly;
        //public static JSCallResultType FromGeneric<TResult>() {
        //    if (typeof(TResult).Assembly == _currentAssembly) {
        //        if (typeof(TResult) == typeof(IJSObjectReference) ||
        //            typeof(TResult) == typeof(IJSInProcessObjectReference) ||
        //            typeof(TResult) == typeof(IJSUnmarshalledObjectReference)) {
        //            return JSCallResultType.JSObjectReference;
        //        }
        //        else if (typeof(TResult) == typeof(IJSStreamReference)) {
        //            return JSCallResultType.JSStreamReference;
        //        }
        //        else if (typeof(TResult) == typeof(void)) {
        //            return JSCallResultType.JSVoidResult;
        //        }
        //        else {
        //            var nmt = true;
        //        }
        //    }
        //    return JSCallResultType.Default;
        //}
    }
}
