using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using SpawnDev.BlazorJS.Internal;
using System.Reflection;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    /// <summary>
    /// IJSObjectReference extension methods
    /// </summary>
    public static class IJSObjectReferenceExtensions
    {
        static PropertyInfo JSObjectReferenceIdProp => _JSObjectReferenceIdProp.Value;
        static FieldInfo JSObjectReference_JSRuntimeField => _JSObjectReference_JSRuntimeField.Value;
        static FieldInfo JSInProcessObjectReference_JSRuntimeField => _JSInProcessObjectReference_JSRuntimeField.Value;
        static Lazy<PropertyInfo> _JSObjectReferenceIdProp = new Lazy<PropertyInfo>(typeof(JSObjectReference).GetProperty("Id", BindingFlags.NonPublic | BindingFlags.Instance)!);
        static Lazy<FieldInfo> _JSObjectReference_JSRuntimeField = new Lazy<FieldInfo>(typeof(JSObjectReference).GetField("_jsRuntime", BindingFlags.NonPublic | BindingFlags.Instance)!);
        static Lazy<FieldInfo> _JSInProcessObjectReference_JSRuntimeField = new Lazy<FieldInfo>(typeof(JSInProcessObjectReference).GetField("_jsRuntime", BindingFlags.NonPublic | BindingFlags.Instance)!);
        /// <summary>
        /// Returns the Id property value of the IJSInProcessObjectReference
        /// </summary>
        public static long JSRefId(this IJSObjectReference _ref) => (long)JSObjectReferenceIdProp!.GetValue(_ref)!;
        /// <summary>
        /// Returns the IJSObjectReference's JSRuntime
        /// </summary>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public static JSRuntime JSRefJSRuntime(this IJSObjectReference _ref) => (JSRuntime)JSObjectReference_JSRuntimeField!.GetValue(_ref)!;
        /// <summary>
        /// Returns the IJSInProcessObjectReference's JSInProcessRuntime
        /// </summary>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public static JSInProcessRuntime JSRefJSInProcessRuntime(this IJSInProcessObjectReference _ref) => (JSInProcessRuntime)JSInProcessObjectReference_JSRuntimeField!.GetValue(_ref)!;
        /// <summary>
        /// Returns the object as type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public static Task<T> As<T>(this IJSObjectReference _ref) => _ref.GetInterop().ObjectGet<T>(_ref);
        private static BlazorJSInteropAsync GetInterop(this IJSObjectReference _ref)
        {
            var jsRuntime = _ref.JSRefJSRuntime();
            return new BlazorJSInteropAsync(jsRuntime);
        }
        /// <summary>
        /// Get a global property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<T> GetAsync<T>(this IJSObjectReference _ref, string key) => _ref.GetInterop().ObjectPropertyGet<T>(_ref, key);
        /// <summary>
        /// Get a global property
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<IJSObjectReference> GetAsync(this IJSObjectReference _ref, string key) => _ref.GetInterop().ObjectPropertyGet<IJSObjectReference>(_ref, key);
        /// <summary>
        /// Set a global property
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Task SetAsync(this IJSObjectReference _ref, string key, object? value) => _ref.GetInterop().ObjectPropertySet(_ref, key, value);
        /// <summary>
        /// Creates a new instance the global property type
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<T> NewAsync<T>(this IJSObjectReference _ref, string key, params object?[]? args) => _ref.GetInterop().ObjectPropertyNew<T>(_ref, key, args);
        /// <summary>
        /// Creates a new instance the global property type
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<IJSObjectReference> NewAsync(this IJSObjectReference _ref, string key, params object?[]? args) => _ref.GetInterop().ObjectPropertyNew<IJSObjectReference>(_ref, key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<T> CallAsync<T>(this IJSObjectReference _ref, string key, params object?[]? args) => _ref.GetInterop().ObjectPropertyCall<T>(_ref, key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<IJSObjectReference> CallAsync(this IJSObjectReference _ref, string key, params object?[]? args) => _ref.GetInterop().ObjectPropertyCall<IJSObjectReference>(_ref, key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task CallVoidAsync(this IJSObjectReference _ref, string key, params object?[]? args) => _ref.GetInterop().ObjectPropertyCallVoid(_ref, key, args);
        /// <summary>
        /// Returns a list of the global property's keys
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="hasOwnProperty"></param>
        /// <returns></returns>
        public static Task<List<string>> KeysAsync(this IJSObjectReference _ref, string key, bool hasOwnProperty = false) => _ref.GetInterop().ObjectPropertyKeys(_ref, key, hasOwnProperty);
        /// <summary>
        /// Returns the global property's 'constructor.name' value
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<string?> ConstructorNameAsync(this IJSObjectReference _ref, string key) => _ref.GetInterop().ObjectPropertyConstructorName(_ref, key);
        /// <summary>
        /// Returns the global property's 'typeof' value
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<string> TypeOfAsync(this IJSObjectReference _ref, string key) => _ref.GetInterop().ObjectPropertyTypeOf(_ref, key);
        /// <summary>
        /// Deletes a global property
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<bool> DeleteAsync(this IJSObjectReference _ref, string key) => _ref.GetInterop().ObjectPropertyDelete(_ref, key);
        /// <summary>
        /// Tests if a property exists using the 'in' operator
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<bool> InAsync(this IJSObjectReference _ref, string key) => _ref.GetInterop().ObjectPropertyIn(_ref, key);
        /// <summary>
        /// Returns true if 'typeof' global property == "undefined"
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> IsUndefinedAsync(this IJSObjectReference _ref, string key) => await _ref.TypeOfAsync(key) == "undefined";
    }
}
