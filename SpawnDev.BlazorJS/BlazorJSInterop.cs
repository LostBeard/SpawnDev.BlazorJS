using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Low level Javascript interop used by SpawnDev.BlazorJS<br/>
    /// Most interop should be done using the BlazorJSRuntime service, JSObjects, and IJSInProcessObjectReferences
    /// </summary>
    public static class BlazorJSInterop
    {
        static IJSInProcessRuntime _js { get; } = BlazorJSRuntime._js;
        #region Global Property methods
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public static bool GlobalPropertyEquals(object key, object? obj2, bool full) => invoke<bool>(nameof(GlobalPropertyEquals), key, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        /// <param name="key">The property key or key path</param>
        /// <returns>string</returns>
        public static string GlobalPropertyTypeOf(object key) => invoke<string>(nameof(GlobalPropertyTypeOf), key);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public static string? GlobalPropertyConstructorName(object key) => invoke<string?>(nameof(GlobalPropertyConstructorName), key);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public static string[] GlobalPropertyConstructorNames(object key) => invoke<string[]>(nameof(GlobalPropertyConstructorNames), key);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public static string? GlobalConstructorName() => invoke<string?>(nameof(GlobalConstructorName));
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public static string[] GlobalConstructorNames() => invoke<string[]>(nameof(GlobalConstructorNames));
        /// <summary>
        /// Equivalent to JSRuntime.Invoke, except here the args are an array
        /// </summary>
        public static T GlobalPropertyCall<T>(object key, object?[]? args) => invoke<T>(nameof(GlobalPropertyCall), key, args);
        /// <summary>
        /// Equivalent to JSRuntime.Invoke, except here the args are an array
        /// </summary>
        public static object? GlobalPropertyCall(Type returnType, object key, object?[]? args) => invoke(returnType, nameof(GlobalPropertyCall), key, args);
        /// <summary>
        /// Equivalent to JSRuntime.InvokeVoid, except here the args are an array
        /// </summary>
        public static void GlobalPropertyCallVoid(object key, object?[]? args) => invokeVoid(nameof(GlobalPropertyCall), key, args);
        /// <summary>
        /// Returns new instance as type T
        /// </summary>
        public static T GlobalPropertyNew<T>(object key, object?[]? args) => invoke<T>(nameof(GlobalPropertyNew), key, args);
        /// <summary>
        /// Returns new instance as type returnType
        /// </summary>
        public static object GlobalPropertyNew(Type returnType, object key, object?[]? args) => invoke(returnType, nameof(GlobalPropertyNew), key, args)!;
        /// <summary>
        /// Returns the a string[] representing the properties of the specified object<br/>
        /// non-string property keys are ignored
        /// </summary>
        public static List<string> GlobalPropertyKeys(object key, bool hasOwnProperty) => invoke<List<string>>(nameof(GlobalPropertyKeys), key, hasOwnProperty);
        /// <summary>
        /// Returns the a string[] representing the properties of the specified object<br/>
        /// non-string property keys are ignored
        /// </summary>
        public static List<string> GlobalKeys(bool hasOwnProperty) => invoke<List<string>>(nameof(GlobalKeys), hasOwnProperty);
        /// <summary>
        /// Returns target instanceof type
        /// </summary>
        public static bool GlobalPropertyInstanceOf(object key, object type) => invoke<bool>(nameof(GlobalPropertyInstanceOf), key, type);
        /// <summary>
        /// Returns the target property as type T
        /// </summary>
        public static T GlobalPropertyGet<T>(object key) => invoke<T>(nameof(GlobalPropertyGet), key);
        /// <summary>
        /// Returns the target property as type returnType
        /// </summary>
        public static object? GlobalPropertyGet(Type returnType, object key) => invoke(returnType, nameof(GlobalPropertyGet), key);
        /// <summary>
        /// Sets a global property value
        /// </summary>
        public static void GlobalPropertySet(object key, object? value) => invokeVoid(nameof(GlobalPropertySet), key, value);
        /// <summary>
        /// Deletes a global property
        /// </summary>
        public static bool GlobalPropertyDelete(object key) => invoke<bool>(nameof(GlobalPropertyDelete), key);
        /// <summary>
        /// Returns key in target
        /// </summary>
        public static bool GlobalPropertyIn(object key) => invoke<bool>(nameof(GlobalPropertyIn), key);
        #endregion
        #region Object Property Methods
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public static bool ObjectPropertyEquals(object obj, object key, object? obj2, bool full) => invoke<bool>(nameof(ObjectPropertyEquals), obj, key, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        public static string ObjectPropertyTypeOf(object obj, object key) => invoke<string>(nameof(ObjectPropertyTypeOf), obj, key);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public static string? ObjectPropertyConstructorName(object obj, object key) => invoke<string?>(nameof(ObjectPropertyConstructorName), obj, key);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public static string[] ObjectPropertyConstructorNames(object obj, object key) => invoke<string[]>(nameof(ObjectPropertyConstructorNames), obj, key);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public static T ObjectPropertyCall<T>(object obj, object key, object?[]? args) => invoke<T>(nameof(ObjectPropertyCall), obj, key, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public static object? ObjectPropertyCall(Type returnType, object obj, object key, object?[]? args) => invoke(returnType, nameof(ObjectPropertyCall), obj, key, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public static void ObjectPropertyCallVoid(object obj, object key, object?[]? args) => invokeVoid(nameof(ObjectPropertyCall), obj, key, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public static T ObjectPropertyNew<T>(object obj, object key, object?[]? args) => invoke<T>(nameof(ObjectPropertyNew), obj, key, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public static object ObjectPropertyNew(Type returnType, object obj, object key, object?[]? args) => invoke(returnType, nameof(ObjectPropertyNew), obj, key, args)!;
        /// <summary>
        /// Returns a list of the object's string property keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public static List<string> ObjectPropertyKeys(object obj, object key, bool hasOwnProperty) => invoke<List<string>>(nameof(ObjectPropertyKeys), obj, key, hasOwnProperty);
        /// <summary>
        /// Returns target instanceof type
        /// </summary>
        public static bool ObjectPropertyInstanceOf(object obj, object key, object type) => invoke<bool>(nameof(ObjectPropertyInstanceOf), obj, key, type);
        /// <summary>
        /// Returns the target
        /// </summary>
        public static T ObjectPropertyGet<T>(object obj, object key) => invoke<T>(nameof(ObjectPropertyGet), obj, key);
        /// <summary>
        /// Returns the target
        /// </summary>
        public static object? ObjectPropertyGet(Type returnType, object obj, object key) => invoke(returnType, nameof(ObjectPropertyGet), obj, key);
        /// <summary>
        /// Sets the target
        /// </summary>
        public static void ObjectPropertySet(object obj, object key, object? value) => invokeVoid(nameof(ObjectPropertySet), obj, key, value);
        /// <summary>
        /// Deletes the target
        /// </summary>
        public static bool ObjectPropertyDelete(object obj, object key) => invoke<bool>(nameof(ObjectPropertyDelete), obj, key);
        /// <summary>
        /// Returns key in target
        /// </summary>
        public static bool ObjectPropertyIn(object obj, object key) => invoke<bool>(nameof(ObjectPropertyIn), obj, key);
        #endregion
        #region Object Methods
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public static bool ObjectEquals(object? obj, object? obj2, bool full) => invoke<bool>(nameof(ObjectEquals), obj, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        public static string ObjectTypeOf(object? obj) => invoke<string>(nameof(ObjectTypeOf), obj);
        /// <summary>
        /// Returns target?.constructor?.name
        /// </summary>
        public static string? ObjectConstructorName(object obj) => invoke<string?>(nameof(ObjectConstructorName), obj);
        /// <summary>
        /// Returns a string[] containing the constructor.name property for each unique entry in the prototype chain
        /// </summary>
        public static string[] ObjectConstructorNames(object obj) => invoke<string[]>(nameof(ObjectConstructorNames), obj);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public static T ObjectCall<T>(object fnObj, object?[]? args) => invoke<T>(nameof(ObjectCall), fnObj, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public static object? ObjectCall(Type returnType, object fnObj, object?[]? args) => invoke(returnType, nameof(ObjectCall), fnObj, args);
        /// <summary>
        /// Calls the target function
        /// </summary>
        public static void ObjectCallVoid(object fnObj, object?[]? args) => invokeVoid(nameof(ObjectCall), fnObj, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public static T ObjectNew<T>(object obj, object?[]? args) => invoke<T>(nameof(ObjectNew), obj, args);
        /// <summary>
        /// Returns new target(...args)
        /// </summary>
        public static object ObjectNew(Type returnType, object obj, object?[]? args) => invoke(returnType, nameof(ObjectNew), obj, args)!;
        /// <summary>
        /// Returns a list of the object's string property keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public static List<string> ObjectKeys(object obj, bool hasOwnProperty) => invoke<List<string>>(nameof(ObjectKeys), obj, hasOwnProperty);
        /// <summary>
        /// Returns target instanceof type
        /// </summary>
        public static bool ObjectInstanceOf(object obj, object objType) => invoke<bool>(nameof(ObjectInstanceOf), obj, objType);
        /// <summary>
        /// Returns the target
        /// </summary>
        public static T ObjectGet<T>(object obj) => invoke<T>(nameof(ObjectGet), obj);
        /// <summary>
        /// Returns the target
        /// </summary>
        public static object? ObjectGet(Type returnType, object? obj) => invoke(returnType, nameof(ObjectGet), obj);
        /// <summary>
        /// Returns the object as IJSInProcessObjectReference?[]?<br/>
        /// </summary>
        public static IJSInProcessObjectReference?[]? ObjectToDotNetRefArray(IJSInProcessObjectReference obj)
        {
            if (obj == null) return null;
            var ids = invoke<long[]?>(nameof(ObjectToDotNetRefArray), obj);
            if (ids == null) return null;
            var ret = new IJSInProcessObjectReference?[ids.Length];
            for (var i = 0; i < ret.Length; i++)
            {
                var id = ids[i];
                ret[i] = id < 0 ? null : _js.CreateIJSInProcessObjectReference(id);
            }
            return ret;
        }
        /// <summary>
        /// Returns the object as JSObject?[]? of type T<br/>
        /// </summary>
        public static T?[]? ObjectToJSObjectArray<T>(IJSInProcessObjectReference? obj) where T : JSObject
        {
            if (obj == null) return null;
            var ids = invoke<long[]?>(nameof(ObjectToDotNetRefArray), obj);
            if (ids == null) return null;
            var ret = new T?[ids.Length];
            for (var i = 0; i < ret.Length; i++)
            {
                var id = ids[i];
                ret[i] = id < 0 ? null : _js.CreateJSObject<T>(id);
            }
            return ret;
        }
        #endregion
        #region Callback methods
        /// <summary>
        /// Disposed a Callback by Callback.Id
        /// </summary>
        /// <param name="id"></param>
        internal static void DisposeCallback(string id) => invokeVoid(nameof(DisposeCallback), id);
        #endregion
        #region Invoke methods
        // ***************************************************************************************************************************
        // These methods are used as intermediaries for the other BlazorJSInterop calls so they can handle preparing the return value
        // ***************************************************************************************************************************
        private static T invoke<T>(string fnName) => _invoke<T>(fnName, new object?[] { });
        private static T invoke<T>(string fnName, object? arg1) => _invoke<T>(fnName, new object?[] { arg1 });
        private static T invoke<T>(string fnName, object? arg1, object? arg2) => _invoke<T>(fnName, new object?[] { arg1, arg2 });
        private static T invoke<T>(string fnName, object? arg1, object? arg2, object? arg3) => _invoke<T>(fnName, new object?[] { arg1, arg2, arg3 });
        private static T invoke<T>(string fnName, object? arg1, object? arg2, object? arg3, object? arg4) => _invoke<T>(fnName, new object?[] { arg1, arg2, arg3, arg4 });
        private static T invoke<T>(string fnName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _invoke<T>(fnName, new object?[] { arg1, arg2, arg3, arg4, arg5 });
        private static object? invoke(Type returnType, string fnName) => _invoke(returnType, fnName, new object?[] { });
        private static object? invoke(Type returnType, string fnName, object? arg1) => _invoke(returnType, fnName, new object?[] { arg1 });
        private static object? invoke(Type returnType, string fnName, object? arg1, object? arg2) => _invoke(returnType, fnName, new object?[] { arg1, arg2 });
        private static object? invoke(Type returnType, string fnName, object? arg1, object? arg2, object? arg3) => _invoke(returnType, fnName, new object?[] { arg1, arg2, arg3 });
        private static object? invoke(Type returnType, string fnName, object? arg1, object? arg2, object? arg3, object? arg4) => _invoke(returnType, fnName, new object?[] { arg1, arg2, arg3, arg4 });
        private static object? invoke(Type returnType, string fnName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _invoke(returnType, fnName, new object?[] { arg1, arg2, arg3, arg4, arg5 });
        private static void invokeVoid(string fnName) => _invokeVoid(fnName, new object?[] { });
        private static void invokeVoid(string fnName, object? arg1) => _invokeVoid(fnName, new object?[] { arg1 });
        private static void invokeVoid(string fnName, object? arg1, object? arg2) => _invokeVoid(fnName, new object?[] { arg1, arg2 });
        private static void invokeVoid(string fnName, object? arg1, object? arg2, object? arg3) => _invokeVoid(fnName, new object?[] { arg1, arg2, arg3 });
        private static void invokeVoid(string fnName, object? arg1, object? arg2, object? arg3, object? arg4) => _invokeVoid(fnName, new object?[] { arg1, arg2, arg3, arg4 });
        private static void invokeVoid(string fnName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => _invokeVoid(fnName, new object?[] { arg1, arg2, arg3, arg4, arg5 });
        private static T _invoke<T>(string fnName, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("blazorJSInterop.Invoke", fnName, args, jsCallResultType);
        }
        private static object? _invoke(Type returnType, string fnName, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "blazorJSInterop.Invoke", fnName, args, jsCallResultType);
        }
        private static void _invokeVoid(string fnName, object?[]? args)
        {
            _js.InvokeVoid("blazorJSInterop.Invoke", fnName, args);
        }
        #endregion
    }
}
