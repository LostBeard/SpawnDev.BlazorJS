﻿using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Create buffer descriptor<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createBuffer#descriptor
    /// </summary>
    public class GPUBufferDescriptor
    {
        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
        /// <summary>
        /// A boolean. If set to true, the buffer will be mapped upon creation, meaning that you can set the values inside the buffer immediately by calling GPUBuffer.getMappedRange(). The default value is false.<br/>
        /// Note that it is valid to set mappedAtCreation: true so you can set the buffer's initial data, even if the GPUBufferUsage.MAP_READ or GPUBufferUsage.MAP_WRITE usage flags are not set.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MappedAtCreation { get; set; }
        /// <summary>
        /// A number representing the size of the buffer, in bytes.
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// The bitwise flags representing the allowed usages for the GPUBuffer. The possible values are in the GPUBuffer.usage value table.
        /// </summary>
        public GPUBufferUsage Usage { get; set; }
    }
}
