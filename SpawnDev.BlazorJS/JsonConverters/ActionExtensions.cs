using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JsonConverters {


    public static class ActionExtensions {
        internal class FNDisposables {
            public Callback? Callback { get; set; }
            public Function? Function { get; set; }
        }

        static Dictionary<object, Callback> _callbacks = new Dictionary<object, Callback>();
        static Dictionary<object, Function> _functions = new Dictionary<object, Function>();

        public static void CallbackDispose(this Action _this) {
            if (_callbacks.TryGetValue(_this, out var callback)) {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn)) {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static Callback? CallbackGet(this Action _this) => _callbacks.TryGetValue(_this, out var callback) ? callback : null;
        public static void CallbackSet(this Action _this, Callback callback) => _callbacks.Add(_this, callback);
        public static Function? FunctionGet(this Action _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static void FunctionSet(this Action _this, Function fn) => _functions.Add(_this, fn);




        public static void CallbackDispose<T0>(this Action<T0> _this) {
            if (_callbacks.TryGetValue(_this, out var callback)) {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn)) {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static Callback? CallbackGet<T0>(this Action<T0> _this) => _callbacks.TryGetValue(_this, out var callback) ? callback : null;
        public static void CallbackSet<T0>(this Action<T0> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static Function? FunctionGet<T0>(this Action<T0> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static void FunctionSet<T0>(this Action<T0> _this, Function fn) => _functions.Add(_this, fn);
            
        public static void CallbackDispose<T0, T1>(this Action<T0, T1> _this) {
            if (_callbacks.TryGetValue(_this, out var callback)) {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
            if (_functions.TryGetValue(_this, out var fn)) {
                _functions.Remove(_this);
                fn.Dispose();
            }
        }
        public static Callback? CallbackGet<T0, T1>(this Action<T0, T1> _this) => _callbacks.TryGetValue(_this, out var callback) ? callback : null;
        public static void CallbackSet<T0, T1>(this Action<T0, T1> _this, Callback callback) => _callbacks.Add(_this, callback);
        public static Function? FunctionGet<T0, T1>(this Action<T0, T1> _this) => _functions.TryGetValue(_this, out var fn) ? fn : null;
        public static void FunctionSet<T0, T1>(this Action<T0, T1> _this, Function fn) => _functions.Add(_this, fn);
    }
}
