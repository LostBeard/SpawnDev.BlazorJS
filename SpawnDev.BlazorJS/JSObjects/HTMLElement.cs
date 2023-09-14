using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement
    public class HTMLElement : Element {
        public HTMLElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLElement(ElementReference elRef) : base(JS.ReturnMe<IJSInProcessObjectReference>(elRef)) { }
        public int OffsetWidth => JSRef.Get<int>("offsetWidth");
        public int OffsetHeight => JSRef.Get<int>("offsetHeight");
        public static explicit operator HTMLElement(ElementReference elRef) => new HTMLElement(elRef);
        public void Focus() => JSRef.CallVoid("focus");

        // Input events
        // https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement#input_events
        public JSEventCallback<InputEvent> OnBeforeInput { get => new JSEventCallback<InputEvent>(o => AddEventListener("beforeinput", o), o => RemoveEventListener("beforeinput", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<InputEvent> OnInput { get => new JSEventCallback<InputEvent>(o => AddEventListener("input", o), o => RemoveEventListener("input", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<Event> OnChange { get => new JSEventCallback<Event>(o => AddEventListener("change", o), o => RemoveEventListener("change", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    }
}