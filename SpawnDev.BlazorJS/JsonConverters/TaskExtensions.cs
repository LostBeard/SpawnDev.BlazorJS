//using SpawnDev.BlazorJS.JSObjects;

//namespace SpawnDev.BlazorJS.JsonConverters
//{
//    public static class TaskExtensions
//    {

//        static Dictionary<object, JSObject> _promises = new Dictionary<object, JSObject>();

//        public static void PromiseDispose(this Task _this)
//        {
//            if (_promises.TryGetValue(_this, out var promise))
//            {
//                _promises.Remove(_this);
//                promise.Dispose();
//            }
//        }
//        public static Promise? PromiseGet(this Task _this, bool allowCreate = false)
//        {
//            Promise? ret = null;
//            if (_promises.TryGetValue(_this, out var tmp)) return (Promise)tmp;
//            if (allowCreate) _promises[_this] = ret = new Promise(_this);
//            return ret;
//        }
//        public static void PromiseSet(this Task _this, Promise promise) => _promises.Add(_this, promise);


//        public static void PromiseDispose<T0>(this Task<T0> _this)
//        {
//            if (_promises.TryGetValue(_this, out var promise))
//            {
//                _promises.Remove(_this);
//                promise.Dispose();
//            }
//        }
//        public static Promise<T0>? PromiseGet<T0>(this Task<T0> _this, bool allowCreate = false)
//        {
//            Promise<T0>? ret = null;
//            if (_promises.TryGetValue(_this, out var tmp)) return (Promise<T0>)tmp;
//            if (allowCreate) _promises[_this] = ret = new Promise<T0>(_this);
//            return ret;
//        }
//        public static void PromiseSet<T0>(this Task<T0> _this, Promise promise) => _promises.Add(_this, promise);

//    }
//}
