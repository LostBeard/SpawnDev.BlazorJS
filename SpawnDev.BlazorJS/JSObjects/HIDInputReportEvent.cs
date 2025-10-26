using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a HIDInputReportEvent fired by a HID device.
    /// This event contains the report data received from a HID device.
    /// Corresponds to the WebHID 'HIDInputReportEvent' interface.
    /// https://wicg.github.io/webhid/#hidinputreportevent-interface
    /// </summary>
    public class HIDInputReportEvent : Event
    {
        public HIDInputReportEvent(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }

        /// <summary>
        /// The HIDDevice object associated with this event, representing the device
        /// that sent the input report.
        /// </summary>
        public HIDDevice Device => new HIDDevice(JSRef!.Get<IJSInProcessObjectReference>("device"));

        /// <summary>
        /// An 8-bit value indicating the report ID of the input report.
        /// A value of 0 means the device does not use report IDs.
        /// </summary>
        public byte ReportId => JSRef!.Get<byte>("reportId");

        /// <summary>
        /// A DataView object containing the raw input report data.
        /// </summary>
        public DataView Data => JSRef!.Get<DataView>("data");
    }
}