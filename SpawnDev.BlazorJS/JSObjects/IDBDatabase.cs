using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // Non-standard implememntation
    // TODO - try to standardize
    // https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase
    [JsonConverter(typeof(JSObjectConverter<IDBDatabase>))]
    public class IDBDatabase : JSObject
    {
        public bool IsOpen { get; private set; } = false;
        public string Name { get; private set; } = "";
        public ulong Version { get; private set; } = 0;
        private double _lastErrorCode = 0;
        public double LastErrorCode { get { var ret = _lastErrorCode; _lastErrorCode = 0; return ret; } }

        private static int _isSupported = 0;
        public static bool IsSupported { 
            get {
                if (_isSupported == 0) _isSupported = JS.IsUndefined("indexedDB") ? -1 : 1;
                return _isSupported == 1;
            } 
        }

        public delegate void UpgradeNeededDelegate();
        public event UpgradeNeededDelegate OnUpgradeNeeded;

        public IDBDatabase(IJSInProcessObjectReference _ref) : base(_ref) { }

        public IDBDatabase(string dbName, ulong version = 1) : base(NullRef)
        {
            Name = dbName;
            Version = version;
        }

        public Task<bool> Open()
        {
            var t = new TaskCompletionSource<bool>();
            if (IsOpen)
            {
                t.SetResult(true);
                return t.Task;
            }
            var request = JS.Call<IDBRequest>("indexedDB.open", Name, Version);
            request.On("onupgradeneeded", (JSObject arg0) => {
                using (var target = arg0._ref.Get<JSObject>("target"))
                {
                    FromReference(target._ref.Get<IJSInProcessObjectReference>("result"));
                    OnUpgradeNeeded?.Invoke();
                }
                arg0.Dispose();
            });
            request.OnSuccess((JSObject arg0) => {
                using (var target = arg0._ref.Get<JSObject>("target"))
                {
                    IsOpen = true;
                    ReplaceReference(target._ref.Get<IJSInProcessObjectReference>("result"));
                    t.TrySetResult(IsOpen);
                    request.Dispose();
                }
                arg0.Dispose();
            });
            request.OnError((JSObject arg0) => {
                using (var target = arg0._ref.Get<JSObject>("target"))
                {
                    _lastErrorCode = _ref.Get<double>("errorCode");
                    t.TrySetResult(IsOpen);
                    request.Dispose();
                }
                arg0.Dispose();
            });
            return t.Task;
        }

        public enum TransactionMode
        {
            READONLY,       // default if not specified
            READWRITE,
            READWRITEFLUSH,
        }

        public enum TransactionDurability
        {
            DEFAULT,
            STRICT,
            RELAXED,
        }

        //public async Task Add()
        //{

        //}

        public IDBTransaction Transaction(string storeName, TransactionMode mode = TransactionMode.READWRITE, TransactionDurability durability = TransactionDurability.DEFAULT)
        {
            return Transaction(new string[] { storeName }, mode, durability);
        }

        public IDBTransaction Transaction(string[] storeNames, TransactionMode mode = TransactionMode.READWRITE, TransactionDurability durability = TransactionDurability.DEFAULT)
        {
            var modeStr = mode.ToString().ToLower();
            dynamic options = new ExpandoObject();
            options.durability = durability.ToString().ToLower();
            return Transaction(storeNames, modeStr, options);
        }

        public IDBTransaction Transaction(string[] storeNames, string mode, ExpandoObject options)
        {
            IDBTransaction transaction = _ref.Call<IDBTransaction>("transaction", storeNames, mode, options);
            return transaction;
        }

        // TODO - below needs to be verified working
        public string[] ObjectStoreNames()
        {
            using(var domStringList = _ref.Get<JSObject>("objectStoreNames"))
            {
                var ret = new List<string>();
                var length = domStringList._ref.Get<int>("length");
                for (var i = 0; i < length; i++)
                {
                    var tmp = domStringList._ref.Call<string>("item", i);
                    ret.Add(tmp);
                }
                return ret.ToArray();
            }
        }

        public bool ObjectStoreExists(string name)
        {
            return ObjectStoreNames().Contains(name);
        }

        // https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase/createObjectStore
        public IDBObjectStore CreateObjectStore(string storeName, string keyPath = null, bool autoIncrement = false)
        {
            dynamic options = new ExpandoObject();
            if (!string.IsNullOrEmpty(keyPath)) options.keyPath = keyPath;
            options.autoIncrement = autoIncrement;
            IDBObjectStore objectStore;
            if (options == null)
                objectStore = _ref.Call<IDBObjectStore>("createObjectStore", storeName);
            else
                objectStore = _ref.Call<IDBObjectStore>("createObjectStore", storeName, (object)options);
            return objectStore;
        }

        public void DeleteObjectStore(string storeName)
        {
            _ref.CallVoid("deleteObjectStore", storeName);
        }

        // static
        public static CallbackGroup AttachErrorSuccessHandler(JSObject request, Action<JSObject> onError, Action<JSObject> onSuccess)
        {
            var callbackGroup = new CallbackGroup();
            request._ref.Set("onerror", Callback.Create((JSObject arg0) => {
                callbackGroup.Dispose();
                onError.Invoke(arg0);
                arg0.Dispose();
            }, callbackGroup));
            request._ref.Set("onsuccess", Callback.Create((JSObject arg0) => {
                callbackGroup.Dispose();
                onSuccess.Invoke(arg0);
                arg0.Dispose();
            }, callbackGroup));
            return callbackGroup;
        }
    }
}
