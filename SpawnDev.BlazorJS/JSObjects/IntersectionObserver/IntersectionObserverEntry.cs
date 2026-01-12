using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IntersectionObserverEntry interface of the Intersection Observer API describes the intersection between the target element and its root container at a specific moment of transition.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserverEntry
    /// </summary>
    public class IntersectionObserverEntry : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IntersectionObserverEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the bounds of the target element as a DOMRectReadOnly. The bounds are computed as described in the documentation for Element.getBoundingClientRect().
        /// </summary>
        public DOMRectReadOnly BoundingClientRect => JSRef!.Get<DOMRectReadOnly>("boundingClientRect");
        /// <summary>
        /// Returns the ratio of the intersectionRect to the boundingClientRect.
        /// </summary>
        public double IntersectionRatio => JSRef!.Get<double>("intersectionRatio");
        /// <summary>
        /// Returns a DOMRectReadOnly representing the target's visible area.
        /// </summary>
        public DOMRectReadOnly IntersectionRect => JSRef!.Get<DOMRectReadOnly>("intersectionRect");
        /// <summary>
        /// A Boolean value which is true if the target element intersects with the intersection observer's root. If this is true, then, the IntersectionObserverEntry describes a transition into a state of intersection; if it's false, then you know the transition is from intersecting to not-intersecting.
        /// </summary>
        public bool IsIntersecting => JSRef!.Get<bool>("isIntersecting");
        /// <summary>
        /// Returns a DOMRectReadOnly for the intersection observer's root.
        /// </summary>
        public DOMRectReadOnly? RootBounds => JSRef!.Get<DOMRectReadOnly?>("rootBounds");
        /// <summary>
        /// The Element whose intersection with the root is being observed.
        /// </summary>
        public Element Target => JSRef!.Get<Element>("target");
        /// <summary>
        /// A DOMHighResTimeStamp indicating the time at which the intersection was recorded, relative to the IntersectionObserver's time origin.
        /// </summary>
        public double Time => JSRef!.Get<double>("time");
    }
}
