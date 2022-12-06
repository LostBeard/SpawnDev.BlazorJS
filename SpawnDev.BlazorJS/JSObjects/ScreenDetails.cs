using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ScreenDetails>))]
    public class ScreenDetails : JSObject
    {
        public ScreenDetails(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ScreenDetailed CurrentScreen => _ref.Get<ScreenDetailed>("currentScreen");
        public ScreenDetailed[] Screens => _ref.Get<ScreenDetailed[]>("screens");
    }
}
