using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ResizeObserver>))]
    public class ResizeObserver : JSObject
    {
        public ResizeObserver(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ResizeObserver(ActionCallback<List<ResizeObserverEntry>> callback) : base("ResizeObserver", callback) { }
        public ResizeObserver(Callback callback) : base("ResizeObserver", callback) { }
        public void Observe(IJSInProcessObjectReference el) => JSRef.CallVoid("observe", el);
        public void Unobserve(IJSInProcessObjectReference el) => JSRef.CallVoid("unobserve", el);
        public void Observe(ElementReference el) => JSRef.CallVoid("observe", el);
        public void Unobserve(ElementReference el) => JSRef.CallVoid("unobserve", el);
    }
}
