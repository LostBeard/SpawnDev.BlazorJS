using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ErrorEvent interface represents events providing information related to errors in scripts or in files.
    /// </summary>
    public class ErrorEvent : Event
    {
        public ErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing a human-readable error message describing the problem. Lacking a crossorigin setting reduces error logging.
        /// </summary>
        public string Message => JSRef.Get<string>("message");
        /// <summary>
        /// A string containing the name of the script file in which the error occurred.
        /// </summary>
        public string Filename => JSRef.Get<string>("filename");
        /// <summary>
        /// An integer containing the line number of the script file on which the error occurred.
        /// </summary>
        public int LineNO => JSRef.Get<int>("lineno");
        /// <summary>
        /// An integer containing the column number of the script file on which the error occurred.
        /// </summary>
        public int ColNO => JSRef.Get<int>("colno");
        /// <summary>
        /// A JavaScript Object that is concerned by the event.
        /// </summary>
        public JSObject? Error => JSRef.Get<JSObject?>("error");
    }
}
