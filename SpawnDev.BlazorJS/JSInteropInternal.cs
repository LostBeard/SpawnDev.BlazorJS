using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;

namespace SpawnDev.BlazorJS
{
    public static partial class JSInterop
    {
        static IJSInProcessRuntime _js = BlazorJSRuntime._js;

        internal static void SetPromiseThenCatch<T>(Promise<T> promise, ActionCallback<T> thenCallback, ActionCallback<string> catchCallback)
        {
            BlazorJSRuntime.JS.CallVoid("JSInterop.setPromiseThenCatch", promise, thenCallback, catchCallback);
        }
        internal static void SetPromiseThenCatch(Promise promise, ActionCallback thenCallback, ActionCallback<string> catchCallback)
        {
            BlazorJSRuntime.JS.CallVoid("JSInterop.setPromiseThenCatch", promise, thenCallback, catchCallback);
        }
        internal static void SetPromiseThenCatch<TResult>(Promise promise, ActionCallback<TResult> thenCallback, ActionCallback<string> catchCallback)
        {
            BlazorJSRuntime.JS.CallVoid("JSInterop.setPromiseThenCatch", promise, thenCallback, catchCallback);
        }

        // *********************************************************************************************************************
        //internal static void SetGlobal(string identifier, object? value) {
        //    _js.InvokeVoid("JSInterop._setGlobal", identifier, value);
        //}
        //internal static void SetGlobal(int identifier, object? value) {
        //    _js.InvokeVoid("JSInterop._setGlobal", identifier, value);
        //}
        //internal static void SetGlobal(long identifier, object? value)
        //{
        //    _js.InvokeVoid("JSInterop._setGlobal", identifier, value);
        //}
        internal static void SetGlobal(object identifier, object? value)
        {
            _js.InvokeVoid("JSInterop._setGlobal", identifier, value);
        }

        //internal static bool DeleteGlobal(string identifier)
        //{
        //    return _js.Invoke<bool>("JSInterop._deleteGlobal", identifier);
        //}

        internal static bool DeleteGlobal(object identifier)
        {
            return _js.Invoke<bool>("JSInterop._deleteGlobal", identifier);
        }

        internal static void CallGlobalVoid(object identifier, object?[]? args)
        {
            _js.InvokeVoid("JSInterop._callGlobal", identifier, args, JSCallResultType.JSVoidResult);
        }

        internal static Task CallGlobalVoidAsync(object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task>();
            return _js.Invoke<Task>("JSInterop._callGlobal", identifier, args, jsCallResultType);
        }

        internal static T CallGlobal<T>(object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("JSInterop._callGlobal", identifier, args, jsCallResultType);
        }

        internal static Task<T> CallGlobalAsync<T>(object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task<T>>();
            return _js.Invoke<Task<T>>("JSInterop._callGlobal", identifier, args, jsCallResultType);
        }

        internal static object? CallGlobal(Type returnType, object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "JSInterop._callGlobal", identifier, args, jsCallResultType);
        }

