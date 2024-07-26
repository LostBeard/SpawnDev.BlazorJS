namespace SpawnDev.BlazorJS
{
    public partial class BlazorJSRuntime
    {
        /// <summary>
        /// Internal dispose callback method
        /// </summary>
        /// <param name="callbackID"></param>
        internal void DisposeCallback(string callbackID) => BlazorJSInterop.DisposeCallback(callbackID);
        /// <summary>
        /// Returns the target's property string keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public List<string> Keys(bool hasOwnProperty = false) => BlazorJSInterop.GlobalKeys(hasOwnProperty);
        /// <summary>
        /// Returns the constructor?.name of the target
        /// </summary>
        public string? ConstructorName() => BlazorJSInterop.GlobalConstructorName();
        /// <summary>
        /// Returns full ? target === obj2 : target == obj2
        /// </summary>
        public bool JSEquals(string key, object? obj2, bool full = false) => BlazorJSInterop.GlobalPropertyEquals(key, obj2, full);
        /// <summary>
        /// Returns typeof target
        /// </summary>
        public string TypeOf(string key) => BlazorJSInterop.GlobalPropertyTypeOf(key);
        /// <summary>
        /// Returns the constructor?.name of the target
        /// </summary>
        public string? ConstructorName(string key) => BlazorJSInterop.GlobalPropertyConstructorName(key);
        /// <summary>
        /// Returns the target's property string keys<br/>
        /// non-string keys are ignored
        /// </summary>
        public List<string> Keys(string key, bool hasOwnProperty = false) => BlazorJSInterop.GlobalPropertyKeys(key, hasOwnProperty);
        /// <summary>
        /// Returns true if the property name === undefined
        /// </summary>
        public bool IsUndefined(string key) => TypeOf(key) == "undefined";
        /// <summary>
        /// Returns key in target
        /// </summary>
        public bool In(string key) => BlazorJSInterop.GlobalPropertyIn(key);
        /// <summary>
        /// Set a property value
        /// </summary>
        public void Set(string key, object? value) => BlazorJSInterop.GlobalPropertySet(key, value);
        /// <summary>
        /// Deletes the target
        /// </summary>
        public bool Delete(string key) => BlazorJSInterop.GlobalPropertyDelete(key);
        /// <summary>
        /// Get a property value
        /// </summary>
        public T Get<T>(string key) => BlazorJSInterop.GlobalPropertyGet<T>(key);
        /// <summary>
        /// Get a property value
        /// </summary>
        public object? Get(Type returnType, string key) => BlazorJSInterop.GlobalPropertyGet(returnType, key);
        /// <summary>
        /// Get a property async value
        /// </summary>
        public Task<T> GetAsync<T>(string key) => BlazorJSInterop.GlobalPropertyGet<Task<T>>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public T CallApply<T>(string key, object?[]? args = null) => BlazorJSInterop.GlobalPropertyCall<T>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? CallApply(Type returnType, string key, object?[]? args = null) => BlazorJSInterop.GlobalPropertyCall(returnType, key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallApplyVoid(string key, object?[]? args = null) => BlazorJSInterop.GlobalPropertyCallVoid(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallApplyAsync<T>(string key, object?[]? args = null) => CallApply<Task<T>>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallApplyVoidAsync(string key, object?[]? args = null) => CallApply<Task>(key, args);
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key) => CallApply<T>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0) => CallApply<T>(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1) => CallApply<T>(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2) => CallApply<T>(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public T Call<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key) => CallApplyVoid(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0) => CallApplyVoid(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1) => CallApplyVoid(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public void CallVoid(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoid(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key) => CallApplyAsync<T>(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0) => CallApplyAsync<T>(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1) => CallApplyAsync<T>(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task<T> CallAsync<T>(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyAsync<T>(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key) => CallApplyVoidAsync(key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0) => CallApplyVoidAsync(key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1) => CallApplyVoidAsync(key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public Task CallVoidAsync(string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoidAsync(key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key) => CallApply(returnType, key);
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0) => CallApply(returnType, key, new object?[] { arg0 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1) => CallApply(returnType, key, new object?[] { arg0, arg1 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Call the target method
        /// </summary>
        public object? Call(Type returnType, string key, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply(returnType, key, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
    }
}
