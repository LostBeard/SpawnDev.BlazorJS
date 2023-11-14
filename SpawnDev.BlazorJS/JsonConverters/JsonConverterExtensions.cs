using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public interface IJSInProcessObjectReferenceConverter
    {
        //JSCallResultType JSCallResultType { get; }
        //bool OverrideResultType { get; }
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
