using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ReportBody interface of the Reporting API represents the body of a report. Individual report types inherit from this interface, adding specific properties for the report type.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReportBody
    /// </summary>
    public class ReportBody : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ReportBody(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The toJSON() method of the ReportBody interface is a serializer; it returns a JSON representation of the ReportBody object.
        /// </summary>
        /// <returns></returns>
        public T ToJSON<T>() => JSRef!.Call<T>("toJSON");
    }
}
