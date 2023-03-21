using Microsoft.JSInterop;
using System.Reflection;

namespace SpawnDev.BlazorJS {
    public static class IJSInProcessRuntimeExtensions {
        public static void Set(this IJSInProcessRuntime _js, string identifier, object? value) => JSInterop.SetGlobal(identifier, value);
        public static T? Get<T>(this IJSInProcessRuntime _js, string identifier) => JSInterop.GetGlobal<T>(identifier);
        public static object? Get(this IJSInProcessRuntime _js, Type returnType, string identifier) => JSInterop.GetGlobal(returnType, identifier);
        public static Task<T> GetAsync<T>(this IJSInProcessRuntime _js, string identifier) => JSInterop.GetGlobalAsync<T>(identifier);
        public static T CallApply<T>(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JSInterop.CallGlobal<T>(identifier, args);
        public static object? CallApply(this IJSInProcessRuntime _js, Type returnType, string identifier, object?[]? args = null) => JSInterop.CallGlobal(returnType, identifier, args);
        public static void CallApplyVoid(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JSInterop.CallGlobalVoid(identifier, args);
        public static Task<T> CallApplyAsync<T>(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JSInterop.CallGlobalAsync<T>(identifier, args);
        public static Task CallApplyVoidAsync(this IJSInProcessRuntime _js, string identifier, object?[]? args = null) => JSInterop.CallGlobalVoidAsync(identifier, args);

        // call with up to 10 arguments
        // used instead of "params" because params has an issue that will never be fixed that can cause unexpected behavior
        // (Example: if a single argument of string[] is passed, the params variable will be an array of string instead of a 2 dimensiaonal array with the first item being the array of strings passed) 
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier) => JSInterop.CallGlobal<T>(identifier, null);
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static T Call<T>(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JSInterop.CallGlobal<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static void CallVoid(this IJSInProcessRuntime _js, string identifier) => JSInterop.CallGlobalVoid(identifier, null);
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static void CallVoid(this IJSInProcessRuntime _js, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JSInterop.CallGlobalVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier) => JSInterop.CallApply(returnType, identifier);
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        //public static object? Call(this IJSInProcessRuntime _js, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => JSInterop.CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static object? Invoke(this IJSInProcessRuntime _js, Type returnType, string identifier, params object[] args) => GetJSRuntimeInvoke(returnType).Invoke(_js, new object[] { identifier, args });
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
        // JSInProcessRuntime
        private static Lazy<MethodInfo> IJSInProcessRuntime_Invoke = new Lazy<MethodInfo>(() => GetBestInstanceMethod(typeof(JSInProcessRuntime), "Invoke", new Type[] { typeof(string), typeof(object[]) }, 1));
        private static Dictionary<Type, MethodInfo> GenericInvokeMethods { get; } = new Dictionary<Type, MethodInfo>();
        private static MethodInfo GetJSRuntimeInvoke(Type type)
        {
            if (GenericInvokeMethods.TryGetValue(type, out MethodInfo generic)) return generic;
            return GenericInvokeMethods[type] = IJSInProcessRuntime_Invoke.Value.MakeGenericMethod(type);
        }
    }
}
