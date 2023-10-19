using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PushMessageData : ExtendableEvent
    {
        public PushMessageData(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ArrayBuffer ArrayBuffer() => JSRef.Call<ArrayBuffer>("arrayBuffer");
        public Blob Blob() => JSRef.Call<Blob>("blob");
        public T Json<T>() => JSRef.Call<T>("json"); 
        public string Text() => JSRef.Call<string>("text");
    }
}
