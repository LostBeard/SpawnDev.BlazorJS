using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Event data for the onbeforeunload event
    /// </summary>
    public class OnBeforeUnloadEvent
    {
        /// <summary>
        /// The confirmation text to show the user
        /// </summary>
        public string? ConfirmationText { get; set; } = null;
    }

    /// <summary>
    /// Service that provides access to the window.onbeforeunload event
    /// </summary>
    public class BeforeUnloadService : IBackgroundService
    {
        /// <summary>
        /// Delegate for the unload event
        /// </summary>
        public delegate void UnloadDelegate();
        /// <summary>
        /// Delegate for the beforeunload event
        /// </summary>
        /// <param name="beforeUnloadEvent"></param>
        public delegate void BeforeUnloadDelegate(OnBeforeUnloadEvent beforeUnloadEvent);
        /// <summary>
        /// Event that is fired before the window is unloaded
        /// </summary>
        public event BeforeUnloadDelegate OnBeforeUnload = default!;
        BlazorJSRuntime JS;
        Callback? BeforeUnloadCallback;
        /// <summary>
        /// Creates a new instance of the BeforeUnloadService
        /// </summary>
        /// <param name="js"></param>
        public BeforeUnloadService(BlazorJSRuntime js)
        {
            JS = js;
            if (!JS.IsWindow) return;
            BeforeUnloadCallback = new FuncCallback<BeforeUnloadEvent, string?>(Window_OnBeforeUnload);
            using var window = JS.GetWindow();
            window!.AddEventListener("beforeunload", BeforeUnloadCallback);
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