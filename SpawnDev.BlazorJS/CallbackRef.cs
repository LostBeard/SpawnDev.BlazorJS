using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public abstract partial class Callback
    {
        private static Dictionary<Delegate, CallBackInfo> CallBackInfos { get; } = new Dictionary<Delegate, CallBackInfo>();
        private class CallBackInfo
        {
            /// <summary>
            /// AddEventListener call count - RemoveEventListener call count<br/>
            /// Callback will be disposed when RefCount == 0
            /// </summary>
            public int RefCount { get; set; }
            /// <summary>
            /// Holds a reference to the callback fo disposing when done using
            /// </summary>
            public Callback Callback { get; init; }
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
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1> RefAdd<T1>(Action<T1> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback<T1>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2> RefAdd<T1, T2>(Action<T1, T2> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback<T1, T2>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3> RefAdd<T1, T2, T3>(Action<T1, T2, T3> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback<T1, T2, T3>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4> RefAdd<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4, T5> RefAdd<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4, T5>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6> RefAdd<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4, T5, T6>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7> RefAdd<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (ActionCallback<T1, T2, T3, T4, T5, T6, T7>)info.Callback;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback? RefGet(Action callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1>? RefGet<T1>(Action<T1> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback<T1>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2>? RefGet<T1, T2>(Action<T1, T2> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback<T1, T2>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3>? RefGet<T1, T2, T3>(Action<T1, T2, T3> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback<T1, T2, T3>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4>? RefGet<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback<T1, T2, T3, T4>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4, T5>? RefGet<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback<T1, T2, T3, T4, T5>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6>? RefGet<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback<T1, T2, T3, T4, T5, T6>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7>? RefGet<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (ActionCallback<T1, T2, T3, T4, T5, T6, T7>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        // AsyncActionCallback
        // - RefAdd
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback RefAdd(Func<Task> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncActionCallback)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1> RefAdd<T1>(Func<T1, Task> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncActionCallback<T1>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1, T2> RefAdd<T1, T2>(Func<T1, T2, Task> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncActionCallback<T1, T2>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1, T2, T3> RefAdd<T1, T2, T3>(Func<T1, T2, T3, Task> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncActionCallback<T1, T2, T3>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncActionCallback<T1, T2, T3, T4> RefAdd<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncActionCallback<T1, T2, T3, T4>)info.Callback;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback? RefGet(Func<Task> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncActionCallback)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1>? RefGet<T1>(Func<T1, Task> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncActionCallback<T1>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1, T2>? RefGet<T1, T2>(Func<T1, T2, Task> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncActionCallback<T1, T2>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1, T2, T3>? RefGet<T1, T2, T3>(Func<T1, T2, T3, Task> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncActionCallback<T1, T2, T3>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncActionCallback<T1, T2, T3, T4>? RefGet<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncActionCallback<T1, T2, T3, T4>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        // FuncCallback
        // - RefAdd
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<TResult> RefAdd<TResult>(Func<TResult> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (FuncCallback<TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, TResult> RefAdd<T1, TResult>(Func<T1, TResult> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (FuncCallback<T1, TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, T2, TResult> RefAdd<T1, T2, TResult>(Func<T1, T2, TResult> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (FuncCallback<T1, T2, TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, T2, T3, TResult> RefAdd<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (FuncCallback<T1, T2, T3, TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static FuncCallback<T1, T2, T3, T4, TResult> RefAdd<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (FuncCallback<T1, T2, T3, T4, TResult>)info.Callback;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<TResult>? RefGet<TResult>(Func<TResult> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (FuncCallback<TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, TResult>? RefGet<T1, TResult>(Func<T1, TResult> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (FuncCallback<T1, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, T2, TResult>? RefGet<T1, T2, TResult>(Func<T1, T2, TResult> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (FuncCallback<T1, T2, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, T2, T3, TResult>? RefGet<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (FuncCallback<T1, T2, T3, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static FuncCallback<T1, T2, T3, T4, TResult>? RefGet<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (FuncCallback<T1, T2, T3, T4, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        // AsyncFuncCallback
        // - RefAdd
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<TResult> RefAdd<TResult>(Func<Task<TResult>> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncFuncCallback<TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, TResult> RefAdd<T1, TResult>(Func<T1, Task<TResult>> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncFuncCallback<T1, TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, T2, TResult> RefAdd<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncFuncCallback<T1, T2, TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, T2, T3, TResult> RefAdd<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncFuncCallback<T1, T2, T3, TResult>)info.Callback;
        }
        /// <summary>
        /// Returns a Callback for the given method and increments the Callback's reference count by 1
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <returns>A Callback object</returns>
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult> RefAdd<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info)) CallBackInfos[callback] = info = new CallBackInfo { Callback = Create(callback) };
            info.RefCount++;
            return (AsyncFuncCallback<T1, T2, T3, T4, TResult>)info.Callback;
        }
        // - RefGet
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<TResult>? RefGet<TResult>(Func<Task<TResult>> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncFuncCallback<TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, TResult>? RefGet<T1, TResult>(Func<T1, Task<TResult>> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncFuncCallback<T1, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, T2, TResult>? RefGet<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncFuncCallback<T1, T2, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, T2, T3, TResult>? RefGet<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncFuncCallback<T1, T2, T3, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        /// <summary>
        /// Returns a Callback for the given method<br/>The Callback reference count is only incremented if the Callback is created
        /// </summary>
        /// <param name="callback">The method to return a Callback for</param>
        /// <param name="allowCreate">If the callback does not already exist and true a new Callback will be created and returned, if false null will be returned</param>
        /// <returns>A Callback object or null</returns>
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult>? RefGet<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback, bool allowCreate = true) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? (AsyncFuncCallback<T1, T2, T3, T4, TResult>)info.Callback! : (!allowCreate ? null : RefAdd(callback));
        // All
        // - RefDel
        /// <summary>
        /// Reduces the given methods reference count by 1 and returns the updated reference count
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>A Callback object or null</returns>
        public static int RefDel(Delegate callback)
        {
            if (!CallBackInfos.TryGetValue(callback, out CallBackInfo? info) || info.RefCount == 0) return 0;
            info.RefCount--;
            if (info.RefCount == 0)
            {
                CallBackInfos.Remove(callback);
                info.Callback!.Dispose();
            }
            return info.RefCount;
        }
        // - RefGetCount
        /// <summary>
        /// Returns the reference count for the given method
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>A Callback object or null</returns>
        public static int RefCount(Delegate callback) => CallBackInfos.TryGetValue(callback, out CallBackInfo? info) ? info!.RefCount : 0;


    }
}
