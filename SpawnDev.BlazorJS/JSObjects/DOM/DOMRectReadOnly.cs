using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMRectReadOnly interface specifies the standard properties used by DOMRect to define a rectangle whose properties are immutable.
    /// </summary>
    public class DOMRectReadOnly : JSObject
    {
        /// <summary>
        /// Creates a new instance of <see cref="DOMRectReadOnly"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public DOMRectReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The x coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
        /// </summary>
        public virtual float X
        {
            get => JSRef!.Get<float>("x");
            set { /* ReadOnly */ }
        }
        /// <summary>
        /// The y coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
        /// </summary>
        public virtual float Y
        {
            get => JSRef!.Get<float>("y");
            set { /* ReadOnly */ }
        }
        /// <summary>
        /// The width of the DOMRect.
        /// </summary>
        public virtual float Width
        {
            get => JSRef!.Get<float>("width");
            set { /* ReadOnly */ }
        }
        /// <summary>
        /// The height of the DOMRect.
        /// </summary>
        public virtual float Height
        {
            get => JSRef!.Get<float>("height");
            set { /* ReadOnly */ }
        }
        /// <summary>
        /// The top coordinate value of the DOMRect (has the same value as y, or y + height if height is negative).
        /// </summary>
        public virtual float Top
        {
            get => JSRef!.Get<float>("top");
            set { /* ReadOnly */ }
        }
        /// <summary>
        /// The right coordinate value of the DOMRect (has the same value as x + width, or x if width is negative).
        /// </summary>
        public virtual float Right
        {
            get => JSRef!.Get<float>("right");
            set { /* ReadOnly */ }
        }
        /// <summary>
        /// The bottom coordinate value of the DOMRect (has the same value as y + height, or y if height is negative).
        /// </summary>
        public virtual float Bottom
        {
            get => JSRef!.Get<float>("bottom");
            set { /* ReadOnly */ }
        }
        /// <summary>
        /// The left coordinate value of the DOMRect (has the same value as x, or x + width if width is negative).
        /// </summary>
        public virtual float Left
        {
            get => JSRef!.Get<float>("left");
            set { /* ReadOnly */ }
        }
    }
}