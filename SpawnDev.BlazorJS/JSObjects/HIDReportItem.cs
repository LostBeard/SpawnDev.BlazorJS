using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A HIDReportItem represents one field within a HID report.
    /// https://wicg.github.io/webhid/#hidreportitem-dictionary
    /// </summary>
    public class HIDReportItem : JSObject
    {
        public HIDReportItem(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }

        /// <summary>
        /// true if the data is absolute (based on a fixed origin), or false if the data is relative
        /// (indicating the change in value from the last report).
        /// </summary>
        public bool IsAbsolute => JSRef!.Get<bool>("isAbsolute");

        /// <summary>
        /// true if the item creates array data fields in reports where each data field contains an index
        /// corresponding to a pressed button or key, or false if the item creates variable data fields
        /// in reports where each data field contains a value.
        /// </summary>
        public bool IsArray => JSRef!.Get<bool>("isArray");

        /// <summary>
        /// true if the item emits a fixed-sized stream of bytes, or false if the item is a numeric
        /// quantity.
        /// </summary>
        public bool IsBufferedBytes => JSRef!.Get<bool>("isBufferedBytes");

        /// <summary>
        /// true if the item is a static read-only field and cannot be modified, or false if the item
        /// defines report fields that contain modifiable device data.
        /// </summary>
        public bool IsConstant => JSRef!.Get<bool>("isConstant");

        /// <summary>
        /// true if the item represents a linear relationship between what is measured and what is
        /// reported, or false if the data has been processed in some way.
        /// </summary>
        public bool IsLinear => JSRef!.Get<bool>("isLinear");

        /// <summary>
        /// true if the item assigns usages from a HID usage range defined by usageMinimum and
        /// usageMaximum, or false if the item has a sequence of HID usage values in usages.
        /// </summary>
        public bool IsRange => JSRef!.Get<bool>("isRange");

        /// <summary>
        /// true if the item value can change without host interaction, or false if the item value
        /// should only be changed by the host. Only used for Feature and Output items.
        /// </summary>
        public bool IsVolatile => JSRef!.Get<bool>("isVolatile");

        /// <summary>
        /// true if the item has a null state in which it is not sending meaningful data, or false if
        /// it does not have a null state. When in a null state, the item will report a value outside
        /// of the specified logicalMinimum and logicalMaximum.
        /// </summary>
        public bool HasNull => JSRef!.Get<bool>("hasNull");

        /// <summary>
        /// true if the item has a preferred state to which it will return when the user is not
        /// physically interacting with the control, or false if the item does not have a preferred
        /// state.
        /// </summary>
        public bool HasPreferredState => JSRef!.Get<bool>("hasPreferredState");

        /// <summary>
        /// true if the item value rolls over when reaching either the extreme high or low value, or
        /// false if the item value does not roll over.
        /// </summary>
        public bool Wrap => JSRef!.Get<bool>("wrap");

        /// <summary>
        /// If isRange is true or this item has no associated HID usage values, then usages MUST be
        /// undefined. If isRange is false then usages is a sequence of HID usage values associated
        /// with this item.
        /// </summary>
        public IEnumerable<uint> Usages => JSRef!.Get<IEnumerable<uint>>("usages");

        /// <summary>
        /// If isRange is true then usageMinimum contains the minimum HID usage value in the usage range
        /// associated with this item. If isRange is false then usageMinimum MUST be undefined.
        /// </summary>
        public uint UsageMinimum => JSRef!.Get<uint>("usageMinimum");

        /// <summary>
        /// If isRange is true then usageMaximum contains the maximum HID usage value in the usage range
        /// associated with this item. If isRange is false then usageMaximum MUST be undefined.
        /// </summary>
        public uint UsageMaximum => JSRef!.Get<uint>("usageMaximum");

        /// <summary>
        /// The size of each report data field in bits. The reportSize MUST be greater than 0.
        /// </summary>
        public ushort ReportSize => JSRef!.Get<ushort>("reportSize");

        /// <summary>
        /// The number of fields included in the report for this item. The reportCount MUST be greater
        /// than 0.
        /// </summary>
        public ushort ReportCount => JSRef!.Get<ushort>("reportCount");

        /// <summary>
        /// The value of the unit exponent, or 0 if the item has no unit definition.
        /// </summary>
        public byte UnitExponent => JSRef!.Get<byte>("unitExponent");

        /// <summary>
        /// A string value specifying the unit system for the unit definition.
        /// This property will have one of the following string values:
        /// <list type="bullet">
        ///     <item>
        ///         <term>"none"</term>
        ///         <description>No unit system. Indicates that the item does not have a unit definition.</description>
        ///     </item>
        ///     <item>
        ///         <term>"si-linear"</term>
        ///         <description>The SI Linear unit system uses centimeter, gram, second, Kelvin, Ampere, Candela.</description>
        ///     </item>
        ///     <item>
        ///         <term>"si-rotation"</term>
        ///         <description>The SI Rotation unit system uses radian, gram, second, Kelvin, Ampere, Candela.</description>
        ///     </item>
        ///     <item>
        ///         <term>"english-linear"</term>
        ///         <description>The English Linear unit system uses inch, slug, second, degree Fahrenheit, Ampere, Candela.</description>
        ///     </item>
        ///     <item>
        ///         <term>"english-rotation"</term>
        ///         <description>The English Rotation unit system uses degree, slug, second, degree Fahrenheit, Ampere, Candela.</description>
        ///     </item>
        ///     <item>
        ///         <term>"vendor-defined"</term>
        ///         <description>A vendor-defined unit system.</description>
        ///     </item>
        ///     <item>
        ///         <term>"reserved"</term>
        ///         <description>Indicates that the device used a reserved value for its unit system.</description>
        ///     </item>
        /// </list>
        /// </summary>
        public string UnitSystem => JSRef!.Get<string>("unitSystem");

        /// <summary>
        /// The value of the exponent for the length unit (centimeters, radians, inch, or degrees) in
        /// the unit definition, or 0 if the item has no unit definition.
        /// </summary>
        public byte UnitFactorLengthExponent => JSRef!.Get<byte>("unitFactorLengthExponent");

        /// <summary>
        /// The value of the exponent for the mass unit (gram or slug) in the unit definition, or 0 if
        /// the item has no unit definition.
        /// </summary>
        public byte UnitFactorMassExponent => JSRef!.Get<byte>("unitFactorMassExponent");

        /// <summary>
        /// The value of the exponent for the time unit (seconds) in the unit definition, or 0 if the
        /// item has no unit definition.
        /// </summary>
        public byte UnitFactorTimeExponent => JSRef!.Get<byte>("unitFactorTimeExponent");

        /// <summary>
        /// The value of the exponent for the temperature unit (Kelvin or degrees Fahrenheit) in the
        /// unit definition, or 0 if the item has no unit definition.
        /// </summary>
        public byte UnitFactorTemperatureExponent => JSRef!.Get<byte>("unitFactorTemperatureExponent");

        /// <summary>
        /// The value of the exponent for the electrical current unit (Ampere) in the unit definition,
        /// or 0 if the item has no unit definition.
        /// </summary>
        public byte UnitFactorCurrentExponent => JSRef!.Get<byte>("unitFactorCurrentExponent");

        /// <summary>
        /// The value of the exponent for the luminous intensity unit (Candela) in the unit definition,
        /// or 0 if the item has no unit definition.
        /// </summary>
        public byte UnitFactorLuminousIntensityExponent => JSRef!.Get<byte>("unitFactorLuminousIntensityExponent");

        /// <summary>
        /// The minimum extent of this item in logical units. This is the minimum value that a variable
        /// or array item will report.
        /// </summary>
        public long LogicalMinimum => JSRef!.Get<long>("logicalMinimum");

        /// <summary>
        /// The maximum extent of this item in logical units. This is the maximum value that a variable
        /// or array item wll report.
        /// </summary>
        public long LogicalMaximum => JSRef!.Get<long>("logicalMaximum");

        /// <summary>
        /// The minimum value for the physical extent of this item. This represents the logicalMinimum
        /// with units applied to it.
        /// </summary>
        public long PhysicalMinimum => JSRef!.Get<long>("physicalMinimum");

        /// <summary>
        /// The maximum value for the physical extent of this item. This represents the logicalMaximum
        /// with units applied to it.
        /// </summary>
        public long PhysicalMaximum => JSRef!.Get<long>("physicalMaximum");

        /// <summary>
        /// The strings associated with this item, or an empty sequence if no strings are associated
        /// with this item.
        /// </summary>
        public IEnumerable<string> Strings => JSRef!.Get<IEnumerable<string>>("strings");
    }
}