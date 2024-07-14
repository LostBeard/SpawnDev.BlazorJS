using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A DOMRect describes the size and position of a rectangle.<br/>
    /// The type of box represented by the DOMRect is specified by the method or property that returned it. For example, Range.getBoundingClientRect() specifies the rectangle that bounds the content of the range using such objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMRect
    /// </summary>
    public class DOMRect : DOMRectReadOnly
    {
        /// <summary>
        /// The DOMRect() constructor creates a new DOMRect object.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public DOMRect(float x, float y, float width, float height) : base(JS.New(nameof(DOMRect), x, y, width, height)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DOMRect(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The x coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
        /// </summary>
        public override float X
        {
            get => JSRef!.Get<float>("x");
            set => JSRef!.Set("x", value);
        }
        /// <summary>
        /// The y coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
        /// </summary>
        public override float Y
        {
            get => JSRef!.Get<float>("y");
            set => JSRef!.Set("y", value);
        }
        /// <summary>
        /// The width of the DOMRect.
        /// </summary>
        public override float Width
        {
            get => JSRef!.Get<float>("width");
            set => JSRef!.Set("width", value);
        }
        /// <summary>
        /// The height of the DOMRect.
        /// </summary>
        public override float Height
        {
            get => JSRef!.Get<float>("height");
            set => JSRef!.Set("width", value);
        }
        /// <summary>
        /// Returns the top coordinate value of the DOMRect (has the same value as y, or y + height if height is negative).
        /// </summary>
        public override float Top
        {
            get => JSRef!.Get<float>("top");
            set => JSRef!.Set("top", value);
        }
        /// <summary>
        /// Returns the right coordinate value of the DOMRect (has the same value as x + width, or x if width is negative).
        /// </summary>
        public override float Right
        {
            get => JSRef!.Get<float>("right");
            set => JSRef!.Set("right", value);
        }
        /// <summary>
        /// Returns the bottom coordinate value of the DOMRect (has the same value as y + height, or y if height is negative).
        /// </summary>
        public override float Bottom
        {
            get => JSRef!.Get<float>("bottom");
            set => JSRef!.Set("bottom", value);
        }
        /// <summary>
        /// Returns the left coordinate value of the DOMRect (has the same value as x, or x + width if width is negative).
        /// </summary>
        public override float Left
        {
            get => JSRef!.Get<float>("left");
            set => JSRef!.Set("left", value);
        }
    }
}