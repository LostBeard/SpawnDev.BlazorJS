using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class HTMLFormElement : HTMLElement
    {
        public HTMLFormElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLFormElement(ElementReference elementReference) : base(JS.ToJSRef(elementReference)) { }
    }
}
