using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class SyncIterator : JSObject
    {
        public SyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IteratorResult Next() => JSRef.Call<IteratorResult>("next");
        public IteratorResult<TValue> Next<TValue>() => JSRef.Call<IteratorResult<TValue>>("next");
    }
    public class Iterator<TValue> : JSObject
    {
        public Iterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IteratorResult<TValue> Next() => JSRef.Call<IteratorResult<TValue>>("next");
    }
}
