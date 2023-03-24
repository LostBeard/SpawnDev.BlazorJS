using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement
    public class HTMLVideoElement : HTMLMediaElement
    {
        public HTMLVideoElement(ElementReference elRef) : base(JS.ToJSRef(elRef)) { }
        public HTMLVideoElement() : base(JS.DocumentCreateElement("video")) { }
        public HTMLVideoElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int VideoWidth => JSRef.Get<int>("videoWidth");
        public int VideoHeight => JSRef.Get<int>("videoHeight");
        public bool SupportsRequestVideoFrameCallback => !JS.IsUndefined(this, "requestVideoFrameCallback");
        public void RequestVideoFrameCallback(Callback callback) => JSRef.CallVoid("requestVideoFrameCallback", callback);
    }
}