using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Internal;

namespace SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey
{
    /// <summary>
    /// IJSInProcessObjectReference extensions methods
    /// </summary>
    public static class IJSInProcessObjectReferenceExtensionsAnyKey
    {
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public static bool JSEquals(this IJSInProcessObjectReference _ref, object key, object? obj2, bool full = false) => BlazorJSInterop.ObjectPropertyEquals(_ref, key, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        public static string TypeOf(this IJSInProcessObjectReference _ref, object key) => BlazorJSInterop.ObjectPropertyTypeOf(_ref, key);
        /// <summary>
        /// Returns the constructor?.name of the target
        /// </summary>
        public static string? ConstructorName(this IJSInProcessObjectReference _ref, object key) => BlazorJSInterop.ObjectPropertyConstructorName(_ref, key);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public static string[] ConstructorNames(this IJSInProcessObjectReference _ref, object key) => BlazorJSInterop.ObjectPropertyConstructorNames(_ref, key);
        /// <summary>
        /// Returns the target's property string keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public static List<string> Keys(this IJSInProcessObjectReference _ref, object key, bool hasOwnProperty = false) => BlazorJSInterop.ObjectPropertyKeys(_ref, key, hasOwnProperty);
        /// <summary>
        /// Returns true if the property name === undefined
        /// </summary>
        public static bool IsUndefined(this IJSInProcessObjectReference _ref, object key) => _ref.TypeOf(key) == "undefined";
        /// <summary>
        /// Returns key in target
        /// </summary>
        public static bool In(this IJSInProcessObjectReference _ref, object key) => BlazorJSInterop.ObjectPropertyIn(_ref, key);
        /// <summary>
        /// Set a property value
        /// </summary>
        public static void Set(this IJSInProcessObjectReference _ref, object key, object? value) => BlazorJSInterop.ObjectPropertySet(_ref, key, value);
        /// <summary>
        /// Deletes the target
        /// </summary>
        public static bool Delete(this IJSInProcessObjectReference _ref, object key) => BlazorJSInterop.ObjectPropertyDelete(_ref, key);
        /// <summary>
        /// Get a property value
        /// </summary>
        public static T Get<T>(this IJSInProcessObjectReference _ref, object key) => BlazorJSInterop.ObjectPropertyGet<T>(_ref, key);
        /// <summary>
        /// Get a property value
        /// </summary>
        public static object? Get(this IJSInProcessObjectReference _ref, Type returnType, object key) => BlazorJSInterop.ObjectPropertyGet(returnType, _ref, key);
        /// <summary>
        /// Get a property async value
        /// </summary>
        public static Task<T> GetAsync<T>(this IJSInProcessObjectReference _ref, object key) => BlazorJSInterop.ObjectPropertyGet<Task<T>>(_ref, key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T CallApply<T>(this IJSInProcessObjectReference _ref, object key, object?[]? args = null) => BlazorJSInterop.ObjectPropertyCall<T>(_ref, key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? CallApply(this IJSInProcessObjectReference _ref, Type returnType, object key, object?[]? args = null) => BlazorJSInterop.ObjectPropertyCall(returnType, _ref, key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallApplyVoid(this IJSInProcessObjectReference _ref, object key, object?[]? args = null) => BlazorJSInterop.ObjectPropertyCallVoid(_ref, key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallApplyAsync<T>(this IJSInProcessObjectReference _ref, object key, object?[]? args = null) => _ref.CallApply<Task<T>>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallApplyVoidAsync(this IJSInProcessObjectReference _ref, object key, object?[]? args = null) => _ref.CallApply<Task>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key) => _ref.CallApply<T>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0) => _ref.CallApply<T>(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1) => _ref.CallApply<T>(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _ref.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key) => _ref.CallApplyVoid(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0) => _ref.CallApplyVoid(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _ref.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key) => _ref.CallApplyAsync<T>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0) => _ref.CallApplyAsync<T>(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _ref.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key) => _ref.CallApplyVoidAsync(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0) => _ref.CallApplyVoidAsync(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _ref.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key) => _ref.CallApply(returnType, key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0) => _ref.CallApply(returnType, key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _ref.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
    }
}
