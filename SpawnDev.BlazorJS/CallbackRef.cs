namespace SpawnDev.BlazorJS
{
    public partial class Callback
    {
        /// <summary>
        /// A copy of the tracked Callbacks Dictionary keyed by the target method<br/>
        /// Only Callbacks created using Callback.RefAdd() and Callback.RefGet() are tracked<br/>
        /// </summary>
        public static Dictionary<Delegate, Callback> Tracked => TrackedCallbacks.ToDictionary(o => o.Key, o => o.Value);
        private static Dictionary<Delegate, Callback> TrackedCallbacks { get; } = new Dictionary<Delegate, Callback>();
        static TCallback TrackCallback<TCallback>(Delegate callback, TCallback callbackJS) where TCallback : Callback
        {
            TrackedCallbacks.Add(callback, callbackJS);
            callbackJS.OnDisposed += () => TrackedCallbacks.Remove(callback);
            return callbackJS;
        }
        // ActionCallback
        // - RefAdd
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback RefAdd(Action callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1> RefAdd<T1>(Action<T1> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback<T1>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2> RefAdd<T1, T2>(Action<T1, T2> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback<T1, T2>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3> RefAdd<T1, T2, T3>(Action<T1, T2, T3> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback<T1, T2, T3>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4> RefAdd<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4, T5> RefAdd<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4, T5>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6> RefAdd<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4, T5, T6>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7> RefAdd<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4, T5, T6, T7>)info;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback? RefGet(Action callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1>? RefGet<T1>(Action<T1> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback<T1>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2>? RefGet<T1, T2>(Action<T1, T2> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback<T1, T2>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3>? RefGet<T1, T2, T3>(Action<T1, T2, T3> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback<T1, T2, T3>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4>? RefGet<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback<T1, T2, T3, T4>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4, T5>? RefGet<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback<T1, T2, T3, T4, T5>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6>? RefGet<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback<T1, T2, T3, T4, T5, T6>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7>? RefGet<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (ActionCallback<T1, T2, T3, T4, T5, T6, T7>)info! : (!allowCreate ? null : RefAdd(callback));
        // AsyncActionCallback
        // - RefAdd
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback RefAdd(Func<Task> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncActionCallback)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1> RefAdd<T1>(Func<T1, Task> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncActionCallback<T1>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1, T2> RefAdd<T1, T2>(Func<T1, T2, Task> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncActionCallback<T1, T2>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1, T2, T3> RefAdd<T1, T2, T3>(Func<T1, T2, T3, Task> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncActionCallback<T1, T2, T3>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1, T2, T3, T4> RefAdd<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncActionCallback<T1, T2, T3, T4>)info;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback? RefGet(Func<Task> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncActionCallback)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1>? RefGet<T1>(Func<T1, Task> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncActionCallback<T1>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1, T2>? RefGet<T1, T2>(Func<T1, T2, Task> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncActionCallback<T1, T2>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1, T2, T3>? RefGet<T1, T2, T3>(Func<T1, T2, T3, Task> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncActionCallback<T1, T2, T3>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1, T2, T3, T4>? RefGet<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncActionCallback<T1, T2, T3, T4>)info! : (!allowCreate ? null : RefAdd(callback));
        // FuncCallback
        // - RefAdd
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<TResult> RefAdd<TResult>(Func<TResult> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (FuncCallback<TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, TResult> RefAdd<T1, TResult>(Func<T1, TResult> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (FuncCallback<T1, TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, T2, TResult> RefAdd<T1, T2, TResult>(Func<T1, T2, TResult> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (FuncCallback<T1, T2, TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, T2, T3, TResult> RefAdd<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (FuncCallback<T1, T2, T3, TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, T2, T3, T4, TResult> RefAdd<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (FuncCallback<T1, T2, T3, T4, TResult>)info;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<TResult>? RefGet<TResult>(Func<TResult> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (FuncCallback<TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, TResult>? RefGet<T1, TResult>(Func<T1, TResult> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (FuncCallback<T1, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, T2, TResult>? RefGet<T1, T2, TResult>(Func<T1, T2, TResult> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (FuncCallback<T1, T2, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, T2, T3, TResult>? RefGet<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (FuncCallback<T1, T2, T3, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, T2, T3, T4, TResult>? RefGet<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (FuncCallback<T1, T2, T3, T4, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        // AsyncFuncCallback
        // - RefAdd
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<TResult> RefAdd<TResult>(Func<Task<TResult>> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncFuncCallback<TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, TResult> RefAdd<T1, TResult>(Func<T1, Task<TResult>> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncFuncCallback<T1, TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, T2, TResult> RefAdd<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncFuncCallback<T1, T2, TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, T2, T3, TResult> RefAdd<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncFuncCallback<T1, T2, T3, TResult>)info;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult> RefAdd<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) info = TrackCallback(callback, Callback.Create(callback));
            else info.RefCount++;
            return (AsyncFuncCallback<T1, T2, T3, T4, TResult>)info;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<TResult>? RefGet<TResult>(Func<Task<TResult>> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncFuncCallback<TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, TResult>? RefGet<T1, TResult>(Func<T1, Task<TResult>> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncFuncCallback<T1, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, T2, TResult>? RefGet<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncFuncCallback<T1, T2, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, T2, T3, TResult>? RefGet<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncFuncCallback<T1, T2, T3, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult>? RefGet<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback, bool allowCreate = true) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? (AsyncFuncCallback<T1, T2, T3, T4, TResult>)info! : (!allowCreate ? null : RefAdd(callback));
        // All
        // - RefDel
        /// <summary>
        /// Reduces the given methods reference count by 1 and returns the updated reference count<br/>
        /// If the RefCount reaches 0 the Callback will be Disposed
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>The new RefCount</returns>
        public static int RefDel(Delegate callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) return 0;
            info.RefCount--;
            return info.RefCount;
        }
        /// <summary>
        /// Forces the Callback to Dispose regardless of RefCount
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>true if the Callback was disposed</returns>
        public static bool RefDispose(Delegate callback)
        {
            if (!TrackedCallbacks.TryGetValue(callback, out Callback? info)) return false;
            info.Dispose(true);
            return true;
        }
        // - GetRefCount
        /// <summary>
        /// Returns the reference count for the given method
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>A Callback object or null</returns>
        public static int GetRefCount(Delegate callback) => TrackedCallbacks.TryGetValue(callback, out Callback? info) ? info!.RefCount : 0;
    }
}
