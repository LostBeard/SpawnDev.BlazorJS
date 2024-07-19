using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    public static class FuncExtensions
    {
        static Dictionary<object, Callback> _callbacks = new Dictionary<object, Callback>();
        static Dictionary<object, Function> _functions = new Dictionary<object, Function>();
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
        public static void CallbackSet<TResult>(this Func<TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, TResult>(this Func<T0, TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, TResult>(this Func<T0, T1, TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static void CallbackSet<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static Function? FunctionGet<TResult>(this Func<TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, TResult>(this Func<T0, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, TResult>(this Func<T0, T1, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static Function? FunctionGet<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static void FunctionSet<TResult>(this Func<TResult> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, TResult>(this Func<T0, TResult> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, TResult>(this Func<T0, T1, TResult> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3, T4, TResult>(this Func<T0, T1, T2, T3, T4, TResult> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3, T4, T5, TResult>(this Func<T0, T1, T2, T3, T4, T5, TResult> _this, Function fn) => _functions.Add(_this, fn);
        public static void FunctionSet<T0, T1, T2, T3, T4, T5, T6, TResult>(this Func<T0, T1, T2, T3, T4, T5, T6, TResult> _this, Function fn) => _functions.Add(_this, fn);
    }
}
