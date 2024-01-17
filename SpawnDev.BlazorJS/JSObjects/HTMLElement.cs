using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement
    // TODO - finish
    public class HTMLElement : Element
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLElement(ElementReference elRef) : base(JS.ReturnMe<IJSInProcessObjectReference>(elRef)) { }
        public int OffsetWidth => JSRef.Get<int>("offsetWidth");
        public int OffsetHeight => JSRef.Get<int>("offsetHeight");
        public static explicit operator HTMLElement(ElementReference elRef) => new HTMLElement(elRef);
        public void Focus() => JSRef.CallVoid("focus");
        public string InnerText { get => JSRef.Get<string>("innerText"); set => JSRef.Set("innerText", value); }

        // Input events
        // https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement#input_events
        public JSEventCallback<InputEvent> OnBeforeInput { get => new JSEventCallback<InputEvent>(o => AddEventListener("beforeinput", o), o => RemoveEventListener("beforeinput", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<InputEvent> OnInput { get => new JSEventCallback<InputEvent>(o => AddEventListener("input", o), o => RemoveEventListener("input", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<Event> OnChange { get => new JSEventCallback<Event>(o => AddEventListener("change", o), o => RemoveEventListener("change", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        //
        public JSEventCallback<DragEvent> OnDrag { get => new JSEventCallback<DragEvent>(o => AddEventListener("drag", o), o => RemoveEventListener("drag", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<DragEvent> OnDragEnd { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragend", o), o => RemoveEventListener("dragend", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<DragEvent> OnDragEnter { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragenter", o), o => RemoveEventListener("dragenter", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<DragEvent> OnDragLeave { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragleave", o), o => RemoveEventListener("dragleave", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<DragEvent> OnDragOver { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragover", o), o => RemoveEventListener("dragover", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<DragEvent> OnDragStart { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragstart", o), o => RemoveEventListener("dragstart", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<DragEvent> OnDrop { get => new JSEventCallback<DragEvent>(o => AddEventListener("drop", o), o => RemoveEventListener("drop", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }

        public JSEventCallback<Event> OnLoad { get => new JSEventCallback<Event>(o => AddEventListener("load", o), o => RemoveEventListener("load", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<Event> OnError { get => new JSEventCallback<Event>(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    }
}