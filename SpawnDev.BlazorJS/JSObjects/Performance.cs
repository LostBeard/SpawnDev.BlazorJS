using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Performance : EventTarget
    {
        #region Constructors
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
        public JSEventCallback OnResourceTimingBufferFull { get => new JSEventCallback(o => AddEventListener("resourcetimingbufferfull", o), o => RemoveEventListener("resourcetimingbufferfull", o)); set { /** required **/ } }
        #endregion
    }
}
