using Microsoft.JSInterop;
using System.Reflection;

namespace SpawnDev.BlazorJS {
    public static class IJSInProcessRuntimeExtensions {
        public static void Set(this IJSInProcessRuntime _js, string identifier, object? value) => JS.Set(identifier, value);
        public static T? Get<T>(this IJSInProcessRuntime _js, string identifier) => JS.Get<T>(identifier);
        public static object? Get(this IJSInProcessRuntime _js, Type returnType, string identifier) => JS.Get(returnType, identifier);
        public static Task<T> GetAsync<T>(this IJSInProcessRuntime _js, string identifier) => JS.GetAsync<T>(identifier);
        public static T CallApply<T>(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JS.CallApply<T>(identifier, args);
        public static object? CallApply(this IJSInProcessRuntime _js, Type returnType, string identifier, object?[]? args = null) => JS.CallApply(returnType, identifier, args);
        public static void CallApplyVoid(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JS.CallApplyVoid(identifier, args);
        public static Task<T> CallApplyAsync<T>(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JS.CallApplyAsync<T>(identifier, args);
        public static Task CallApplyVoidAsync(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JS.CallApplyVoidAsync(identifier, args);

        // call with up to 10 arguments
        // used instead of "params" because params has an issue that will never be fixed that can cause unexpected behavior
        // (Example: if a single argument of string[] is passed, the params variable will be an array of string instead of a 2 dimensiaonal array with the first item being the array of strings passed) 
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier) => JS.CallApply<T>(identifier);
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0) => JS.CallApply<T>(identifier, new object?[] { arg0 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JS.CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier) => JS.CallApply(returnType, identifier);
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0) => JS.CallApply(returnType, identifier, new object?[] { arg0 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JS.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static void CallVoid(this IJSInProcessRuntime _js, string identifier) => JS.CallApplyVoid(identifier);
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0) => JS.CallApplyVoid(identifier, new object?[] { arg0 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JS.CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier) => JS.CallApplyAsync<T>(identifier);
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        //public static ValueTask<T> CallAsync<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JS.CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier) => JS.CallApplyAsync(returnType, identifier);
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        //public static ValueTask<object?> CallAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JS.CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier) => JS.CallApplyVoidAsync(identifier);
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        //public static ValueTask CallVoidAsync(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JS.CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        //public static async ValueTask<object?> InvokeAsync(this IJSInProcessRuntime _js, Type returnType, string identifier, params object[] args)
        //{
        //    // TODO - get repalce dynamic usage with other (like is WebWorkers ServiceCallDispatcher)
        //    dynamic task = GetJSRuntimeInvokeAsync(returnType).Invoke(_js, new object[] { identifier, args });
        //    if (task == null) return null;
        //    await task;
        //    return (object?)task.GetAwaiter().GetResult();
        //}
        public static object? Invoke(this IJSInProcessRuntime _js, Type returnType, string identifier, params object[] args) => GetJSRuntimeInvoke(returnType).Invoke(_js, new object[] { identifier, args });

        private static MethodInfo? GetBestInstanceMethod(Type classType, string identifier, Type[]? paramTypes = null, int genericsCount = 0, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance) {
            MethodInfo? best = null;
            //var bestIsAsync = false;
            if (paramTypes == null) paramTypes = new Type[0];
            var instanceMethods = classType
            .GetMethods(bindingFlags)
            .Where(m => m.Name == identifier)
            .Where(m => (!m.IsGenericMethod && genericsCount == 0) || (m.IsGenericMethod && m.GetGenericArguments().Length == genericsCount))
            .Where(m => m.GetParameters().Length == paramTypes.Length)
            .ToList();
            if (instanceMethods.Count == 1) {
                best = instanceMethods[0];
            }
            else if (instanceMethods.Count > 1) {
                Type[] bestParams = new Type[0];
                Func<Type[], Type[], bool> isAssignableFrom = (a, b) => {
                    for (int i = 0; i < a.Length; i++) {
                        if (!a[i].IsAssignableFrom(b[i])) return false;
                    }
                    return true;
                };
                foreach (var method in instanceMethods) {
                    Type[] mParams = method.GetParameters().Select(x => x.ParameterType).ToArray();
                    if (isAssignableFrom(mParams, paramTypes)) {
                        if (best == null || isAssignableFrom(bestParams, mParams)) {
                            best = method;
                            //bestIsAsync = methodIsAsync;
                            bestParams = mParams;
                        }
                    }
                }
            }
            return best;
        }
        // JSInProcessRuntime
        private static Lazy<MethodInfo> IJSInProcessRuntime_Invoke = new Lazy<MethodInfo>(() => GetBestInstanceMethod(typeof(JSInProcessRuntime), "Invoke", new Type[] { typeof(string), typeof(object[]) }, 1));
        private static Dictionary<Type, MethodInfo> GenericInvokeMethods { get; } = new Dictionary<Type, MethodInfo>();
        private static MethodInfo GetJSRuntimeInvoke(Type type) {
            if (GenericInvokeMethods.TryGetValue(type, out MethodInfo generic)) return generic;
            return GenericInvokeMethods[type] = IJSInProcessRuntime_Invoke.Value.MakeGenericMethod(type);
        }
    }
}
