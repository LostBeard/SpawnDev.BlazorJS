using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HIDCollectionInfo interface of the WebHID API represents a collection of HID reports and their associated metadata.
    /// https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice/collections
    /// </summary>
    public class HIDCollectionInfo : JSObject
    {
        /// <summary>
        /// Creates a new instance of <see cref="HIDCollectionInfo"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public HIDCollectionInfo(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }

        /// <summary>
        /// An integer representing the usage page component of the HID usage associated with this collection. The usage for a top level collection is used to identify the device type.
        /// </summary>
        public int UsagePage => JSRef!.Get<int>("usagePage");

        /// <summary>
        /// An integer representing the usage ID component of the HID usage associated with this collection.
        /// </summary>
        public int Usage => JSRef!.Get<int>("usage");

        /// <summary>
        /// An 8-bit value representing the collection type, which describes a different relationship between the grouped items.
        /// It can be one of the following values:
        /// <list type="bullet">
        ///     <item>
        ///         <term>0x00</term>
        ///         <description>Physical (group of axes)</description>
        ///     </item>
        ///     <item>
        ///         <term>0x01</term>
        ///         <description>Application (mouse, keyboard)</description>
        ///     </item>
        ///     <item>
        ///         <term>0x02</term>
        ///         <description>Logical (interrelated data)</description>
        ///     </item>
        ///     <item>
        ///         <term>0x03</term>
        ///         <description>Report</description>
        ///     </item>
        ///     <item>
        ///         <term>0x04</term>
        ///         <description>Named array</description>
        ///     </item>
        ///     <item>
        ///         <term>0x05</term>
        ///         <description>Usage switch</description>
        ///     </item>
        ///     <item>
        ///         <term>0x06</term>
        ///         <description>Usage modified</description>
        ///     </item>
        ///     <item>
        ///         <term>0x07 to 0x7F</term>
        ///         <description>Reserved for future use</description>
        ///     </item>
        ///     <item>
        ///         <term>0x80 to 0xFF</term>
        ///         <description>Vendor-defined</description>
        ///     </item>
        /// </list>
        /// </summary>
        public byte Type => JSRef!.Get<byte>("type");

        /// <summary>
        /// An array of sub-collections which takes the same format as a top-level collection.
        /// </summary>
        public HIDCollectionInfo[] Children => JSRef!.Get<HIDCollectionInfo[]>("children");

        /// <summary>
        /// An array of inputReport items which represent individual input reports described in this collection.
        /// </summary>
        public HIDReportInfo[] InputReports => JSRef!.Get<HIDReportInfo[]>("inputReports");

        /// <summary>
        /// An array of outputReport items which represent individual output reports described in this collection.
        /// </summary>
        public HIDReportInfo[] OutputReports => JSRef!.Get<HIDReportInfo[]>("outputReports");

        /// <summary>
        /// An array of featureReport items which represent individual feature reports described in this collection.
        /// </summary>
        public HIDReportInfo[] FeatureReports => JSRef!.Get<HIDReportInfo[]>("featureReports");
    }
}