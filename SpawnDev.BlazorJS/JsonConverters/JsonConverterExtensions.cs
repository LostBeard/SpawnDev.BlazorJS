using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JsonConverters {
    public interface IJSInProcessObjectReferenceConverter {
        JSCallResultType JSCallResultType { get; }
        bool OverrideResultType { get; }
    }
    internal static class JsonConverterExtensions {
        public static bool GetJSCallResultTypeOverride(this JsonConverter jsonConverter, out JSCallResultType jsReturnTypeOverride) {
            if (jsonConverter is IJSInProcessObjectReferenceConverter jsonConverterV2) {
                jsReturnTypeOverride = jsonConverterV2.JSCallResultType;
                return true;
            }
            else {
                jsReturnTypeOverride = JSCallResultType.Default;
                return false;
            }
        }
    }
}
