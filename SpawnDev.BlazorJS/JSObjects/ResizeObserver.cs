using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ResizeObserver interface reports changes to the dimensions of an Element's content or border box, or the bounding box of an SVGElement.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver
    /// </summary>
    public class ResizeObserver : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ResizeObserver(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates and returns a new ResizeObserver object.
        /// </summary>
        /// <param name="callback"></param>
        public ResizeObserver(ActionCallback<ResizeObserverEntry[]> callback) : base(JS.New(nameof(ResizeObserver), callback)) { }
        /// <summary>
        /// Creates and returns a new ResizeObserver object.
        /// </summary>
        /// <param name="callback"></param>
        public ResizeObserver(ActionCallback callback) : base(JS.New(nameof(ResizeObserver), callback)) { }
        /// <summary>
        /// Unobserves all observed Element targets of a particular observer.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// Initiates the observing of a specified Element.
        /// </summary>
        /// <param name="target"></param>
        public void Observe(ElementReference target) => JSRef!.CallVoid("observe", target);
        /// <summary>
        /// Initiates the observing of a specified Element.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="options"></param>
        public void Observe(Element target, ObserveOptions options) => JSRef!.CallVoid("observe", target, options);
        /// <summary>
        /// Initiates the observing of a specified Element.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="options"></param>
        public void Observe(ElementReference target, ObserveOptions options) => JSRef!.CallVoid("observe", target, options);
        /// <summary>
        /// Initiates the observing of a specified Element.
        /// </summary>
        /// <param name="target"></param>
        public void Observe(Element target) => JSRef!.CallVoid("observe", target);
        /// <summary>
        /// Ends the observing of a specified Element.
        /// </summary>
        /// <param name="el"></param>
        public void Unobserve(ElementReference el) => JSRef!.CallVoid("unobserve", el);
        /// <summary>
        /// Ends the observing of a specified Element.
        /// </summary>
        /// <param name="el"></param>
        public void Unobserve(Element el) => JSRef!.CallVoid("unobserve", el);
    }
}
