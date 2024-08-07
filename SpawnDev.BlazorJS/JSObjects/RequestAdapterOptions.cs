﻿namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for GPU.RequestAdapter
    /// </summary>
    public class RequestAdapterOptions
    {
        /// <summary>
        /// An enumerated value that can be used to provide a hint to the user agent indicating what class of adapter should be chosen from the system's available adapters. Available values are:<br/>
        /// undefined (or not specified), which provides no hint.<br/>
        /// "low-power", which provides a hint to prioritize power savings over performance. If your app runs OK with this setting, it is recommended to use it, as it can significantly improve battery life on portable devices. This is usually the default if no options are provided.<br/>
        /// "high-performance", which provides a hint to prioritize performance over power consumption. You are encouraged to only specify this value if absolutely necessary, since it may significantly decrease battery life on portable devices. It may also result in increased GPUDevice loss — the system will sometimes elect to switch to a lower-power adapter to save power.
        /// </summary>
        public string? PowerPreference { get; set; }
    }
}
