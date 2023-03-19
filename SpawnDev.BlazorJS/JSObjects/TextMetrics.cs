using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics
    public class TextMetrics : JSObject
    {
        public TextMetrics(IJSInProcessObjectReference _ref) : base(_ref) { }
        public double Width { get => JSRef.Get<double>("width"); set => JSRef.Set("width", value); }
    }
}
