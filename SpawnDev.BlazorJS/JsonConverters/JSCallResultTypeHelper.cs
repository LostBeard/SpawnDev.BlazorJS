using Microsoft.JSInterop;
using System.Reflection;

namespace SpawnDev.BlazorJS.JsonConverters {
    /// <summary>
    /// This class is used to determine if the JSCallResultType that the JSRuntime call will use needs to be overridden
    /// If the value needs to be overridden, the new valueis returned with 128 added to the new JSCallResultType
    /// </summary>
    internal class JSCallResultTypeHelperOverride {
        private static MethodInfo? FromGenericMethodInfo = null;
        static Dictionary<Type, MethodInfo> FromGenericTypedCache = new Dictionary<Type, MethodInfo>();
        static MethodInfo GetFromGenericTyped(Type type) {
            MethodInfo result;
            if (FromGenericTypedCache.TryGetValue(type, out result)) return result;
            if (FromGenericMethodInfo == null) {
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

        public static JSCallResultType FromGeneric<TResult>() {
            var returnType = typeof(TResult);
            var jsonConverter = JS.RuntimeJsonSerializerOptions.GetConverter(returnType);
            var resultTypeOrig = FromGenericOrig<TResult>();
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

        public static JSCallResultType FromGenericOrig(Type resultType) {
            var fromGenericTyped = GetFromGenericTyped(resultType);
            return (JSCallResultType)fromGenericTyped.Invoke(null, null);
        }

        public static JSCallResultType FromGenericOrig<TResult>() {
            var fromGenericTyped = GetFromGenericTyped(typeof(TResult));
            return (JSCallResultType)fromGenericTyped.Invoke(null, null);
        }
    }
}
