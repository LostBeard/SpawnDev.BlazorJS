using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Screen>))]
    public class Screen : JSObject
    {
        public Screen(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int AvailHeight => _ref.Get<int>("availHeight");
        public int AvailLeft => _ref.Get<int>("availLeft");
        public int AvailTop => _ref.Get<int>("availTop");
        public int AvailWidth => _ref.Get<int>("availWidth");
        public int ColorDepth => _ref.Get<int>("colorDepth");
        public double DevicePixelRatio { get { var tmp = JS.Get<double>("window.devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        public int Height => _ref.Get<int>("height");
        public bool IsExtended => _ref.Get<bool>("isExtended");
        public int PixelDepth => _ref.Get<int>("pixelDepth");
        public int Width => _ref.Get<int>("width");
        public ScreenOrientation Orientation => _ref.Get<ScreenOrientation>("orientation");
    }
}
