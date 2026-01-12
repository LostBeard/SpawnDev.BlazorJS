using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DeprecationReportBody interface of the Reporting API represents the body of a deprecation report.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DeprecationReportBody
    /// </summary>
    public class DeprecationReportBody : ReportBody
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DeprecationReportBody(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string representing the feature or API that is deprecated, for example "insecure-origin" or "synchronous-xhr".
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// A string containing a human-readable description of the deprecation, including information such as what to use instead.
        /// </summary>
        public string Message => JSRef!.Get<string>("message");
        /// <summary>
        /// A string containing the path to the source file where the deprecated feature is used, if known, or null otherwise.
        /// </summary>
        public string? SourceFile => JSRef!.Get<string?>("sourceFile");
        /// <summary>
        /// A number representing the line in the source file in which the deprecated feature is used, if known, or null otherwise.
        /// </summary>
        public int? LineNumber => JSRef!.Get<int?>("lineNumber");
        /// <summary>
        /// A number representing the column in the source file in which the deprecated feature is used, if known, or null otherwise.
        /// </summary>
        public int? ColumnNumber => JSRef!.Get<int?>("columnNumber");
        /// <summary>
        /// A Date object (rendered as a string) representing the date when the feature is expected to be removed from the browser. If the date is not known, this property is null.
        /// </summary>
        public DateTime? AnticipatedRemoval => JSRef!.Get<DateTime?>("anticipatedRemoval");
    }
}
