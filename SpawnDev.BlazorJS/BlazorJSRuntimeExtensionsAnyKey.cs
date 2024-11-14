using SpawnDev.BlazorJS.Internal;

namespace SpawnDev.BlazorJS.BlazorJSRuntimeAnyKey
{
    /// <summary>
    /// Adds methods to BlazorJSRuntime that allow any object as a key
    /// </summary>
    public static class BlazorJSRuntimeExtensionsAnyKey
    {
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public static bool JSEquals(this BlazorJSRuntime _this, object key, object? obj2, bool full = false) => BlazorJSInterop.GlobalPropertyEquals(key, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        public static string TypeOf(this BlazorJSRuntime _this, object key) => BlazorJSInterop.GlobalPropertyTypeOf(key);
        /// <summary>
        /// Returns the constructor?.name of the target
        /// </summary>
        public static string? ConstructorName(this BlazorJSRuntime _this, object key) => BlazorJSInterop.GlobalPropertyConstructorName(key);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public static string[] ConstructorNames(this BlazorJSRuntime _this, object key) => BlazorJSInterop.GlobalPropertyConstructorNames(key);
        /// <summary>
        /// Returns the target's property string keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public static List<string> Keys(this BlazorJSRuntime _this, object key, bool hasOwnProperty = false) => BlazorJSInterop.GlobalPropertyKeys(key, hasOwnProperty);
        /// <summary>
        /// Returns true if the property name === undefined
        /// </summary>
        public static bool IsUndefined(this BlazorJSRuntime _this, object key) => _this.TypeOf(key) == "undefined";
        /// <summary>
        /// Returns key in target
        /// </summary>
        public static bool In(this BlazorJSRuntime _this, object key) => BlazorJSInterop.GlobalPropertyIn(key);
        /// <summary>
        /// Set a property value
        /// </summary>
        public static void Set(this BlazorJSRuntime _this, object key, object? value) => BlazorJSInterop.GlobalPropertySet(key, value);
        /// <summary>
        /// Deletes the target
        /// </summary>
        public static bool Delete(this BlazorJSRuntime _this, object key) => BlazorJSInterop.GlobalPropertyDelete(key);
        /// <summary>
        /// Get a property value
        /// </summary>
        public static T Get<T>(this BlazorJSRuntime _this, object key) => BlazorJSInterop.GlobalPropertyGet<T>(key);
        /// <summary>
        /// Get a property value
        /// </summary>
        public static object? Get(this BlazorJSRuntime _this, Type returnType, object key) => BlazorJSInterop.GlobalPropertyGet(returnType, key);
        /// <summary>
        /// Get a property async value
        /// </summary>
        public static Task<T> GetAsync<T>(this BlazorJSRuntime _this, object key) => BlazorJSInterop.GlobalPropertyGet<Task<T>>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T CallApply<T>(this BlazorJSRuntime _this, object key, object?[]? args = null) => BlazorJSInterop.GlobalPropertyCall<T>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? CallApply(this BlazorJSRuntime _this, Type returnType, object key, object?[]? args = null) => BlazorJSInterop.GlobalPropertyCall(returnType, key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallApplyVoid(this BlazorJSRuntime _this, object key, object?[]? args = null) => BlazorJSInterop.GlobalPropertyCallVoid(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallApplyAsync<T>(this BlazorJSRuntime _this, object key, object?[]? args = null) => _this.CallApply<Task<T>>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallApplyVoidAsync(this BlazorJSRuntime _this, object key, object?[]? args = null) => _this.CallApply<Task>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key) => _this.CallApply<T>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0) => _this.CallApply<T>(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1) => _this.CallApply<T>(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static T Call<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _this.CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key) => _this.CallApplyVoid(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0) => _this.CallApplyVoid(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1) => _this.CallApplyVoid(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static void CallVoid(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _this.CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key) => _this.CallApplyAsync<T>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0) => _this.CallApplyAsync<T>(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task<T> CallAsync<T>(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _this.CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key) => _this.CallApplyVoidAsync(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0) => _this.CallApplyVoidAsync(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static Task CallVoidAsync(this BlazorJSRuntime _this, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _this.CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key) => _this.CallApply(returnType, key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0) => _this.CallApply(returnType, key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1) => _this.CallApply(returnType, key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public static object? Call(this BlazorJSRuntime _this, Type returnType, object key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => _this.CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
    }
}
