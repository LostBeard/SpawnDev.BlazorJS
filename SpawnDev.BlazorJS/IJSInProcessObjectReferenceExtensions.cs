using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop.Implementation;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    public static class IJSInProcessObjectReferenceExtensions
    {
        // Function Call
        public static object? Invoke(this IJSInProcessObjectReference _ref, Type returnType, string identifier, params object[] args) => GetJSInProcessObjectInvoke(returnType).Invoke(_ref, new object[] { identifier, args });
        public static async Task<object?> InvokeAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, params object[] args)
        {
            // TODO - get repalce dynamic usage with other (like is WebWorkers ServiceCallDispatcher)
            dynamic task = GetJSInProcessObjectInvokeAsync(returnType).Invoke(_ref, new object[] { identifier, args });
            await task;
            return (object)task.GetAwaiter().GetResult();
        }
        // Private
        //private static Type AsyncStateMachineAttributeType = typeof(AsyncStateMachineAttribute);
        //private static bool IsAsyncMethod(MethodInfo method) => method.GetCustomAttribute(AsyncStateMachineAttributeType) != null;
        private static MethodInfo? GetBestInstanceMethod(Type classType, string identifier, Type[]? paramTypes = null, int genericsCount = 0, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            MethodInfo? best = null;
            //var bestIsAsync = false;
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
                    //var methodIsAsync = IsAsyncMethod(method);
                    Type[] mParams = method.GetParameters().Select(x => x.ParameterType).ToArray();
                    if (isAssignableFrom(mParams, paramTypes))
                    {
                        if (best == null || isAssignableFrom(bestParams, mParams))
                        {
                            best = method;
                            //bestIsAsync = methodIsAsync;
                            bestParams = mParams;
                        }
                    }
                }
            }
            return best;
        }
        private static Dictionary<Type, MethodInfo> JSInProcessObjectGenericInvokeAsyncMethods { get; } = new Dictionary<Type, MethodInfo>();
        private static Dictionary<Type, MethodInfo> JSInProcessObjectGenericInvokeMethods { get; } = new Dictionary<Type, MethodInfo>();
        private static System.Lazy<MethodInfo> IJSInProcessObjectReference_Invoke = new System.Lazy<MethodInfo>(() => GetBestInstanceMethod(typeof(JSInProcessObjectReference), "Invoke", new Type[] { typeof(string), typeof(object[]) }, 1));
        private static System.Lazy<MethodInfo> IJSInProcessObjectReference_InvokeAsync = new System.Lazy<MethodInfo>(() => GetBestInstanceMethod(typeof(JSInProcessObjectReference), "InvokeAsync", new Type[] { typeof(string), typeof(object[]) }, 1));
        private static MethodInfo GetJSInProcessObjectInvokeAsync(Type type)
        {
            if (JSInProcessObjectGenericInvokeAsyncMethods.TryGetValue(type, out MethodInfo generic)) return generic;
            return JSInProcessObjectGenericInvokeAsyncMethods[type] = IJSInProcessObjectReference_InvokeAsync.Value.MakeGenericMethod(type);
        }
        private static MethodInfo GetJSInProcessObjectInvoke(Type type)
        {
            if (JSInProcessObjectGenericInvokeMethods.TryGetValue(type, out MethodInfo generic)) return generic;
            return JSInProcessObjectGenericInvokeMethods[type] = IJSInProcessObjectReference_Invoke.Value.MakeGenericMethod(type);
        }
    }
}
