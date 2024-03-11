using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Performance interface provides access to performance-related information for the current page.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Performance
    /// </summary>
    public class Performance : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Performance(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        //public EventCounts EventCounts => JSRef.Get<EventCounts>("eventCounts");
        //public JSObject Memory => JSRef.Get<JSObject>("memory");
        //public PerformanceNavigation Navigation => JSRef.Get<PerformanceNavigation>("navigation");
        //public Number TimeOrigin => JSRef.Get<Number>("timeOrigin");
        //public PerformanceTiming Timing => JSRef.Get<PerformanceTiming>("timing");
        #endregion

        #region Methods
        //public void ClearMarks() => JSRef.CallVoid("clearMarks");
        //public void ClearMeasures() => JSRef.CallVoid("clearMeasures");
        //public void ClearResourceTimings() => JSRef.CallVoid("clearResourceTimings");
        //public void GetEntries() => JSRef.CallVoid("getEntries");
        //public void GetEntriesByName() => JSRef.CallVoid("getEntriesByName");
        //public void GetEntriesByType() => JSRef.CallVoid("getEntriesByType");
        //public void Mark() => JSRef.CallVoid("mark");
        //public void Measure() => JSRef.CallVoid("measure");
        /// <summary>
        /// Returns a DOMHighResTimeStamp representing the number of milliseconds elapsed since a reference instant.
        /// </summary>
        /// <returns></returns>
        public double Now() => JSRef.Call<double>("now");
        //public void SetResourceTimingBufferSize() => JSRef.CallVoid("setResourceTimingBufferSize");
        //public void ToJSON() => JSRef.CallVoid("toJSON");
        #endregion

        #region Events
        /// <summary>
        /// The resourcetimingbufferfull event is fired when the browser's resource timing buffer is full.
        /// </summary>
        public JSEventCallback<Event> OnResourceTimingBufferFull { get => new JSEventCallback<Event>("resourcetimingbufferfull", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
