﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class StorageEvent
        : Event
    {
        public StorageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Key => JSRef!.Get<string>("key");
        public string OldValue => JSRef!.Get<string>("oldValue");
        public string NewValue => JSRef!.Get<string>("newValue");
        public string Url => JSRef!.Get<string>("url");
        public Storage StorageArea => JSRef!.Get<Storage>("storageArea");
    }
}
