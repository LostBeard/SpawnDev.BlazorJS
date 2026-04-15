# HIDReportItem

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/HIDReportItem.cs`  

> A HIDReportItem represents one field within a HID report. https://wicg.github.io/webhid/#hidreportitem-dictionary

## Constructors

| Signature | Description |
|---|---|
| `HIDReportItem(IJSInProcessObjectReference _ref)` | Creates a new instance of `HIDReportItem`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IsAbsolute` | `bool` | get | true if the data is absolute (based on a fixed origin), or false if the data is relative (indicating the change in value from the last report). |
| `IsArray` | `bool` | get | true if the item creates array data fields in reports where each data field contains an index corresponding to a pressed button or key, or false if the item creates variable data fields in reports where each data field contains a value. |
| `IsBufferedBytes` | `bool` | get | true if the item emits a fixed-sized stream of bytes, or false if the item is a numeric quantity. |
| `IsConstant` | `bool` | get | true if the item is a static read-only field and cannot be modified, or false if the item defines report fields that contain modifiable device data. |
| `IsLinear` | `bool` | get | true if the item represents a linear relationship between what is measured and what is reported, or false if the data has been processed in some way. |
| `IsRange` | `bool` | get | true if the item assigns usages from a HID usage range defined by usageMinimum and usageMaximum, or false if the item has a sequence of HID usage values in usages. |
| `IsVolatile` | `bool` | get | true if the item value can change without host interaction, or false if the item value should only be changed by the host. Only used for Feature and Output items. |
| `HasNull` | `bool` | get | true if the item has a null state in which it is not sending meaningful data, or false if it does not have a null state. When in a null state, the item will report a value outside of the specified logicalMinimum and logicalMaximum. |
| `HasPreferredState` | `bool` | get | true if the item has a preferred state to which it will return when the user is not physically interacting with the control, or false if the item does not have a preferred state. |
| `Wrap` | `bool` | get | true if the item value rolls over when reaching either the extreme high or low value, or false if the item value does not roll over. |
| `Usages` | `IEnumerable<uint>` | get | If isRange is true or this item has no associated HID usage values, then usages MUST be undefined. If isRange is false then usages is a sequence of HID usage values associated with this item. |
| `UsageMinimum` | `uint` | get | If isRange is true then usageMinimum contains the minimum HID usage value in the usage range associated with this item. If isRange is false then usageMinimum MUST be undefined. |
| `UsageMaximum` | `uint` | get | If isRange is true then usageMaximum contains the maximum HID usage value in the usage range associated with this item. If isRange is false then usageMaximum MUST be undefined. |
| `ReportSize` | `ushort` | get | The size of each report data field in bits. The reportSize MUST be greater than 0. |
| `ReportCount` | `ushort` | get | The number of fields included in the report for this item. The reportCount MUST be greater than 0. |
| `UnitExponent` | `byte` | get | The value of the unit exponent, or 0 if the item has no unit definition. |
| `UnitSystem` | `string` | get | A string value specifying the unit system for the unit definition. This property will have one of the following string values: "none" No unit system. Indicates that the item does not have a unit definition. "si-linear" The SI Linear unit system uses centimeter, gram, second, Kelvin, Ampere, Candela. "si-rotation" The SI Rotation unit system uses radian, gram, second, Kelvin, Ampere, Candela. "english-linear" The English Linear unit system uses inch, slug, second, degree Fahrenheit, Ampere, Candela. "english-rotation" The English Rotation unit system uses degree, slug, second, degree Fahrenheit, Ampere, Candela. "vendor-defined" A vendor-defined unit system. "reserved" Indicates that the device used a reserved value for its unit system. |
| `UnitFactorLengthExponent` | `byte` | get | The value of the exponent for the length unit (centimeters, radians, inch, or degrees) in the unit definition, or 0 if the item has no unit definition. |
| `UnitFactorMassExponent` | `byte` | get | The value of the exponent for the mass unit (gram or slug) in the unit definition, or 0 if the item has no unit definition. |
| `UnitFactorTimeExponent` | `byte` | get | The value of the exponent for the time unit (seconds) in the unit definition, or 0 if the item has no unit definition. |
| `UnitFactorTemperatureExponent` | `byte` | get | The value of the exponent for the temperature unit (Kelvin or degrees Fahrenheit) in the unit definition, or 0 if the item has no unit definition. |
| `UnitFactorCurrentExponent` | `byte` | get | The value of the exponent for the electrical current unit (Ampere) in the unit definition, or 0 if the item has no unit definition. |
| `UnitFactorLuminousIntensityExponent` | `byte` | get | The value of the exponent for the luminous intensity unit (Candela) in the unit definition, or 0 if the item has no unit definition. |
| `LogicalMinimum` | `long` | get | The minimum extent of this item in logical units. This is the minimum value that a variable or array item will report. |
| `LogicalMaximum` | `long` | get | The maximum extent of this item in logical units. This is the maximum value that a variable or array item wll report. |
| `PhysicalMinimum` | `long` | get | The minimum value for the physical extent of this item. This represents the logicalMinimum with units applied to it. |
| `PhysicalMaximum` | `long` | get | The maximum value for the physical extent of this item. This represents the logicalMaximum with units applied to it. |
| `Strings` | `IEnumerable<string>` | get | The strings associated with this item, or an empty sequence if no strings are associated with this item. |

