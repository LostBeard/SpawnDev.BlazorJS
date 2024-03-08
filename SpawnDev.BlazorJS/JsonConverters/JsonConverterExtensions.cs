using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// When implemented on a JsonConverter it indicates that the converter needs an IJSInProcessObjectReference whhich can be read with<br />
    /// var _ref = JsonSerializer.Deserialize&lt;IJSInProcessObjectReference?&gt;(ref reader, options)
    /// </summary>
    public interface IJSInProcessObjectReferenceConverter
    {
        // This is an indicator interface and has no defined body.
    }
    internal static class JsonConverterExtensions
    {
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
