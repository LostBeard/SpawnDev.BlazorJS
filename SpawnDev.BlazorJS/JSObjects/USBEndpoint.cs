using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects;

/// <summary>
/// The USBEndpoint interface of the WebUSB API provides information about an endpoint provided by the USB device. An endpoint represents a unidirectional data stream into or out of a device.
/// https://developer.mozilla.org/en-US/docs/Web/API/USBEndpoint
/// </summary>
public class USBEndpoint : JSObject
{
    /// <inheritdoc />
    public USBEndpoint(IJSInProcessObjectReference _ref) : base(_ref)
    {
    }

    /// <summary>
    /// This endpoint's "endpoint number" which is a value from 1 to 15 extracted from the bEndpointAddress field of the endpoint descriptor defining this endpoint. This value is used to identify the endpoint when calling methods on USBDevice.
    /// </summary>
    public int EndpointNumber => JSRef!.Get<int>("endpointNumber");

    /// <summary>
    /// The direction in which this endpoint transfers data, one of:
    ///   - "in" - Data is transferred from device to host.
    ///   - "out" - Data is transferred from host to device.
    /// </summary>

    public string Direction => JSRef!.Get<string>("direction");

    /// <summary>
    /// The type of this endpoint, one of:
    ///   - "bulk" - Provides reliable data transfer for large payloads.Data sent through a bulk endpoint is guaranteed to be delivered or generate an error but may be preempted by other data traffic.
    ///   - "interrupt" - Provides reliable data transfer for small payloads. Data sent through an interrupt endpoint is guaranteed to be delivered or generate an error and is also given dedicated bus time for transmission.
    ///   - "isochronous" - Provides unreliable data transfer for payloads that must be delivered periodically. They are given dedicated bus time but if a deadline is missed the data is dropped.
    /// </summary>
    public string Type => JSRef!.Get<string>("type");

    /// <summary>
    /// The size of the packets that data sent through this endpoint will be divided into.
    /// </summary>
    public int PacketSize => JSRef!.Get<int>("packetSize");
}