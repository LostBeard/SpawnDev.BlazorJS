﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public static partial class JS
    {

        public static List<string> GetPropertyNames(this IJSInProcessObjectReference _ref, bool hasOwnProperty = false) => _JSInteropCall<List<string>>("JSInterop._getPropertyNames", _ref, null, hasOwnProperty);
        public static string PropertyType(this IJSInProcessObjectReference _ref, string identifier = "") => _JSInteropCall<string>("JSInterop._typeof", _ref, identifier);
        public static string PropertyInstanceOf(this IJSInProcessObjectReference _ref, string identifier = "") => _JSInteropCall<string>("JSInterop._instanceof", _ref, identifier);

        #region IJSInProcessObjectReference Base Accessors
        public static void Set(this IJSInProcessObjectReference targetObject, string identifier, object? value) => _JSInteropCallVoid("_set", targetObject, identifier, value);
        public static T Get<T>(this IJSInProcessObjectReference targetObject, string identifier) => _JSInteropCall<T>("_get", targetObject, identifier);
        public static T Get<T>(this IJSInProcessObjectReference targetObject, int identifier) => _JSInteropCall<T>("_get", targetObject, identifier);
        public static object? Get(this IJSInProcessObjectReference targetObject, Type returnType, string identifier) => _JSInteropCall(returnType, "_get", targetObject, identifier);
        public static object? Get(this IJSInProcessObjectReference targetObject, Type returnType, int identifier) => _JSInteropCall(returnType, "_get", targetObject, identifier);

        #region IJSInProcessObjectReference Get Async
        public static ValueTask<T> GetAsync<T>(this IJSInProcessObjectReference targetObject, string identifier) => _JSInteropCallAsync<T>("_get", targetObject, identifier);
        public static ValueTask<object?> GetAsync(this IJSInProcessObjectReference targetObject, Type returnType, string identifier)=> _JSInteropCallAsync(returnType, "_get", targetObject, identifier);
        #endregion
        #region IJSInProcessObjectReference Call Sync
        public static T CallApply<T>(this IJSInProcessObjectReference targetObject, string identifier, object?[]? args = null) => _JSInteropCall<T>("_call", targetObject, identifier, args);
        public static object? CallApply(this IJSInProcessObjectReference targetObject, Type returnType, string identifier, object?[]? args = null) => _JSInteropCall(returnType, "_call", targetObject, identifier, args);
        public static void CallApplyVoid(this IJSInProcessObjectReference targetObject, string identifier, object?[]? args = null) => _JSInteropCallVoid("_call", targetObject, identifier, args);
        #endregion
        #region IJSInProcessObjectReference Call Async
        public static ValueTask<T> CallApplyAsync<T>(this IJSInProcessObjectReference targetObject, string identifier, object?[]? args = null) => _JSInteropCallAsync<T>("_call", targetObject, identifier, args);
        public static ValueTask<object?> CallApplyAsync(this IJSInProcessObjectReference targetObject, Type returnType, string identifier, object?[]? args = null) => _JSInteropCallAsync(returnType, "_call", targetObject, identifier, args);
        public static ValueTask CallApplyVoidAsync(this IJSInProcessObjectReference targetObject, string identifier, object?[]? args = null) => _JSInteropCallVoidAsync("_call", targetObject, identifier, args);
        #endregion
        #endregion

        // call with up to 10 arguments
        // used instead of "params" becuase params has an issue that will never be fixed thata can cause unexpected behavior
        // (Example: if a single argument of an array of string is passed, the params variable will be an array of string instead of a 2 dimensiaonal array with the first item being the array of strings passed) 
        #region IJSInProcessObjectReference Call Sync 
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier) => CallApply<T>(_ref, identifier);
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0) => CallApply<T>(_ref, identifier, new object?[] { arg0 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier) => CallApply(_ref, returnType, identifier);
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0) => CallApply(_ref, returnType, identifier, new object?[] { arg0 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier) => CallApplyVoid(_ref, identifier);
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0) => CallApplyVoid(_ref, identifier, new object?[] { arg0 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        #endregion


        #region IJSInProcessObjectReference Call Async
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier) => CallApplyAsync<T>(_ref, identifier);
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static ValueTask<T> CallAsync<T>(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier) => CallApplyAsync(_ref, returnType, identifier);
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static ValueTask<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier) => CallApplyVoidAsync(_ref, identifier);
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static ValueTask CallVoidAsync(this IJSInProcessObjectReference _ref, string identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });


        #endregion

    }
}
