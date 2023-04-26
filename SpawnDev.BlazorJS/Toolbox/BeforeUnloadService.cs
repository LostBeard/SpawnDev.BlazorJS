
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using System;

namespace SpawnDev.BlazorJS.Toolbox
{
    public class BeforeUnloadEvent
    {
        public string? ConfirmationText { get; set; } = null;
    }

    public class BeforeUnloadService : IBackgroundService
    {
        public delegate void UnloadDelegate();
        public delegate void BeforeUnloadDelegate(BeforeUnloadEvent beforeUnloadEvent);

        public event BeforeUnloadDelegate OnBeforeUnload;
        //public event UnloadDelegate OnUnload;
        BlazorJSRuntime JS;
        public BeforeUnloadService(BlazorJSRuntime js)
        {
            JS = js;
            using var window = JS.GetWindow<Window>();
            window.AddEventListener("beforeunload", Callback.Create(new Func<JSObject, string?>((e) =>
            {
                Console.WriteLine("beforeunload");
                BeforeUnloadEvent beforeUnloadEvent = new BeforeUnloadEvent();
                OnBeforeUnload?.Invoke(beforeUnloadEvent);
                if (!string.IsNullOrEmpty(beforeUnloadEvent.ConfirmationText))
                {
                    e.JSRef.CallVoid("preventDefault");
                    e.JSRef.Set("returnValue", beforeUnloadEvent.ConfirmationText);
                    return beforeUnloadEvent.ConfirmationText;
                }
                return null;
            })));
        }

        public Task InitAsync()
        {
            return Task.FromResult(0);
        }
    }
}