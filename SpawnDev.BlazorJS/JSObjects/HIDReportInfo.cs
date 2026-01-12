using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A HIDReportInfo represents one input, output, or feature report within the report descriptor.
    /// https://wicg.github.io/webhid/#dom-hidreportinfo
    /// </summary>
    public class HIDReportInfo : JSObject
    {
        /// <summary>
        /// Creates a new instance of <see cref="HIDReportInfo"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public HIDReportInfo(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }

        /// <summary>
        /// A HID interface uses report IDs if it prepends a one-byte identification prefix to each report transfer. The reportId member is the prefix for this report if the interface uses report IDs, or 0 otherwise.
        /// </summary>
        public byte ReportId => JSRef!.Get<byte>("reportId");

        /// <summary>
        /// A sequence of HIDReportItem representing the fields of this report.
        /// </summary>
        public IEnumerable<HIDReportItem> Items => JSRef!.Get<IEnumerable<HIDReportItem>>("items");
    }
}