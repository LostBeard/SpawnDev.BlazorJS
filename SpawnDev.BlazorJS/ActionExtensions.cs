using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    public static class ActionExtensions
    {
        static Dictionary<Delegate, Callback> _callbacks = new Dictionary<Delegate, Callback>();
        static Dictionary<Delegate, Function> _functions = new Dictionary<Delegate, Function>();
        public static void DisposeJS(this Action _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static void DisposeJS<T0>(this Action<T0> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static void DisposeJS<T0, T1>(this Action<T0, T1> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static void DisposeJS<T0, T1, T2>(this Action<T0, T1, T2> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static void DisposeJS<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static void DisposeJS<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static void DisposeJS<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static void DisposeJS<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn))
            {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static ActionCallback? CallbackGet(this Action _this, bool allowCreate = false)
            => (ActionCallback?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns></returns>
        public static ActionCallback<T0>? CallbackGet<T0>(this Action<T0> _this, bool allowCreate = false)
            => (ActionCallback<T0>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns></returns>
        public static ActionCallback<T0, T1>? CallbackGet<T0, T1>(this Action<T0, T1> _this, bool allowCreate = false)
            => (ActionCallback<T0, T1>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns></returns>
        public static ActionCallback<T0, T1, T2>? CallbackGet<T0, T1, T2>(this Action<T0, T1, T2> _this, bool allowCreate = false)
            => (ActionCallback<T0, T1, T2>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns></returns>
        public static ActionCallback<T0, T1, T2, T3>? CallbackGet<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this, bool allowCreate = false)
            => (ActionCallback<T0, T1, T2, T3>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns></returns>
        public static ActionCallback<T0, T1, T2, T3, T4>? CallbackGet<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this, bool allowCreate = false)
            => (ActionCallback<T0, T1, T2, T3, T4>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns></returns>
        public static ActionCallback<T0, T1, T2, T3, T4, T5>? CallbackGet<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this, bool allowCreate = false)
            => (ActionCallback<T0, T1, T2, T3, T4, T5>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns></returns>
        public static ActionCallback<T0, T1, T2, T3, T4, T5, T6>? CallbackGet<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this, bool allowCreate = false) 
            => (ActionCallback<T0, T1, T2, T3, T4, T5, T6>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        public static void CallbackSet(this Action _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0>(this Action<T0> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1>(this Action<T0, T1> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2>(this Action<T0, T1, T2> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static Function? FunctionGet(this Action _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0>(this Action<T0> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1>(this Action<T0, T1> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2>(this Action<T0, T1, T2> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static void FunctionSet(this Action _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0>(this Action<T0> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1>(this Action<T0, T1> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2>(this Action<T0, T1, T2> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this, Function fn) => _functions.Add(_this, fn);
    }
}
