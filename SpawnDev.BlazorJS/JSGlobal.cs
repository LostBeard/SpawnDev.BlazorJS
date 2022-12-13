using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public static partial class JS
    {
        #region Global Base Accessors
        public static void Set(string identifier, object? value) => _JSInteropCallVoid("_setGlobal", identifier, value);
         #region Global Get Sync
        public static T Get<T>(string identifier) => _JSInteropCall<T>("_getGlobal", identifier);
        //public static IJSInProcessObjectReference GetJSRef(string identifier) => _JSInteropCall<IJSInProcessObjectReference>("_getGlobal", identifier);
        public static object? Get(Type returnType, string identifier) => _JSInteropCall(returnType, "_getGlobal", identifier);
        #endregion
        #region Global Get Async
        public static ValueTask<T> GetAsync<T>(string identifier) => _JSInteropCallAsync<T>("_getGlobal", identifier);
        public static ValueTask<object?> GetAsync(Type returnType, string identifier) => _JSInteropCallAsync(returnType, "_getGlobal", identifier);
        #endregion
        #region Global Call Sync
        public static T CallApply<T>(string identifier, object?[]? args = null) => _JSInteropCall<T>("_callGlobal", identifier, args);
        public static object? CallApply(Type returnType, string identifier, object?[]? args = null) => _JSInteropCall(returnType, "_callGlobal", identifier, args);
        public static void CallApplyVoid(string identifier, object?[]? args = null) => _JSInteropCallVoid("_callVoidGlobal", identifier, args);
        #endregion
        #region Global Call Async
        public static ValueTask<T> CallApplyAsync<T>(string identifier, object?[]? args = null) => _JSInteropCallAsync<T>("_callGlobal", identifier, args);
        public static ValueTask<object?> CallApplyAsync(Type returnType, string identifier, object?[]? args = null) => _JSInteropCallAsync(returnType, "_callGlobal", identifier, args);
        public static ValueTask CallApplyVoidAsync(string identifier, object?[]? args = null) => _JSInteropCallVoidAsync("_callVoidGlobal", identifier, args);
        #endregion
        #endregion

        public static T Call<T>(string identifier) => CallApply<T>(identifier);
        public static T Call<T>(string identifier, object? arg0) => CallApply<T>(identifier, new object?[] { arg0 });
        public static T Call<T>(string identifier, object? arg0, object? arg1) => CallApply<T>(identifier, new object?[] { arg0, arg1 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static T Call<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static object? Call(Type returnType, string identifier) => CallApply(returnType, identifier);
        public static object? Call(Type returnType, string identifier, object? arg0) => CallApply(returnType, identifier, new object?[] { arg0 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1) => CallApply(returnType, identifier, new object?[] { arg0, arg1 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static object? Call(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static void CallVoid(string identifier) => CallApplyVoid(identifier);
        public static void CallVoid(string identifier, object? arg0) => CallApplyVoid(identifier, new object?[] { arg0 });
        public static void CallVoid(string identifier, object? arg0, object? arg1) => CallApplyVoid(identifier, new object?[] { arg0, arg1 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static void CallVoid(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoid(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });



        public static ValueTask<T> CallAsync<T>(string identifier) => CallApplyAsync<T>(identifier);
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0) => CallApplyAsync<T>(identifier, new object?[] { arg0 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static ValueTask<T> CallAsync<T>(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyAsync<T>(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static ValueTask<object?> CallAsync(Type returnType, string identifier) => CallApplyAsync(returnType, identifier);
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0) => CallApplyAsync(returnType, identifier, new object?[] { arg0 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static ValueTask<object?> CallAsync(Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyAsync(returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static ValueTask CallVoidAsync(string identifier) => CallApplyVoidAsync(identifier);
        public static ValueTask CallVoidAsync(string identifier, object? arg0) => CallApplyVoidAsync(identifier, new object?[] { arg0 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static ValueTask CallVoidAsync(string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoidAsync(identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });


    }
}
