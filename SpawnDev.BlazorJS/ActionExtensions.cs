using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Extends Action
    /// </summary>
    public static class ActionExtensions
    {
        static Dictionary<Delegate, Callback> _callbacks = new Dictionary<Delegate, Callback>();
        static Dictionary<Delegate, Function> _functions = new Dictionary<Delegate, Function>();
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
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
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose(this Action _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose<T0>(this Action<T0> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose<T0, T1>(this Action<T0, T1> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose<T0, T1, T2>(this Action<T0, T1, T2> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Callback if one exists
        /// </summary>
        public static void CallbackDispose<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this)
        {
            if (_callbacks.TryGetValue(_this, out var callback))
            {
                _callbacks.Remove(_this);
                callback.Dispose();
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

        #region Function
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet(this Action _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0>(this Action<T0> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1>(this Action<T0, T1> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2>(this Action<T0, T1, T2> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet(this Action _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0>(this Action<T0> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1>(this Action<T0, T1> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2>(this Action<T0, T1, T2> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose(this Action _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<T0>(this Action<T0> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<T0, T1>(this Action<T0, T1> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<T0, T1, T2>(this Action<T0, T1, T2> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<T0, T1, T2, T3, T4>(this Action<T0, T1, T2, T3, T4> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<T0, T1, T2, T3, T4, T5>(this Action<T0, T1, T2, T3, T4, T5> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<T0, T1, T2, T3, T4, T5, T6>(this Action<T0, T1, T2, T3, T4, T5, T6> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
        #endregion
    }
}
