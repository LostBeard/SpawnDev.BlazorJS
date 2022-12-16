using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace SpawnDev.BlazorJS
{
    public partial class JS
    {
        [StructLayout(LayoutKind.Explicit, Pack = 4)]
        internal struct JSCallInfo
        {
            [FieldOffset(0)]
            public string FunctionIdentifier;

            [FieldOffset(4)]
            public JSCallResultType ResultType;

            [FieldOffset(8)]
            public string MarshalledCallArgsJson;

            [FieldOffset(12)]
            public long MarshalledCallAsyncHandle;

            [FieldOffset(20)]
            public long TargetInstanceId;
        }

        // this is the moethod we need to implemented
        //// reflected from JSInProcessRuntime.Invoke
        //internal TValue Invoke<[DynamicallyAccessedMembers(JsonSerialized)] TValue>(string identifier, long targetInstanceId, params object?[]? args)
        //{
        //    var resultJson = InvokeJS(
        //        identifier,
        //        JsonSerializer.Serialize(args, JsonSerializerOptions),
        //        JSCallResultTypeHelper.FromGeneric<TValue>(),
        //        targetInstanceId);

        //    // While the result of deserialization could be null, we're making a
        //    // quality of life decision and letting users explicitly determine if they expect
        //    // null by specifying TValue? as the expected return type.
        //    if (resultJson is null)
        //    {
        //        return default!;
        //    }

        //    var result = JsonSerializer.Deserialize<TValue>(resultJson, JsonSerializerOptions)!;
        //    ByteArraysToBeRevived.Clear();
        //    return result;
        //}

        internal static JsonSerializerOptions _runtimeSerializerOptions;
        //internal static ArrayBuilder<byte[]> ByteArraysToBeRevived;

        static MethodInfo arrayBuilderClearMethod;
        static object arrayBuilderInstance;

        static MethodInfo internalCallsInvoekJSMethod;

        delegate TRes InvokeJSDelegate<T0, T1, T2, TRes>(out string exception, ref JSCallInfo callInfo, [AllowNull] T0 arg0, [AllowNull] T1 arg1, [AllowNull] T2 arg2);

        static string InternalCalls_InvokeJSAlt(out string exception, ref JSCallInfo callInfo)
        {
            exception = "";
            var genericMethod = internalCallsInvoekJSMethod.MakeGenericMethod(new Type[] { typeof(object), typeof(object), typeof(object), typeof(string) });
            var callArgs = new object?[] { exception, callInfo, null, null, null };
            var ret = (string?)genericMethod.Invoke(null, callArgs);
            return ret ?? "";
        }

        static string WebAssemblyJSRuntime_InvokeJS(string identifier, string? argsJson, JSCallResultType resultType, long targetInstanceId)
        {
            var callInfo = new JSCallInfo
            {
                FunctionIdentifier = identifier,
                TargetInstanceId = targetInstanceId,
                ResultType = resultType,
                MarshalledCallArgsJson = argsJson ?? "[]",
                MarshalledCallAsyncHandle = default
            };
            //var result = InternalCalls.InvokeJS<object, object, object, string>(out var exception, ref callInfo, null, null, null);
            var result = InternalCalls_InvokeJSAlt(out var exception, ref callInfo);
            return exception != null
                ? throw new JSException(exception)
                : result;
        }

        public static JSCallResultType JSCallResultTypeHelper_FromGeneric<TResult>()
        {
            if (typeof(TResult) == typeof(IJSStreamReference))
            {
                return JSCallResultType.JSStreamReference;
            }
            // if you do not want the return value you can ask for object and you'll get null (nothing will be serialized/deserialized)
            else if (typeof(TResult) == typeof(object))
            {
                return JSCallResultType.JSVoidResult;
            }
            else if (typeof(TResult) == typeof(IJSObjectReference) ||
                typeof(TResult) == typeof(IJSInProcessObjectReference) ||
                typeof(TResult) == typeof(IJSUnmarshalledObjectReference) ||
                typeof(JSObject).IsAssignableFrom(typeof(TResult)))
            {
                return JSCallResultType.JSObjectReference;
            }
            return JSCallResultType.Default;
        }

        private static void JSRuntime_ByteArraysToBeRevived_Clear()
        {
            arrayBuilderClearMethod.Invoke(arrayBuilderInstance, null);
        }

        //this is the moethod we need to implemented
        // reflected from JSInProcessRuntime.Invoke
        static TValue JSInProcessRuntime_Invoke<TValue>(string identifier, long targetInstanceId, params object?[]? args)
        {
            var resultJson = WebAssemblyJSRuntime_InvokeJS(
                identifier, 
                JsonSerializer.Serialize(args, _runtimeSerializerOptions), 
                JSCallResultTypeHelper_FromGeneric<TValue>(), 
                targetInstanceId);
            // While the result of deserialization could be null, we're making a
            // quality of life decision and letting users explicitly determine if they expect
            // null by specifying TValue? as the expected return type.
            if (resultJson is null)
            {
                return default!;
            }
            var result = JsonSerializer.Deserialize<TValue>(resultJson, _runtimeSerializerOptions)!;
            JSRuntime_ByteArraysToBeRevived_Clear();
            return result;
        }

        //static void BeginInvokeJS(long asyncHandle, string identifier, [StringSyntax(StringSyntaxAttribute.Json)] string? argsJson, JSCallResultType resultType, long targetInstanceId)
        //{
        //    var callInfo = new JSCallInfo
        //    {
        //        FunctionIdentifier = identifier,
        //        TargetInstanceId = targetInstanceId,
        //        ResultType = resultType,
        //        MarshalledCallArgsJson = argsJson ?? "[]",
        //        MarshalledCallAsyncHandle = asyncHandle
        //    };
        //    InternalCalls.InvokeJS<object, object, object, string>(out _, ref callInfo, null, null, null);
        //}
    }
}
