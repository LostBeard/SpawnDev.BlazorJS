using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Report interface of the Reporting API represents a single report. Reports can be accessed via the ReportingObserver interface, or via the Report-To HTTP header.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Report
    /// </summary>
    public class Report : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Report(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string representing the type of report generated, e.g. "deprecation" or "intervention".
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
        /// <summary>
        /// A string representing the URL of the document that generated the report.
        /// </summary>
        public string Url => JSRef!.Get<string>("url");
        /// <summary>
        /// A ReportBody object containing the body of the report. The interface of the body depends on the type of report.
        /// </summary>
        public ReportBody? Body
        {
            get
            {
                var type = Type;
                return type switch
                {
                    "deprecation" => JSRef!.Get<DeprecationReportBody?>("body"),
                    "intervention" => JSRef!.Get<InterventionReportBody?>("body"),
                    "crash" => JSRef!.Get<CrashReportBody?>("body"),
                    _ => JSRef!.Get<ReportBody?>("body"),
                };
            }
        }
    }
}
