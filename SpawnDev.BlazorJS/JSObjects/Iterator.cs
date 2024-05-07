﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Iterator : JSObject
    {
        public Iterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IteratorResult Next() => JSRef.Call<IteratorResult>("next");
        public IteratorResult<TValue> Next<TValue>() => JSRef.Call<IteratorResult<TValue>>("next");
    }
    public class Iterator<TValue> : JSObject
    {
        public Iterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IteratorResult<TValue> Next() => JSRef.Call<IteratorResult<TValue>>("next");
    }
}
