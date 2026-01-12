using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IntersectionObserver interface of the Intersection Observer API provides a way to asynchronously observe changes in the intersection of a target element with an ancestor element or with a top-level document's viewport.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver
    /// </summary>
    public class IntersectionObserver : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IntersectionObserver(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new IntersectionObserver object which will invoke a specified callback function when it detects that the intersection ratio of the target element vs the root exceeds one of the thresholds.
        /// </summary>
        /// <param name="callback">A function which is called when the percentage of the target element is visible crosses a threshold. The callback receives as input two parameters:<br/>
        /// entries: An array of IntersectionObserverEntry objects, each representing one threshold which was crossed, either becoming more or less visible than the percentage specified by that threshold.<br/>
        /// observer: The IntersectionObserver object itself.</param>
        /// <param name="options">An optional object which customizes the observer. If options isn't specified, the observer uses the document's viewport as the root, with no margin, and a 0% threshold (meaning that even a one-pixel change is enough to trigger a callback).</param>
        public IntersectionObserver(Action<IntersectionObserverEntry[], IntersectionObserver> callback, IntersectionObserverInit? options = null) : base(JS.New(nameof(IntersectionObserver), Callback.Create(callback), options)) { }
        /// <summary>
        /// Creates a new IntersectionObserver object which will invoke a specified callback function when it detects that the intersection ratio of the target element vs the root exceeds one of the thresholds.
        /// </summary>
        /// <param name="callback">A function which is called when the percentage of the target element is visible crosses a threshold. The callback receives as input two parameters:<br/>
        /// entries: An array of IntersectionObserverEntry objects, each representing one threshold which was crossed, either becoming more or less visible than the percentage specified by that threshold.<br/>
        /// observer: The IntersectionObserver object itself.</param>
        /// <param name="options">An optional object which customizes the observer. If options isn't specified, the observer uses the document's viewport as the root, with no margin, and a 0% threshold (meaning that even a one-pixel change is enough to trigger a callback).</param>
        public IntersectionObserver(ActionCallback<IntersectionObserverEntry[], IntersectionObserver> callback, IntersectionObserverInit? options = null) : base(JS.New(nameof(IntersectionObserver), callback, options)) { }
        /// <summary>
        /// Stops the IntersectionObserver object from observing any target.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// Tells the IntersectionObserver a target element to observe.
        /// </summary>
        /// <param name="target">The Element to be observed.</param>
        public void Observe(Element target) => JSRef!.CallVoid("observe", target);
        /// <summary>
        /// Returns an array of IntersectionObserverEntry objects for all observed targets.
        /// </summary>
        /// <returns></returns>
        public IntersectionObserverEntry[] TakeRecords() => JSRef!.Call<IntersectionObserverEntry[]>("takeRecords");
        /// <summary>
        /// Tells the IntersectionObserver to stop observing a particular target element.
        /// </summary>
        /// <param name="target">The Element to stop observing.</param>
        public void Unobserve(Element target) => JSRef!.CallVoid("unobserve", target);
        /// <summary>
        /// The Element or Document whose bounds are used as the bounding box when testing for intersection. If no root is passed to the constructor or its value is null, the top-level document's viewport is used.
        /// </summary>
        public Element? Root => JSRef!.Get<Element?>("root");
        /// <summary>
        /// A string, similar to the CSS margin property, setting the offsets to apply to the root's bounding_box when calculating intersections.
        /// </summary>
        public string RootMargin => JSRef!.Get<string>("rootMargin");
        /// <summary>
        /// A list of thresholds, sorted in increasing numeric order, where each threshold is a ratio of intersection area to bounding box area of an observed target.
        /// </summary>
        public double[] Thresholds => JSRef!.Get<double[]>("thresholds");
    }
}
