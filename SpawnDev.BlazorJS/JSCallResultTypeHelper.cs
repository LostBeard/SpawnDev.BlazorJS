using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS {
    internal class JSCallResultTypeHelperOverride {
        // We avoid using Assembly.GetExecutingAssembly() because this is shared code.
        private static readonly Assembly _currentAssembly = typeof(JSCallResultType).Assembly;

        public static JSCallResultType FromGeneric<TResult>() {
            if (typeof(TResult).Assembly == _currentAssembly) {
                if (typeof(TResult) == typeof(IJSObjectReference) ||
                    typeof(TResult) == typeof(IJSInProcessObjectReference) ||
                    typeof(TResult) == typeof(IJSUnmarshalledObjectReference)) {
                    return JSCallResultType.JSObjectReference;
                }
                else if (typeof(TResult) == typeof(IJSStreamReference)) {
                    return JSCallResultType.JSStreamReference;
                }
                else if (typeof(TResult) == typeof(void)) {
                    return JSCallResultType.JSVoidResult;
                }
                else {
                    var nmt = true;
                }
            }

            return JSCallResultType.Default;
        }
    }
}
