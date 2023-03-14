using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class Screen : JSObject
    {
        public Screen(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int AvailHeight => JSRef.Get<int>("availHeight");
        public int AvailLeft => JSRef.Get<int>("availLeft");
        public int AvailTop => JSRef.Get<int>("availTop");
        public int AvailWidth => JSRef.Get<int>("availWidth");
        public int ColorDepth => JSRef.Get<int>("colorDepth");
        public double DevicePixelRatio { get { var tmp = JS.Get<double>("window.devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        public int Height => JSRef.Get<int>("height");
        public bool IsExtended => JSRef.Get<bool>("isExtended");
        public int PixelDepth => JSRef.Get<int>("pixelDepth");
        public int Width => JSRef.Get<int>("width");
        public ScreenOrientation Orientation => JSRef.Get<ScreenOrientation>("orientation");
    }
}