        internal static T GetGlobal<T>(object identifier)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("JSInterop._getGlobal", identifier, jsCallResultType);
        }

        internal static Task<T> GetGlobalAsync<T>(object identifier)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task<T>>();
            return _js.Invoke<Task<T>>("JSInterop._getGlobal", identifier, jsCallResultType);
        }

        internal static object? GetGlobal(Type returnType, object identifier)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "JSInterop._getGlobal", identifier, jsCallResultType);
        }

        internal static T Call<T>(IJSInProcessObjectReference targetObject, object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("JSInterop._call", targetObject, identifier, args, jsCallResultType);
        }

        internal static Task<T> CallAsync<T>(IJSInProcessObjectReference targetObject, object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task<T>>();
            return _js.Invoke<Task<T>>("JSInterop._call", targetObject, identifier, args, jsCallResultType);
        }

        internal static object? Call(Type returnType, IJSInProcessObjectReference targetObject, object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "JSInterop._call", targetObject, identifier, args, jsCallResultType);
        }

        internal static void CallVoid(IJSInProcessObjectReference targetObject, object identifier, object?[]? args)
        {
            _js.InvokeVoid("JSInterop._call", targetObject, identifier, args, JSCallResultType.JSVoidResult);
        }

        internal static Task CallVoidAsync(IJSInProcessObjectReference targetObject, object identifier, object?[]? args)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task>();
            return _js.Invoke<Task>("JSInterop._call", targetObject, identifier, args, jsCallResultType);
        }

        internal static T Get<T>(IJSInProcessObjectReference targetObject, object identifier)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("JSInterop._get", targetObject, identifier, jsCallResultType);
        }

        internal static Task<T> GetAsync<T>(IJSInProcessObjectReference targetObject, object identifier)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task<T>>();
            return _js.Invoke<Task<T>>("JSInterop._get", targetObject, identifier, jsCallResultType);
        }

        //internal static T Get<T>(IJSInProcessObjectReference targetObject, object identifier) {
        //    var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
        //    return _js.Invoke<T>("JSInterop._get", targetObject, identifier, jsCallResultType);
        //}

        //internal static Task<T> GetAsync<T>(IJSInProcessObjectReference targetObject, object identifier) {
        //    var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task<T>>();
        //    return _js.Invoke<Task<T>>("JSInterop._get", targetObject, identifier, jsCallResultType);
        //}

        internal static object? Get(Type returnType, IJSInProcessObjectReference targetObject, object identifier)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "JSInterop._get", targetObject, identifier, jsCallResultType);
        }

        //internal static Task<T> GetAsync<T>(IJSInProcessObjectReference targetObject, object identifier) {
        //    var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<Task<T>>();
        //    return _js.Invoke<Task<T>>("JSInterop._get", targetObject, identifier, jsCallResultType);
        //}

        //internal static T Get<T>(IJSInProcessObjectReference targetObject, object identifier) {
        //    var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
        //    return _js.Invoke<T>("JSInterop._get", targetObject, identifier, jsCallResultType);
        //}

        //internal static T Get<T>(IJSInProcessObjectReference targetObject, object identifier)
        //{
        //    var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
        //    return _js.Invoke<T>("JSInterop._get", targetObject, identifier, jsCallResultType);
        //}

        //internal static object? Get(Type returnType, IJSInProcessObjectReference targetObject, object identifier) {
        //    var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
        //    return _js.Invoke(returnType, "JSInterop._get", targetObject, identifier, jsCallResultType);
        //}

        internal static T?[]? ReturnArrayJSObjects<T>(IJSInProcessObjectReference? targetObject) where T : JSObject
        {
            if (targetObject == null) return null;
            var ids = CallGlobal<long[]?>("JSInterop._returnArrayJSObjectReferenceIds", new[] { targetObject });
            if (ids == null) return null;
            var ret = new T?[ids.Length];
            for (var i = 0; i < ret.Length; i++)
            {
                var id = ids[i];
                ret[i] = id < 0 ? null : _js.CreateJSObject<T>(id);
            }
            return ret;
        }

        internal static IJSInProcessObjectReference?[]? ReturnArrayJSObjectReferences(IJSInProcessObjectReference? targetObject)
        {
            if (targetObject == null) return null;
            var ids = CallGlobal<long[]?>("JSInterop._returnArrayJSObjectReferenceIds", new object?[] { targetObject });
            if (ids == null) return null;
            var ret = new IJSInProcessObjectReference?[ids.Length];
            for (var i = 0; i < ret.Length; i++)
            {
                var id = ids[i];
                ret[i] = id < 0 ? null : _js.CreateIJSInProcessObjectReference(id);
            }
            return ret;
        }

        internal static T ReturnMe<T>(object? obj1)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("JSInterop._returnMe", obj1, jsCallResultType);
        }

        internal static object? ReturnMe(Type returnType, object? obj1)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "JSInterop._returnMe", obj1, jsCallResultType);
        }

        internal static IJSInProcessObjectReference ReturnNew(IJSInProcessObjectReference targetObject, object?[]? args = null)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<IJSInProcessObjectReference>();
            return _js.Invoke<IJSInProcessObjectReference>("JSInterop._returnNew", targetObject, null, args, jsCallResultType);
        }

        internal static T ReturnNew<T>(IJSInProcessObjectReference targetObject, object?[]? args = null)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("JSInterop._returnNew", targetObject, null, args, jsCallResultType);
        }

        internal static object? ReturnNew(IJSInProcessObjectReference targetObject, Type returnType, object?[]? args = null)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "JSInterop._returnNew", targetObject, null, args, jsCallResultType);
        }

        internal static IJSInProcessObjectReference ReturnNew(string className, object?[]? args = null)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<IJSInProcessObjectReference>();
            return _js.Invoke<IJSInProcessObjectReference>("JSInterop._returnNew", null, className, args, jsCallResultType);
        }

        internal static T ReturnNew<T>(string className, object?[]? args = null)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric<T>();
            return _js.Invoke<T>("JSInterop._returnNew", null, className, args, jsCallResultType);
        }

        internal static object? ReturnNew(Type returnType, string className, object?[]? args = null)
        {
            var jsCallResultType = JSCallResultTypeHelperOverride.FromGeneric(returnType);
            return _js.Invoke(returnType, "JSInterop._returnNew", null, className, args, jsCallResultType);
        }

        internal static void Set(IJSInProcessObjectReference targetObject, object identifier, object? value)
        {
            _js.InvokeVoid("JSInterop._set", targetObject, identifier, value);
        }

        internal static void Delete(IJSInProcessObjectReference targetObject, object identifier)
        {
            _js.InvokeVoid("JSInterop._delete", targetObject, identifier);
        }

        //internal static void Set(IJSInProcessObjectReference targetObject, object identifier, object? value) {
        //    _js.InvokeVoid("JSInterop._set", targetObject, identifier, value);
        //}

        //internal static void Set(IJSInProcessObjectReference targetObject, object identifier, object? value)
        //{
        //    _js.InvokeVoid("JSInterop._set", targetObject, identifier, value);
        //}

        //internal static void Set(IJSInProcessObjectReference targetObject, object identifier, object? value)
        //{
        //    _js.InvokeVoid("JSInterop._set", targetObject, identifier, value);
        //}

        internal static void DisposeCallbacker(string callbackId)
        {
            _js.InvokeVoid("JSInterop.DisposeCallbacker", callbackId);
        }

        internal static bool IsEqual(object? obj1, object? obj2)
        {
            return _js.Invoke<bool>("JSInterop.__equals", obj1, obj2);
        }

        internal static string? TypeOf(object? obj, object? identifier)
        {
            return _js.Invoke<string?>("JSInterop._typeof", obj, identifier);
        }

        internal static string? InstanceOf(object? obj, object? identifier)
        {
            return _js.Invoke<string?>("JSInterop._instanceof", obj, identifier);
        }

        internal static string? GlobalTypeOf(object? identifier)
        {
            return _js.Invoke<string?>("JSInterop._typeofGlobal", identifier);
        }

        internal static string? GlobalInstanceOf(object? identifier)
        {
            return _js.Invoke<string?>("JSInterop._instanceofGlobal", identifier);
        }

        //internal static string TypeOf(object? obj, int identifier)
        //{
        //    return _js.Invoke<string>("JSInterop._typeof", obj, identifier);
        //}

        //internal static string InstanceOf(object? obj, int identifier)
        //{
        //    return _js.Invoke<string>("JSInterop._instanceof", obj, identifier);
        //}

        internal static List<string> GetPropertyNames(object? obj, object? identifier = null, bool hasOwnProperty = true)
        {
            return _js.Invoke<List<string>>("JSInterop._getPropertyNames", obj, identifier, hasOwnProperty);
        }

    }
}
