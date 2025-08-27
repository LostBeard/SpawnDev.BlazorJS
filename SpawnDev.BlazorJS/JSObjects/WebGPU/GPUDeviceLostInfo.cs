namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUDeviceLostInfo interface of the WebGPU API represents the object returned when the GPUDevice.lost Promise resolves. This provides information as to why a device has been lost.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDeviceLostInfo
    /// </summary>
    public class GPUDeviceLostInfo
    {
        /// <summary>
        /// A string providing a human-readable message that explains why the device was lost.
        /// </summary>
        public string Message { get; init; }
        /// <summary>
        /// An enumerated value that defines the reason the device was lost in a machine-readable way.
        /// </summary>
        public string Reason { get; init; }
    }
}
