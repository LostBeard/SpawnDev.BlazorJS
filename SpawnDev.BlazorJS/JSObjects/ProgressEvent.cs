using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The progress event is fired periodically as the FileReader reads data.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileReader/progress_event
    /// </summary>
    public class ProgressEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ProgressEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A 64-bit unsigned integer value indicating the amount of work already performed by the underlying process. The ratio of work done can be calculated by dividing total by the value of this property. When downloading a resource using HTTP, this only counts the body of the HTTP message, and doesn't include headers and other overhead.
        /// </summary>
        public ulong? Loaded => JSRef!.Get<ulong?>("loaded");
        /// <summary>
        /// A 64-bit unsigned integer representing the total amount of work that the underlying process is in the progress of performing. When downloading a resource using HTTP, this is the Content-Length (the size of the body of the message), and doesn't include the headers and other overhead.
        /// </summary>
        public ulong? Total => JSRef!.Get<ulong?>("total");
        /// <summary>
        /// A boolean flag indicating if the total work to be done, and the amount of work already done, by the underlying process is calculable. In other words, it tells if the progress is measurable or not.
        /// </summary>
        public bool? LengthComputable => JSRef!.Get<bool?>("lengthComputable");
    }
    public class ProgressEvent<TTarget> : Event<TTarget> where TTarget : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ProgressEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A 64-bit unsigned integer value indicating the amount of work already performed by the underlying process. The ratio of work done can be calculated by dividing total by the value of this property. When downloading a resource using HTTP, this only counts the body of the HTTP message, and doesn't include headers and other overhead.
        /// </summary>
        public ulong? Loaded => JSRef!.Get<ulong?>("loaded");
        /// <summary>
        /// A 64-bit unsigned integer representing the total amount of work that the underlying process is in the progress of performing. When downloading a resource using HTTP, this is the Content-Length (the size of the body of the message), and doesn't include the headers and other overhead.
        /// </summary>
        public ulong? Total => JSRef!.Get<ulong?>("total");
        /// <summary>
        /// A boolean flag indicating if the total work to be done, and the amount of work already done, by the underlying process is calculable. In other words, it tells if the progress is measurable or not.
        /// </summary>
        public bool? LengthComputable => JSRef!.Get<bool?>("lengthComputable");
    }
}
