using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
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
        public override float X
        {
            get => JSRef.Get<float>("x");
            set => JSRef.Set("x", value);
        }
        public override float Y
        {
            get => JSRef.Get<float>("y");
            set => JSRef.Set("y", value);
        }
        public override float Width
        {
            get => JSRef.Get<float>("width");
            set => JSRef.Set("width", value);
        }
        public override float Height
        {
            get => JSRef.Get<float>("height");
            set => JSRef.Set("width", value);
        }
        public override float Top
        {
            get => JSRef.Get<float>("top");
            set => JSRef.Set("top", value);
        }
        public override float Right
        {
            get => JSRef.Get<float>("right");
            set => JSRef.Set("right", value);
        }
        public override float Bottom
        {
            get => JSRef.Get<float>("bottom");
            set => JSRef.Set("bottom", value);
        }
        public override float Left
        {
            get => JSRef.Get<float>("left");
            set => JSRef.Set("left", value);
        }
    }
}