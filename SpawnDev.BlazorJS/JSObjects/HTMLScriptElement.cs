using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class HTMLScriptElement : JSObject
    {
        public string Src { get => JSRef.Get<string>("src"); set => JSRef.Set("src", value); }
        public HTMLScriptElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLScriptElement() : base(JS.DocumentCreateElement("script")) { }
        public ActionCallback OnLoad { set => JSRef.Set("onload", value); }
        public ActionCallback OnError { set => JSRef.Set("onerror", value); }
        public Task OnLoadAsync()
        {
            var taskCompletionSource = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            OnLoad = Callback.Create(()=> { 
                callbacks.Dispose(); 
                taskCompletionSource.TrySetResult(); 
            }, callbacks);
            OnError = Callback.Create(() => { 
                callbacks.Dispose(); 
                taskCompletionSource.TrySetException(new Exception("Script load failed")); 
            }, callbacks);
            return taskCompletionSource.Task;
        }
    }
}
