using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    public class OnBeforeUnloadEvent
    {
        public string? ConfirmationText { get; set; } = null;
    }

    public class BeforeUnloadService : IBackgroundService
    {
        public delegate void UnloadDelegate();
        public delegate void BeforeUnloadDelegate(OnBeforeUnloadEvent beforeUnloadEvent);
        public event BeforeUnloadDelegate OnBeforeUnload;
        BlazorJSRuntime JS;
        Callback BeforeUnloadCallback;
        public BeforeUnloadService(BlazorJSRuntime js)
        {
            JS = js;
            if (!JS.IsWindow) return;
            BeforeUnloadCallback = new FuncCallback<BeforeUnloadEvent, string?>(Window_OnBeforeUnload);
            using var window = JS.GetWindow<Window>();
            window.AddEventListener("beforeunload", BeforeUnloadCallback);
        }
        string? Window_OnBeforeUnload(BeforeUnloadEvent e)
        {
            var beforeUnloadEvent = new OnBeforeUnloadEvent();
            OnBeforeUnload?.Invoke(beforeUnloadEvent);
            if (!string.IsNullOrEmpty(beforeUnloadEvent.ConfirmationText))
            {
                e.PreventDefault();
                e.ReturnValue = beforeUnloadEvent.ConfirmationText;
                return beforeUnloadEvent.ConfirmationText;
            }
            return null;
        }
    }
}