﻿using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Can be used when creating a SharedArrayBuffer
    /// </summary>
    public class SharedArrayBufferOptions
    {
        /// <summary>
        /// The maximum size, in bytes, that the shared array buffer can be resized to.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? MaxByteLength { get; set; }
    }
}
