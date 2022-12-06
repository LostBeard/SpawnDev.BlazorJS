using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ScreenDetailed>))]
    public class ScreenDetailed : JSObject
    {
        public ScreenDetailed(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int AvailHeight => _ref.Get<int>("availHeight");
        public int AvailLeft => _ref.Get<int>("availLeft");
        public int AvailTop => _ref.Get<int>("availTop");
        public int AvailWidth => _ref.Get<int>("availWidth");
        public int ColorDepth => _ref.Get<int>("colorDepth");
        public double DevicePixelRatio { get { var tmp = _ref.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        public int Height => _ref.Get<int>("height");
        public bool IsExtended => _ref.Get<bool>("isExtended");
        public bool IsInternal => _ref.Get<bool>("isInternal");
        public bool IsPrimary => _ref.Get<bool>("isPrimary");
        public string Label => _ref.Get<string>("label");
        public int Left => _ref.Get<int>("left");
        public int PixelDepth => _ref.Get<int>("pixelDepth");
        public int Top => _ref.Get<int>("top");
        public int Width => _ref.Get<int>("width");
        public ScreenOrientation Orientation => _ref.Get<ScreenOrientation>("orientation");
    }
}
