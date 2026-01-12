using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PerformanceObserverEntryList interface is a list of performance events that were observed, and is delivered to the callback function of a PerformanceObserver.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserverEntryList
    /// </summary>
    public class PerformanceObserverEntryList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PerformanceObserverEntryList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a list of PerformanceEntry objects based on the given name and entry type.
        /// </summary>
        /// <returns></returns>
        public PerformanceEntry[] GetEntries() => JSRef!.Call<PerformanceEntry[]>("getEntries");
        /// <summary>
        /// Returns a list of PerformanceEntry objects based on the given name and entry type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public PerformanceEntry[] GetEntriesByType(string type) => JSRef!.Call<PerformanceEntry[]>("getEntriesByType", type);
        /// <summary>
        /// Returns a list of PerformanceEntry objects based on the given name and entry type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public PerformanceEntry[] GetEntriesByName(string name, string? type = null) => JSRef!.Call<PerformanceEntry[]>("getEntriesByName", name, type);
    }
}
