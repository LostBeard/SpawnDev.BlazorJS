using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMRectReadOnly interface specifies the standard properties used by DOMRect to define a rectangle whose properties are immutable.
    /// </summary>
    public class DOMRectReadOnly : JSObject
    {
        public DOMRectReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        public virtual float X
        {
            get => JSRef!.Get<float>("x");
            set { /* ReadOnly */ }
        }
        public virtual float Y
        {
            get => JSRef!.Get<float>("y");
            set { /* ReadOnly */ }
        }
        public virtual float Width
        {
            get => JSRef!.Get<float>("width");
            set { /* ReadOnly */ }
        }
        public virtual float Height
        {
            get => JSRef!.Get<float>("height");
            set { /* ReadOnly */ }
        }
        public virtual float Top
        {
            get => JSRef!.Get<float>("top");
            set { /* ReadOnly */ }
        }
        public virtual float Right
        {
            get => JSRef!.Get<float>("right");
            set { /* ReadOnly */ }
        }
        public virtual float Bottom
        {
            get => JSRef!.Get<float>("bottom");
            set { /* ReadOnly */ }
        }
        public virtual float Left
        {
            get => JSRef!.Get<float>("left");
            set { /* ReadOnly */ }
        }
    }
}