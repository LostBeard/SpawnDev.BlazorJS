using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBConfiguration interface of the WebUSB API provides information about a particular configuration of a USB device and the interfaces that it supports.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBConfiguration
    /// </summary>
    public class USBConfiguration : JSObject
    {
        /// <inheritdoc/>
        public USBConfiguration(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The USBConfiguration() constructor creates a new USBConfiguration object which contains information about the configuration on the provided USBDevice with the given configuration value.
        /// </summary>
        /// <param name="device">Specifies the USBDevice you want to configure.</param>
        /// <param name="configurationValue">Specifies the configuration descriptor you want to read. This is an unsigned integer in the range 0 to 255.</param>
        public USBConfiguration(USBDevice device, byte configurationValue) : base(JS.New(nameof(USBConfiguration), device, configurationValue)) { }

        #region Properties
        /// <summary>
        /// Returns the value of the configuration.
        /// </summary>
        public byte ConfigurationValue => JSRef!.Get<byte>("configurationValue");

        /// <summary>
        /// Returns the name of the configuration.
        /// </summary>
        public string ConfigurationName => JSRef!.Get<string>("configurationName");

        /// <summary>
        /// Returns an array of USBInterface objects representing the interfaces provided by the configuration.
        /// </summary>
        public USBInterface[] Interfaces => JSRef!.Get<USBInterface[]>("interfaces");
        #endregion
    }
}
