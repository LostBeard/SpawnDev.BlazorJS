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
    
    public class Document : Node
    {
        public Document(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Element ActiveElement => JSRef.Get<Element>("sctiveElement");
        public T CreateElement<T>(string tagName) where T : JSObject => JSRef.Call<T>("createElement", tagName);
        public IJSInProcessObjectReference CreateElement(string tagName) => JSRef.Call<IJSInProcessObjectReference>("createElement", tagName);
        public async ValueTask ExitFullscreen() => JSRef.CallVoidAsync("exitFullscreen");
    }
}
