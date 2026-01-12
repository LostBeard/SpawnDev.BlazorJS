using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects;

/// <summary>
/// The USBAlternateInterface interface of the WebUSB API provides information about a particular configuration of an interface provided by the USB device. An interface includes one or more alternate settings which can configure a set of endpoints based on the operating mode of the device.
/// https://developer.mozilla.org/en-US/docs/Web/API/USBAlternateInterface
/// </summary>
public class USBAlternateInterface : JSObject
{
    /// <inheritdoc />
    public USBAlternateInterface(IJSInProcessObjectReference _ref) : base(_ref)
    {
    }

    /// <summary>
    /// The alternate setting number of this interface. This is equal to the bAlternateSetting field of the interface descriptor defining this interface
    /// </summary>
    public int AlternateSetting => JSRef!.Get<int>("alternateSetting");

    /// <summary>
    /// The class of this interface. This is equal to the bInterfaceClass field of the interface descriptor defining this interface. Standardized values for this field are defined by the USB Implementers Forum. A value of 0xFF indicates a vendor-defined interface.
    /// </summary>
    public int InterfaceClass => JSRef!.Get<int>("interfaceClass");

    /// <summary>
    /// The subclass of this interface. This is equal to the bInterfaceSubClass field of the interface descriptor defining this interface. The meaning of this value depends on the interfaceClass field.
    /// </summary>
    public int InterfaceSubclass => JSRef!.Get<int>("interfaceSubclass");

    /// <summary>
    /// The protocol supported by this interface. This is equal to the bInterfaceProtocol field of the interface descriptor defining this interface. The meaning of this value depends on the interfaceClass and interfaceSubclass fields.
    /// </summary>
    public int InterfaceProtocol => JSRef!.Get<int>("interfaceProtocol");

    /// <summary>
    /// The name of the interface, if one is provided by the device. This is the value of the string descriptor with the index specified by the iInterface field of the interface descriptor defining this interface.
    /// </summary>
    public string? InterfaceName => JSRef!.Get<string?>("interfaceName");

    /// <summary>
    /// An array containing instances of the USBEndpoint interface describing each of the endpoints that are part of this interface.
    /// </summary>
    public Array<USBEndpoint> Endpoints => JSRef!.Get<Array<USBEndpoint>>("endpoints");
}