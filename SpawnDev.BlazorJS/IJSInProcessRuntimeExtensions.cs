using Microsoft.JSInterop;
using System.Reflection;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// IJSInProcessRuntime extension methods
    /// </summary>
    public static class IJSInProcessRuntimeExtensions
    {
        private static Type WebAssemblyJSObjectReferenceType = typeof(Microsoft.JSInterop.WebAssembly.WebAssemblyJSRuntime).Assembly.GetType("Microsoft.JSInterop.WebAssembly.WebAssemblyJSObjectReference")!;
        private static Lazy<MethodInfo> IJSInProcessRuntime_Invoke = new Lazy<MethodInfo>(() => typeof(JSInProcessRuntime).GetMethod("Invoke", new Type[] { typeof(string), typeof(object[]) })!);
        private static Dictionary<Type, MethodInfo> GenericInvokeMethods { get; } = new Dictionary<Type, MethodInfo>();
        private static MethodInfo GetJSRuntimeInvoke(Type type)
        {
            if (GenericInvokeMethods.TryGetValue(type, out MethodInfo? generic)) return generic!;
            return GenericInvokeMethods[type] = IJSInProcessRuntime_Invoke.Value.MakeGenericMethod(type);
        }
        internal static object? Invoke(this IJSInProcessRuntime _js, Type returnType, string identifier, params object?[]? args) => GetJSRuntimeInvoke(returnType).Invoke(_js, new object?[] { identifier, args });
        internal static IJSInProcessObjectReference CreateIJSInProcessObjectReference(this IJSInProcessRuntime _js, long id)
        {
            return (IJSInProcessObjectReference)Activator.CreateInstance(WebAssemblyJSObjectReferenceType, _js, id)!;
        }
        internal static T CreateJSObject<T>(this IJSInProcessRuntime _js, long id) where T : JSObject
        {
            var _ref = (IJSInProcessObjectReference)Activator.CreateInstance(WebAssemblyJSObjectReferenceType, _js, id)!;
            return (T)Activator.CreateInstance(typeof(T), _ref)!;
        }
    }
}
