using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class HTMLElement : Element {
        public HTMLElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLElement(ElementReference elRef) : base(JS.ReturnMe<IJSInProcessObjectReference>(elRef)) { }
        public int OffsetWidth => JSRef.Get<int>("offsetWidth");
        public int OffsetHeight => JSRef.Get<int>("offsetHeight");
        public static explicit operator HTMLElement(ElementReference elRef) => new HTMLElement(elRef);
        public void Focus() => JSRef.CallVoid("focus");
    }
}