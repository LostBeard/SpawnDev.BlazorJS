using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BlobEvent : Event
    {
        public BlobEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Blob Data<T>() => JSRef.Get<Blob>("data");
        public double Timecode<T>() => JSRef.Get<double>("timecode");
    }
}
