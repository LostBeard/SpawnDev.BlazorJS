using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // TODO - finish
    public class HTMLInputElement : HTMLElement
    {
        public HTMLInputElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLInputElement(ElementReference elRef) : base(JS.ToJSRef(elRef)) { }
        public Array<File>? Files => JSRef.Get<Array<File>?>("files");
        public string Value => JSRef.Get<string>("value");
    }
}
