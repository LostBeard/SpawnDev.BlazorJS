using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    internal static class JsonConverterExtensions
    {
        static Dictionary<Type, JsonConverter?> ConverterCache = new Dictionary<Type, JsonConverter?>();
        internal static JsonConverter? GetConverterSafe(this JsonSerializerOptions _this, Type type)
        {
            if (ConverterCache.TryGetValue(type, out var converter)) return converter;
            // below is set to null so that if the followign line causes a recursive hit, it does not go forever
            ConverterCache[type] = converter;
            converter = _this.GetConverter(type);
            ConverterCache[type] = converter;
            return converter;
        }
        /// <summary>
        /// Returns true if the type must be deserialized from Javascript runtime side to .Net per-instance 
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="pType"></param>
        /// <returns></returns>
        internal static bool TypeDeserializationRequiresPerInstance(this JsonSerializerOptions _this, Type pType)
        {
            if (typeof(JSObject).IsAssignableFrom(pType))
            {
                return true;
            }
            if (typeof(IJSObjectProxy).IsAssignableFrom(pType))
            {
                return true;
            }
            if (typeof(IJSInProcessObjectReference) == pType)
            {
                return true;
            }
            if (typeof(byte[]) == pType)
            {
                return true;
            }
            var converter = _this.GetConverterSafe(pType);
            if (converter == null) return false;
            if (converter is IJSInProcessObjectReferenceConverter) return true;
            return false;
        }
        public static bool GetJSCallResultTypeOverride(this JsonConverter jsonConverter, out JSCallResultType jsReturnTypeOverride)
        {
            if (jsonConverter is IJSInProcessObjectReferenceConverter jsonConverterV2)
            {
                jsReturnTypeOverride = JSCallResultType.JSObjectReference;
                return true;
            }
            else
            {
                jsReturnTypeOverride = JSCallResultType.Default;
                return false;
            }
        }
    }
}
