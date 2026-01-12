using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PerformanceObserver interface is used to observe the following performance measurement events to be notified of new performance entries as they are recorded in the browser's performance timeline.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver
    /// </summary>
    public class PerformanceObserver : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PerformanceObserver(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new PerformanceObserver object which will invoke a specified callback function when new performance entries are recorded.
        /// </summary>
        /// <param name="callback">A function which is called when performance entries are recorded. The callback receives as input two parameters:<br/>
        /// list: A PerformanceObserverEntryList object containing the reported entries.<br/>
        /// observer: The PerformanceObserver object itself.<br/>
        /// </param>
        public PerformanceObserver(Action<PerformanceObserverEntryList, PerformanceObserver> callback) : base(JS.New(nameof(PerformanceObserver), Callback.Create(callback))) { }
        /// <summary>
        /// Stops the PerformanceObserver object from receiving performance notifications.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// Specifies the set of entry types to observe. The observer's callback function will be invoked when a performance entry is recorded for one of the specified entry types.
        /// </summary>
        /// <param name="options">A PerformanceObserverInit object specifying the entry types to observe.</param>
        public void Observe(PerformanceObserverInit options) => JSRef!.CallVoid("observe", options);
        /// <summary>
        /// Returns the current list of performance entries stored in the performance observer, emptying it out.
        /// </summary>
        /// <returns></returns>
        public PerformanceEntry[] TakeRecords() => JSRef!.Call<PerformanceEntry[]>("takeRecords");
        /// <summary>
        /// Returns an array of the supported performance entry types.
        /// </summary>
        public static string[] SupportedEntryTypes => JS.Get<string[]>("PerformanceObserver.supportedEntryTypes");
    }
}
