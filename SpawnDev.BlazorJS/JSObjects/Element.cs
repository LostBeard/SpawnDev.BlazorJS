using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/Element
    // TODO - finish
    public class Element : Node
    {
        public Element(ElementReference elRef) : base(JS.ReturnMe<IJSInProcessObjectReference>(elRef)) { }
        public Element(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DOMRect GetBoundingClientRect() => JSRef.Call<DOMRect>("getBoundingClientRect");
        public Task RequestFullscreen() => JSRef.CallVoidAsync("requestFullscreen");
        public Task RequestFullscreen(RequestFullscreenOptions options) => JSRef.CallVoidAsync("requestFullscreen", options);
        public DOMTokenList ClassList => JSRef.Get<DOMTokenList>("classList");
        public string ClassName { get => JSRef.Get<string>("className"); set => JSRef.Set("className", value); }
        public string[] ClassNames => ClassName.Split(' ').ToArray();
        public string? GetAttribute(string name) => JSRef.Call<string?>("getAttribute", name);
        public void RemoveAttribute(string name) => JSRef.CallVoid("removeAttribute", name);
        public void SetAttribute(string name, string value) => JSRef.CallVoid("setAttribute", name, value);
        public void After(params Node[] nodes) => JSRef.CallApplyVoid("after", nodes);
        public void Remove() => JSRef.CallVoid("remove");


        public float ScrollHeight => JSRef.Get<float>("scrollHeight");
        public float ScrollWidth => JSRef.Get<float>("scrollWidth");
        public float ScrollTop { get => JSRef.Get<float>("scrollTop"); set => JSRef.Set("scrollTop", value); }

        public float ClientHeight => JSRef.Get<float>("clientHeight");




        public JSEventCallback<Event> OnScroll { get => new JSEventCallback<Event>(o => AddEventListener("scroll", o), o => RemoveEventListener("scroll", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<Event> OnScrollEnd { get => new JSEventCallback<Event>(o => AddEventListener("scrollend", o), o => RemoveEventListener("scrollend", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    }
}