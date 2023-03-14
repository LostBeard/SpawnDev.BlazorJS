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
    
    public class ScreenDetails : JSObject
    {
        public ScreenDetails(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ScreenDetailed CurrentScreen => JSRef.Get<ScreenDetailed>("currentScreen");
        public ScreenDetailed[] Screens => JSRef.Get<ScreenDetailed[]>("screens");
    }
}
