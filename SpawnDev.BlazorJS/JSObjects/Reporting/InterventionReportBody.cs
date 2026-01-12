using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The InterventionReportBody interface of the Reporting API represents the body of an intervention report.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/InterventionReportBody
    /// </summary>
    public class InterventionReportBody : ReportBody
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public InterventionReportBody(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string representing the intervention that occurred, for example "audio-output-device-permission".
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// A string containing a human-readable description of the intervention, including information such as how to fix the issue.
        /// </summary>
        public string Message => JSRef!.Get<string>("message");
        /// <summary>
        /// A string containing the path to the source file where the intervention occurred, if known, or null otherwise.
        /// </summary>
        public string? SourceFile => JSRef!.Get<string?>("sourceFile");
        /// <summary>
        /// A number representing the line in the source file in which the intervention occurred, if known, or null otherwise.
        /// </summary>
        public int? LineNumber => JSRef!.Get<int?>("lineNumber");
        /// <summary>
        /// A number representing the column in the source file in which the intervention occurred, if known, or null otherwise.
        /// </summary>
        public int? ColumnNumber => JSRef!.Get<int?>("columnNumber");
    }
}
