//using SpawnDev.BlazorJS.JSObjects;

//namespace SpawnDev.BlazorJS
//{
//    /// <summary>
//    /// Extends Func&lt;[...,] Task<TResult>&lt;>>
//    /// </summary>
//    public static class AsyncFuncExtensions
//    {
//        static Dictionary<Delegate, Callback> _callbacks = new Dictionary<Delegate, Callback>();
//        static Dictionary<Delegate, Function> _functions = new Dictionary<Delegate, Function>();
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<TResult>(this Func<Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<T0, TResult>(this Func<T0, Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<T0, T1, TResult>(this Func<T0, T1, Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<T0, T1, T2, TResult>(this Func<T0, T1, T2, Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, Task<TResult>> _this)
//        {
//            if (_callbacks.TryGetValue(_this, out var callback))
//            {
//                _callbacks.Remove(_this);
//                callback.Dispose();
//            }
//        }
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<TResult>? CallbackGet<TResult>(this Func<Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<T0, TResult>? CallbackGet<T0, TResult>(this Func<T0, Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<T0, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<T0, T1, TResult>? CallbackGet<T0, T1, TResult>(this Func<T0, T1, Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<T0, T1, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<T0, T1, T2, TResult>? CallbackGet<T0, T1, T2, TResult>(this Func<T0, T1, T2, Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<T0, T1, T2, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<T0, T1, T2, T3, TResult>? CallbackGet<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<T0, T1, T2, T3, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<T0, T1, T2, T3, T4, TResult>? CallbackGet<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<T0, T1, T2, T3, T4, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<T0, T1, T2, T3, T4, T5, TResult>? CallbackGet<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<T0, T1, T2, T3, T4, T5, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncFuncCallback<T0, T1, T2, T3, T4, T5, T6, TResult>? CallbackGet<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, Task<TResult>> _this, bool allowCreate = false)
//            => (AsyncFuncCallback<T0, T1, T2, T3, T4, T5, T6, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//    }
//}
