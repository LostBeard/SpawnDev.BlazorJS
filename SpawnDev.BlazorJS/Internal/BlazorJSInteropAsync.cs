using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using SpawnDev.BlazorJS.RemoteJSRuntime;

namespace SpawnDev.BlazorJS.Internal
{
    /// <summary>
    /// Provides async access to the SpawnDev.BlazorJS javascript interop library 'globalThis.blazorJSInterop' using IJSRuntime which is usable with both server and webassembly rendering<br/>
    /// Async version of BlazorJSInterop<br/>
    /// This class is not static and must be instantiated. It can be used as a service via dependency injection.
    /// </summary>
    public class BlazorJSInteropAsync
    {
        const string JSInvokeMethodName = "blazorJSInterop.Invoke";
        const string JSInvokeAsyncMethodName = "blazorJSInterop.InvokeAsync";
        IJSRuntime JSR;
        JSRuntimeSerializerOptionsInfo JSRuntimeSerializerOptionsInfo;
        /// <summary>
        /// Create new instance
        /// </summary>
        /// <param name="jsr"></param>
        public BlazorJSInteropAsync(IJSRuntime jsr)
        {
            JSR = jsr;
            JSRuntimeSerializerOptionsInfo = new JSRuntimeSerializerOptionsInfo(JSR);
        }
        /// <summary>
        /// Creates an instance of BlazorJSInteropAsync using the specified IJSRuntime
        /// </summary>
        /// <param name="jsr"></param>
        /// <returns></returns>
        public static BlazorJSInteropAsync With(IJSRuntime jsr) => new BlazorJSInteropAsync(jsr);
        #region Global Property methods
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public Task<bool> GlobalPropertyEquals(object key, object? obj2, bool full) => invoke<bool>(nameof(GlobalPropertyEquals), key, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        /// <param name="key">The property key or key path</param>
        /// <returns>string</returns>
        public Task<string> GlobalPropertyTypeOf(object key) => invoke<string>(nameof(GlobalPropertyTypeOf), key);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public Task<string?> GlobalPropertyConstructorName(object key) => invoke<string?>(nameof(GlobalPropertyConstructorName), key);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public Task<string[]> GlobalPropertyConstructorNames(object key) => invoke<string[]>(nameof(GlobalPropertyConstructorNames), key);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public Task<string?> GlobalConstructorName() => invoke<string?>(nameof(GlobalConstructorName));
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public Task<string[]> GlobalConstructorNames() => invoke<string[]>(nameof(GlobalConstructorNames));
        /// <summary>
        /// Equivalent to JSRuntime.Invoke, except here the args are an array
        /// </summary>
        public Task<T> GlobalPropertyCall<T>(object key, object?[]? args) => invoke<T>(nameof(GlobalPropertyCall), key, args);
        /// <summary>
        /// Equivalent to JSRuntime.Invoke, except here the args are an array
        /// </summary>
        public Task<object?> GlobalPropertyCall(Type returnType, object key, object?[]? args) => invoke(returnType, nameof(GlobalPropertyCall), key, args);
        /// <summary>
        /// Equivalent to JSRuntime.InvokeVoid, except here the args are an array
        /// </summary>
        public Task GlobalPropertyCallVoid(object key, object?[]? args) => invokeVoid(nameof(GlobalPropertyCall), key, args);
        /// <summary>
        /// Returns new instance as type T
        /// </summary>
        public Task<T> GlobalPropertyNew<T>(object key, object?[]? args) => invoke<T>(nameof(GlobalPropertyNew), key, args);
        /// <summary>
        /// Returns new instance as type returnType
        /// </summary>
        public Task<object> GlobalPropertyNew(Type returnType, object key, object?[]? args) => invoke(returnType, nameof(GlobalPropertyNew), key, args)!;
        /// <summary>
        /// Returns the a string[] representing the properties of the specified object<br/>
        /// non-string property keys are ignored
        /// </summary>
        public Task<List<string>> GlobalPropertyKeys(object key, bool hasOwnProperty) => invoke<List<string>>(nameof(GlobalPropertyKeys), key, hasOwnProperty);
        /// <summary>
        /// Returns the a string[] representing the properties of the specified object<br/>
        /// non-string property keys are ignored
        /// </summary>
        public Task<List<string>> GlobalKeys(bool hasOwnProperty) => invoke<List<string>>(nameof(GlobalKeys), hasOwnProperty);
        /// <summary>
        /// Returns target instanceof type
        /// </summary>
        public Task<bool> GlobalPropertyInstanceOf(object key, object type) => invoke<bool>(nameof(GlobalPropertyInstanceOf), key, type);
        /// <summary>
        /// Returns the target property as type T
        /// </summary>
        public Task<T> GlobalPropertyGet<T>(object key) => invoke<T>(nameof(GlobalPropertyGet), key);
        /// <summary>
        /// Returns the target property as type returnType
        /// </summary>
        public Task<object?> GlobalPropertyGet(Type returnType, object key) => invoke(returnType, nameof(GlobalPropertyGet), key);
        /// <summary>
        /// Sets a global property value
        /// </summary>
        public Task GlobalPropertySet(object key, object? value) => invokeVoid(nameof(GlobalPropertySet), key, value);
        /// <summary>
        /// Deletes a global property
        /// </summary>
        public Task<bool> GlobalPropertyDelete(object key) => invoke<bool>(nameof(GlobalPropertyDelete), key);
        /// <summary>
        /// Returns key in target
        /// </summary>
        public Task<bool> GlobalPropertyIn(object key) => invoke<bool>(nameof(GlobalPropertyIn), key);
        #endregion
        #region Object Property Methods
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public Task<bool> ObjectPropertyEquals(object obj, object key, object? obj2, bool full) => invoke<bool>(nameof(ObjectPropertyEquals), obj, key, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        public Task<string> ObjectPropertyTypeOf(object obj, object key) => invoke<string>(nameof(ObjectPropertyTypeOf), obj, key);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public Task<string?> ObjectPropertyConstructorName(object obj, object key) => invoke<string?>(nameof(ObjectPropertyConstructorName), obj, key);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public Task<string[]> ObjectPropertyConstructorNames(object obj, object key) => invoke<string[]>(nameof(ObjectPropertyConstructorNames), obj, key);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public Task<T> ObjectPropertyCall<T>(object obj, object key, object?[]? args) => invoke<T>(nameof(ObjectPropertyCall), obj, key, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public object? ObjectPropertyCall(Type returnType, object obj, object key, object?[]? args) => invoke(returnType, nameof(ObjectPropertyCall), obj, key, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public Task ObjectPropertyCallVoid(object obj, object key, object?[]? args) => invokeVoid(nameof(ObjectPropertyCall), obj, key, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public Task<T> ObjectPropertyNew<T>(object obj, object key, object?[]? args) => invoke<T>(nameof(ObjectPropertyNew), obj, key, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public Task<object> ObjectPropertyNew(Type returnType, object obj, object key, object?[]? args) => invoke(returnType, nameof(ObjectPropertyNew), obj, key, args)!;
        /// <summary>
        /// Returns a list of the object's string property keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public Task<List<string>> ObjectPropertyKeys(object obj, object key, bool hasOwnProperty) => invoke<List<string>>(nameof(ObjectPropertyKeys), obj, key, hasOwnProperty);
        /// <summary>
        /// Returns target instanceof type
        /// </summary>
        public Task<bool> ObjectPropertyInstanceOf(object obj, object key, object type) => invoke<bool>(nameof(ObjectPropertyInstanceOf), obj, key, type);
        /// <summary>
        /// Returns the target
        /// </summary>
        public Task<T> ObjectPropertyGet<T>(object obj, object key) => invoke<T>(nameof(ObjectPropertyGet), obj, key);
        /// <summary>
        /// Returns the target
        /// </summary>
        public Task<object?> ObjectPropertyGet(Type returnType, object obj, object key) => invoke(returnType, nameof(ObjectPropertyGet), obj, key);
        /// <summary>
        /// Sets the target
        /// </summary>
        public Task ObjectPropertySet(object obj, object key, object? value) => invokeVoid(nameof(ObjectPropertySet), obj, key, value);
        /// <summary>
        /// Deletes the target
        /// </summary>
        public Task<bool> ObjectPropertyDelete(object obj, object key) => invoke<bool>(nameof(ObjectPropertyDelete), obj, key);
        /// <summary>
        /// Returns key in target
        /// </summary>
        public Task<bool> ObjectPropertyIn(object obj, object key) => invoke<bool>(nameof(ObjectPropertyIn), obj, key);
        #endregion
        #region Object Methods
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public Task<bool> ObjectEquals(object? obj, object? obj2, bool full) => invoke<bool>(nameof(ObjectEquals), obj, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        public Task<string> ObjectTypeOf(object? obj) => invoke<string>(nameof(ObjectTypeOf), obj);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public Task<string?> ObjectConstructorName(object obj) => invoke<string?>(nameof(ObjectConstructorName), obj);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public Task<string[]> ObjectConstructorNames(object obj) => invoke<string[]>(nameof(ObjectConstructorNames), obj);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public Task<T> ObjectCall<T>(object fnObj, object?[]? args) => invoke<T>(nameof(ObjectCall), fnObj, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public object? ObjectCall(Type returnType, object fnObj, object?[]? args) => invoke(returnType, nameof(ObjectCall), fnObj, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public Task ObjectCallVoid(object fnObj, object?[]? args) => invokeVoid(nameof(ObjectCall), fnObj, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public Task<T> ObjectNew<T>(object obj, object?[]? args) => invoke<T>(nameof(ObjectNew), obj, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public Task<object> ObjectNew(Type returnType, object obj, object?[]? args) => invoke(returnType, nameof(ObjectNew), obj, args)!;
        /// <summary>
        /// Returns a list of the object's string property keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public Task<List<string>> ObjectKeys(object obj, bool hasOwnProperty) => invoke<List<string>>(nameof(ObjectKeys), obj, hasOwnProperty);
        /// <summary>
        /// Returns target instanceof type
        /// </summary>
        public Task<bool> ObjectInstanceOf(object obj, object objType) => invoke<bool>(nameof(ObjectInstanceOf), obj, objType);
        /// <summary>
        /// Returns the target
        /// </summary>
        public Task<T> ObjectGet<T>(object obj) => invoke<T>(nameof(ObjectGet), obj);
        /// <summary>
        /// Returns the target
        /// </summary>
        public object? ObjectGet(Type returnType, object? obj) => invoke(returnType, nameof(ObjectGet), obj);
        #endregion
        #region Callback methods
        /// <summary>
        /// Disposed a Callback by Callback.Id
        /// </summary>
        /// <param name="id"></param>
        internal Task DisposeCallback(string id) => invokeVoid(nameof(DisposeCallback), id);
        #endregion
        #region Invoke methods
        // ***************************************************************************************************************************
        // These methods are used as intermediaries for the other BlazorJSInterop calls so they can handle preparing the return value
        // ***************************************************************************************************************************
        private Task<T> invoke<T>(string fnName) => _invoke<T>(fnName, new object?[] { });
        private Task<T> invoke<T>(string fnName, object? arg1) => _invoke<T>(fnName, new object?[] { arg1 });
        private Task<T> invoke<T>(string fnName, object? arg1, object? arg2) => _invoke<T>(fnName, new object?[] { arg1, arg2 });
        private Task<T> invoke<T>(string fnName, object? arg1, object? arg2, object? arg3) => _invoke<T>(fnName, new object?[] { arg1, arg2, arg3 });
        private Task<T> invoke<T>(string fnName, object? arg1, object? arg2, object? arg3, object? arg4) => _invoke<T>(fnName, new object?[] { arg1, arg2, arg3, arg4 });
        private Task<T> invoke<T>(string fnName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _invoke<T>(fnName, new object?[] { arg1, arg2, arg3, arg4, arg5 });
        private Task<object?> invoke(Type returnType, string fnName) => _invoke(returnType, fnName, new object?[] { });
        private Task<object?> invoke(Type returnType, string fnName, object? arg1) => _invoke(returnType, fnName, new object?[] { arg1 });
        private Task<object?> invoke(Type returnType, string fnName, object? arg1, object? arg2) => _invoke(returnType, fnName, new object?[] { arg1, arg2 });
        private Task<object?> invoke(Type returnType, string fnName, object? arg1, object? arg2, object? arg3) => _invoke(returnType, fnName, new object?[] { arg1, arg2, arg3 });
        private Task<object?> invoke(Type returnType, string fnName, object? arg1, object? arg2, object? arg3, object? arg4) => _invoke(returnType, fnName, new object?[] { arg1, arg2, arg3, arg4 });
        private Task<object?> invoke(Type returnType, string fnName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _invoke(returnType, fnName, new object?[] { arg1, arg2, arg3, arg4, arg5 });
        private Task invokeVoid(string fnName) => _invokeVoid(fnName, new object?[] { });
        private Task invokeVoid(string fnName, object? arg1) => _invokeVoid(fnName, new object?[] { arg1 });
        private Task invokeVoid(string fnName, object? arg1, object? arg2) => _invokeVoid(fnName, new object?[] { arg1, arg2 });
        private Task invokeVoid(string fnName, object? arg1, object? arg2, object? arg3) => _invokeVoid(fnName, new object?[] { arg1, arg2, arg3 });
        private Task invokeVoid(string fnName, object? arg1, object? arg2, object? arg3, object? arg4) => _invokeVoid(fnName, new object?[] { arg1, arg2, arg3, arg4 });
        private Task invokeVoid(string fnName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _invokeVoid(fnName, new object?[] { arg1, arg2, arg3, arg4, arg5 });

        private async Task<T> _invoke<T>(string fnName, object?[]? args)
        {
            var jsCallResultType = JSRuntimeSerializerOptionsInfo.FromGeneric<T>();
            return await JSR.InvokeAsync<T>(JSInvokeAsyncMethodName, fnName, args, jsCallResultType);
        }
        private Task<object?> _invoke(Type returnType, string fnName, object?[]? args)
        {
            var jsCallResultType = JSRuntimeSerializerOptionsInfo.FromGeneric(returnType);
            return JSR.InvokeAsync(returnType, JSInvokeAsyncMethodName, fnName, args, jsCallResultType);
        }
        private async Task _invokeVoid(string fnName, object?[]? args)
        {
            await JSR.InvokeVoidAsync(JSInvokeAsyncMethodName, fnName, args);
        }
        #endregion
    }

}
