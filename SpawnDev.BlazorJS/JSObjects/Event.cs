using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Event : JSObject
    {
        public Event(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Bubbles => JSRef.Get<bool>("bubbles");
        public bool Cancelable => JSRef.Get<bool>("cancelable");
        public bool Composed => JSRef.Get<bool>("composed");
        public EventTarget Target => JSRef.Get<EventTarget>("target");
        public T TargetAs<T>() where T : EventTarget => JSRef.Get<T>("target");
        public void PreventDefault() => JSRef.CallVoid("preventDefault");
        public string Type => JSRef.Get<string>("type");
    }
}
