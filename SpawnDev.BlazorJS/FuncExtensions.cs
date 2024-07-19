using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Extends Func
    /// </summary>
    public static class FuncExtensions
    {
        static Dictionary<object, Callback> _callbacks = new Dictionary<object, Callback>();
        static Dictionary<object, Function> _functions = new Dictionary<object, Function>();
        /// <summary>
        /// Disposes both attached Callbacks and Functions
        /// </summary>
        public static void DisposeJS<TResult>(this Func<TResult> _this)
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
        public static void DisposeJS<T0, TResult>(this Func<T0, TResult> _this)
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
        public static void DisposeJS<T0, T1, TResult>(this Func<T0, T1, TResult> _this)
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
        public static void DisposeJS<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this)
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
        public static void DisposeJS<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this)
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
        public static void DisposeJS<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this)
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
        public static void DisposeJS<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this)
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
        public static void DisposeJS<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this)
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
        public static void CallbackDispose<TResult>(this Func<TResult> _this)
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
        public static void CallbackDispose<T0, TResult>(this Func<T0, TResult> _this)
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
        public static void CallbackDispose<T0, T1, TResult>(this Func<T0, T1, TResult> _this)
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
        public static void CallbackDispose<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this)
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
        public static void CallbackDispose<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this)
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
        public static void CallbackDispose<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this)
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
        public static void CallbackDispose<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this)
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
        public static void CallbackDispose<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this)
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
        public static FuncCallback<TResult>? CallbackGet<TResult>(this Func<TResult> _this, bool allowCreate = false)
            => (FuncCallback<TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static FuncCallback<T0, TResult>? CallbackGet<T0, TResult>(this Func<T0, TResult> _this, bool allowCreate = false)
            => (FuncCallback<T0, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static FuncCallback<T0, T1, TResult>? CallbackGet<T0, T1, TResult>(this Func<T0, T1, TResult> _this, bool allowCreate = false)
            => (FuncCallback<T0, T1, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static FuncCallback<T0, T1, T2, TResult>? CallbackGet<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this, bool allowCreate = false)
            => (FuncCallback<T0, T1, T2, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static FuncCallback<T0, T1, T2, T3, TResult>? CallbackGet<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this, bool allowCreate = false)
            => (FuncCallback<T0, T1, T2, T3, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static FuncCallback<T0, T1, T2, T3, T4, TResult>? CallbackGet<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this, bool allowCreate = false)
            => (FuncCallback<T0, T1, T2, T3, T4, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static FuncCallback<T0, T1, T2, T3, T4, T5, TResult>? CallbackGet<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this, bool allowCreate = false)
            => (FuncCallback<T0, T1, T2, T3, T4, T5, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Gets or creates a Callback attached to this method.<br/>
        /// The attached Callback can be disposed using this.DisposeJS()
        /// </summary>
        /// <param name="_this">This method</param>
        /// <param name="allowCreate">If true and the Callback does not already exist, it will be created</param>
        /// <returns>A Callback or null</returns>
        public static FuncCallback<T0, T1, T2, T3, T4, T5, T6, TResult>? CallbackGet<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this, bool allowCreate = false)
            => (FuncCallback<T0, T1, T2, T3, T4, T5, T6, TResult>?)(!_callbacks.TryGetValue(_this, out Callback? ret) && allowCreate ? _callbacks[_this] = ret = Callback.Create(_this) : ret);
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<TResult>(this Func<TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, TResult>(this Func<T0, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, TResult>(this Func<T0, T1, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Returns the attached Function or null
        /// </summary>
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<TResult>(this Func<TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, TResult>(this Func<T0, TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, TResult>(this Func<T0, T1, TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Attaches a Function to this method. This is done when a Function has been converted tp a method allowing it to stay alive until disposed when no longer needed.
        /// </summary>
        internal static void FunctionSet<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this, Function fn) => _functions.Add(_this, fn);
        /// <summary>
        /// Disposes the attached Function if one exists
        /// </summary>
        public static void FunctionDispose<TResult>(this Func<TResult> _this)
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
        public static void FunctionDispose<T0, TResult>(this Func<T0, TResult> _this)
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
        public static void FunctionDispose<T0, T1, TResult>(this Func<T0, T1, TResult> _this)
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
        public static void FunctionDispose<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this)
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
        public static void FunctionDispose<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this)
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
        public static void FunctionDispose<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this)
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
        public static void FunctionDispose<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this)
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
        public static void FunctionDispose<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this)
        {
            if (_functions.TryGetValue(_this, out var function))
            {
                _functions.Remove(_this);
                function.Dispose();
            }
        }
    }
}
