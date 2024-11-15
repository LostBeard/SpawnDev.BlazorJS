using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Internal;
using System.Reflection;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    /// <summary>
    /// IJSRuntime extension methods
    /// </summary>
    public static class IJSRuntimeExtensions
    {
        private static Lazy<MethodInfo> IJSRuntime_InvokeAsync = new Lazy<MethodInfo>(() => typeof(JSRuntime).GetMethod("InvokeAsync", new Type[] { typeof(string), typeof(object[]) })!);
        private static Dictionary<Type, MethodInfo> GenericInvokeAsyncMethods { get; } = new Dictionary<Type, MethodInfo>();
        private static MethodInfo GetJSRuntimeInvokeAsync(Type type)
        {
            if (GenericInvokeAsyncMethods.TryGetValue(type, out MethodInfo? generic)) return generic!;
            return GenericInvokeAsyncMethods[type] = IJSRuntime_InvokeAsync.Value.MakeGenericMethod(type);
        }
        internal static async Task<object?> InvokeAsync(this IJSRuntime _js, Type returnType, string identifier, params object?[]? args)
        {
            var typedMethod = GetJSRuntimeInvokeAsync(returnType);
            var ret = await typedMethod.InvokeAsync(_js, new object[] { identifier, args });
            return ret;
        }
        private static BlazorJSInteropAsync GetInterop(this IJSRuntime _ref)
        {
            return new BlazorJSInteropAsync(_ref);
        }
        /// <summary>
        /// Get a global property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<T> GetAsync<T>(this IJSRuntime _ref, string key) => _ref.GetInterop().GlobalPropertyGet<T>(key);
        /// <summary>
        /// Get a global property
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<IJSObjectReference> GetAsync(this IJSRuntime _ref, string key) => _ref.GetInterop().GlobalPropertyGet<IJSObjectReference>(key);
        /// <summary>
        /// Set a global property
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Task SetAsync(this IJSRuntime _ref, string key, object? value) => _ref.GetInterop().GlobalPropertySet(key, value);
        /// <summary>
        /// Creates a new instance the global property type
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<T> NewAsync<T>(this IJSRuntime _ref, string key, params object?[]? args) => _ref.GetInterop().GlobalPropertyNew<T>(key, args);
        /// <summary>
        /// Creates a new instance the global property type
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<IJSObjectReference> NewAsync(this IJSRuntime _ref, string key, params object?[]? args) => _ref.GetInterop().GlobalPropertyNew<IJSObjectReference>(key, args);
        /// <summary>
        /// Creates a new Object instance
        /// </summary>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public static Task<IJSObjectReference> NewAsync(this IJSRuntime _ref) => _ref.GetInterop().GlobalPropertyNew<IJSObjectReference>("Object", null);
        /// <summary>
        /// Creates a new Object instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public static Task<T> NewAsync<T>(this IJSRuntime _ref) => _ref.GetInterop().GlobalPropertyNew<T>("Object", null);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<T> CallAsync<T>(this IJSRuntime _ref, string key, params object?[]? args) => _ref.GetInterop().GlobalPropertyCall<T>(key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task<IJSObjectReference> CallAsync(this IJSRuntime _ref, string key, params object?[]? args) => _ref.GetInterop().GlobalPropertyCall<IJSObjectReference>(key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Task CallVoidAsync(this IJSRuntime _ref, string key, params object?[]? args) => _ref.GetInterop().GlobalPropertyCallVoid(key, args);
        /// <summary>
        /// Returns a list of the global property's keys
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <param name="hasOwnProperty"></param>
        /// <returns></returns>
        public static Task<List<string>> KeysAsync(this IJSRuntime _ref, string key, bool hasOwnProperty = false) => _ref.GetInterop().GlobalPropertyKeys(key, hasOwnProperty);
        /// <summary>
        /// Returns the global property's 'constructor.name' value
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<string?> ConstructorNameAsync(this IJSRuntime _ref, string key) => _ref.GetInterop().GlobalPropertyConstructorName(key);
        /// <summary>
        /// Returns the global property's 'typeof' value
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<string> TypeOfAsync(this IJSRuntime _ref, string key) => _ref.GetInterop().GlobalPropertyTypeOf(key);
        /// <summary>
        /// Deletes a global property
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<bool> DeleteAsync(this IJSRuntime _ref, string key) => _ref.GetInterop().GlobalPropertyDelete(key);
        /// <summary>
        /// Tests if a property exists using the 'in' operator
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Task<bool> InAsync(this IJSRuntime _ref, string key) => _ref.GetInterop().GlobalPropertyIn(key);
        /// <summary>
        /// Returns true if 'typeof' global property == "undefined"
        /// </summary>
        /// <param name="_ref"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> IsUndefinedAsync(this IJSRuntime _ref, string key) => await _ref.TypeOfAsync(key) == "undefined";
        /// <summary>
        /// Returns the specified object as type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Task<T> ReturnAs<T>(this IJSRuntime _ref, object? obj) => _ref.GetInterop().ObjectGet<T>(obj);
    }
}
