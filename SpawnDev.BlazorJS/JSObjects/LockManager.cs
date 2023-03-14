using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class LockManager : JSObject {
        public LockManager(IJSInProcessObjectReference _ref) : base(_ref) {
        }

        // https://developer.mozilla.org/en-US/docs/Web/API/LockManager/request
        //public Promise Request(string lockName, Promise lockHolder) => JSRef.Call<Promise>(lockName, lockHolder);
        //public Promise Request(string lockName, object options, Promise lockHolder) => JSRef.Call<Promise>(lockName, options, lockHolder);
        public Promise Request(string lockName, FuncCallback<Lock, Promise> callback) => JSRef.Call<Promise>("request", lockName, callback);
        public Promise Request(string lockName, object options, FuncCallback<Lock, Promise> callback) => JSRef.Call<Promise>("request", lockName, options, callback);

    }
}
