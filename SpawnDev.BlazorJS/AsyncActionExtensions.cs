//using SpawnDev.BlazorJS.JSObjects;

//namespace SpawnDev.BlazorJS
//{
//    /// <summary>
//    /// Extends Func&lt;[...,] Task>
//    /// </summary>
//    public static class AsyncActionExtensions
//    {
//        static Dictionary<Delegate, Callback> _callbacks = new Dictionary<Delegate, Callback>();
//        static Dictionary<Delegate, Function> _functions = new Dictionary<Delegate, Function>();
//        /// <summary>
//        /// Disposes the attached Callback if one exists
//        /// </summary>
//        public static void CallbackDispose(this Func<Task> _this)
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
//        public static void CallbackDispose<T0>(this Func<T0, Task> _this)
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
//        public static void CallbackDispose<T0, T1>(this Func<T0, T1, Task> _this)
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
//        public static void CallbackDispose<T0, T1, T2>(this Func<T0, T1, T2, Task> _this)
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
//        public static void CallbackDispose<T0, T1, T2, T3>(this Func<T0, T1, T2, T3, Task> _this)
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
//        public static void CallbackDispose<T0, T1, T2, T3, T4>(this Func<T0, T1, T2, T3, T4, Task> _this)
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
//        public static void CallbackDispose<T0, T1, T2, T3, T4, T5>(this Func<T0, T1, T2, T3, T4, T5, Task> _this)
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
//        public static void CallbackDispose<T0, T1, T2, T3, T4, T5, T6>(this Func<T0, T1, T2, T3, T4, T5, T6, Task> _this)
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
//        public static AsyncActionCallback? CallbackGet(this Func<Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncActionCallback<T0>? CallbackGet<T0>(this Func<T0, Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback<T0>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncActionCallback<T0, T1>? CallbackGet<T0, T1>(this Func<T0, T1, Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback<T0, T1>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncActionCallback<T0, T1, T2>? CallbackGet<T0, T1, T2>(this Func<T0, T1, T2, Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback<T0, T1, T2>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncActionCallback<T0, T1, T2, T3>? CallbackGet<T0, T1, T2, T3>(this Func<T0, T1, T2, T3, Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback<T0, T1, T2, T3>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncActionCallback<T0, T1, T2, T3, T4>? CallbackGet<T0, T1, T2, T3, T4>(this Func<T0, T1, T2, T3, T4, Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback<T0, T1, T2, T3, T4>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncActionCallback<T0, T1, T2, T3, T4, T5>? CallbackGet<T0, T1, T2, T3, T4, T5>(this Func<T0, T1, T2, T3, T4, T5, Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback<T0, T1, T2, T3, T4, T5>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//        /// <summary>
//        /// Gets or creates a Callback attached to this method.<br/>
//        /// The attached Callback can be disposed using this.DisposeJS()
//        /// </summary>
//        /// <param name="_this">This method</param>
//        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
//        /// <returns></returns>
//        public static AsyncActionCallback<T0, T1, T2, T3, T4, T5, T6>? CallbackGet<T0, T1, T2, T3, T4, T5, T6>(this Func<T0, T1, T2, T3, T4, T5, T6, Task> _this, bool allowCreate = false)
//            => (AsyncActionCallback<T0, T1, T2, T3, T4, T5, T6>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
//    }
//}
