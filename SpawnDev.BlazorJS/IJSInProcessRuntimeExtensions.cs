using Microsoft.JSInterop;
using System.Reflection;

namespace SpawnDev.BlazorJS
{
    internal static class IJSInProcessRuntimeExtensions
    {
        private static Type WebAssemblyJSObjectReferenceType = typeof(Microsoft.JSInterop.WebAssembly.WebAssemblyJSRuntime).Assembly.GetType("Microsoft.JSInterop.WebAssembly.WebAssemblyJSObjectReference")!;
        private static Lazy<MethodInfo> IJSInProcessRuntime_Invoke = new Lazy<MethodInfo>(() => GetBestInstanceMethod(typeof(JSInProcessRuntime), "Invoke", new Type[] { typeof(string), typeof(object[]) }, 1)!);
        private static Dictionary<Type, MethodInfo> GenericInvokeMethods { get; } = new Dictionary<Type, MethodInfo>();
        private static MethodInfo GetJSRuntimeInvoke(Type type)
        {
            if (GenericInvokeMethods.TryGetValue(type, out MethodInfo? generic)) return generic!;
            return GenericInvokeMethods[type] = IJSInProcessRuntime_Invoke.Value.MakeGenericMethod(type);
        }
        internal static IJSInProcessObjectReference CreateIJSInProcessObjectReference(this IJSInProcessRuntime _js, long id)
        {
            return (IJSInProcessObjectReference)Activator.CreateInstance(WebAssemblyJSObjectReferenceType, _js, id)!;
        }
        internal static T CreateJSObject<T>(this IJSInProcessRuntime _js, long id) where T : JSObject
        {
            var _ref = (IJSInProcessObjectReference)Activator.CreateInstance(WebAssemblyJSObjectReferenceType, _js, id)!;
            return (T)Activator.CreateInstance(typeof(T), _ref)!;
        }
        internal static object? Invoke(this IJSInProcessRuntime _js, Type returnType, string identifier, params object?[]? args) => GetJSRuntimeInvoke(returnType).Invoke(_js, new object[] { identifier, args });
        private static MethodInfo? GetBestInstanceMethod(Type classType, string identifier, Type[]? paramTypes = null, int genericsCount = 0, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            MethodInfo? best = null;
            if (paramTypes == null) paramTypes = new Type[0];
            var instanceMethods = classType
            .GetMethods(bindingFlags)
            .Where(m => m.Name == identifier)
            .Where(m => (!m.IsGenericMethod && genericsCount == 0) || (m.IsGenericMethod && m.GetGenericArguments().Length == genericsCount))
            .Where(m => m.GetParameters().Length == paramTypes.Length)
            .ToList();
            if (instanceMethods.Count == 1)
            {
                best = instanceMethods[0];
            }
            else if (instanceMethods.Count > 1)
            {
                Type[] bestParams = new Type[0];
                Func<Type[], Type[], bool> isAssignableFrom = (a, b) =>
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (!a[i].IsAssignableFrom(b[i])) return false;
                    }
                    return true;
                };
                foreach (var method in instanceMethods)
                {
                    Type[] mParams = method.GetParameters().Select(x => x.ParameterType).ToArray();
                    if (isAssignableFrom(mParams, paramTypes))
                    {
                        if (best == null || isAssignableFrom(bestParams, mParams))
                        {
                            best = method;
                            bestParams = mParams;
                        }
                    }
                }
            }
            return best;
        }
    }
}
