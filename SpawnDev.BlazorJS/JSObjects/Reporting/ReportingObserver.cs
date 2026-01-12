using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ReportingObserver interface of the Reporting API allows you to collect and access reports.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver
    /// </summary>
    public class ReportingObserver : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ReportingObserver(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new ReportingObserver object instance, which can be used to collect and access reports.
        /// </summary>
        /// <param name="callback">A function which is called when the ReportingObserver detects a report. The function receives two parameters:<br/>
        /// reports: An array of Report objects.<br/>
        /// observer: The ReportingObserver object that detected the report.
        /// </param>
        /// <param name="options">An object allowing you to configure the observer.</param>
        public ReportingObserver(Action<Report[], ReportingObserver> callback, ReportingObserverOptions? options = null) : base(JS.New(nameof(ReportingObserver), Callback.Create(callback), options)) { }
        /// <summary>
        /// The disconnect() method of the ReportingObserver interface stops the observer from collecting reports.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// The observe() method of the ReportingObserver interface tells the observer to start collecting reports.
        /// </summary>
        public void Observe() => JSRef!.CallVoid("observe");
        /// <summary>
        /// The takeRecords() method of the ReportingObserver interface returns the current list of reports contained in the observer and empties the list.
        /// </summary>
        /// <returns></returns>
        public Report[] TakeRecords() => JSRef!.Call<Report[]>("takeRecords");
    }
}
