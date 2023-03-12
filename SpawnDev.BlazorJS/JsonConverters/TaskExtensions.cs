using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JsonConverters {
    public static class TaskExtensions {

        static Dictionary<object, Callback> _callbacks = new Dictionary<object, Callback>();

        public static void CallbackDispose(this Task _this) {
            if (_callbacks.TryGetValue(_this, out var callback)) {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        public static Callback? CallbackGet(this Task _this) => _callbacks.TryGetValue(_this, out var callback) ? callback : null;
        public static void CallbackSet(this Task _this, Callback callback) => _callbacks.Add(_this, callback);


        public static void CallbackDispose<T0>(this Task<T0> _this) {
            if (_callbacks.TryGetValue(_this, out var callback)) {
                _callbacks.Remove(_this);
                callback.Dispose();
            }
        }
        public static Callback? CallbackGet<T0>(this Task<T0> _this) => _callbacks.TryGetValue(_this, out var callback) ? callback : null;
        public static void CallbackSet<T0>(this Task<T0> _this, Callback callback) => _callbacks.Add(_this, callback);

    }
}
