using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SecurityPolicyViolationEvent interface inherits from Event, and represents the event object of an event sent on a document or worker when its content security policy is violated.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/SecurityPolicyViolationEvent<br/>
    /// </summary>
    public class SecurityPolicyViolationEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SecurityPolicyViolationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string representing the URI of the resource that was blocked because it violates a policy.
        /// </summary>
        public string BlockedURI => JSRef!.Get<string>("blockedURI");
        /// <summary>
        /// The column number in the document or worker at which the violation occurred.
        /// </summary>
        public int? ColumnNumber => JSRef!.Get<int?>("columnNumber");
        /// <summary>
        /// Indicates how the violated policy is configured to be treated by the user agent. This will be "enforce" or "report".
        /// </summary>
        public string Disposition => JSRef!.Get<string>("disposition");
        /// <summary>
        /// A string representing the URI of the document or worker in which the violation was found.
        /// </summary>
        public string DocumentURI => JSRef!.Get<string>("documentURI");
        /// <summary>
        /// A string representing the directive whose enforcement uncovered the violation.
        /// </summary>
        public string EffectiveDirective => JSRef!.Get<string>("effectiveDirective");
        /// <summary>
        /// The line number in the document or worker at which the violation occurred.
        /// </summary>
        public int? LineNumber => JSRef!.Get<int?>("lineNumber");
        /// <summary>
        /// A string containing the policy whose enforcement uncovered the violation.
        /// </summary>
        public string OriginalPolicy => JSRef!.Get<string>("originalPolicy");
        /// <summary>
        /// A string representing the URL for the referrer of the resources whose policy was violated, or null.
        /// </summary>
        public string? Referrer => JSRef!.Get<string?>("referrer");
        /// <summary>
        /// A string representing a sample of the resource that caused the violation, usually the first 40 characters. This will only be populated if the resource is an inline script, event handler, or style — external resources causing a violation will not generate a sample.
        /// </summary>
        public string? Sample => JSRef!.Get<string?>("sample");
        /// <summary>
        /// If the violation occurred as a result of a script, this will be the URL of the script; otherwise, it will be null. Both columnNumber and lineNumber should have non-null values if this property is not null.
        /// </summary>
        public string? SourceFile => JSRef!.Get<string?>("sourceFile");
        /// <summary>
        /// A number representing the HTTP status code of the document or worker in which the violation occurred.
        /// </summary>
        public int StatusCode => JSRef!.Get<int>("statusCode");
        /// <summary>
        /// A string representing the directive whose enforcement uncovered the violation.
        /// </summary>
        public string ViolatedDirective => JSRef!.Get<string>("violatedDirective");


    }
}
