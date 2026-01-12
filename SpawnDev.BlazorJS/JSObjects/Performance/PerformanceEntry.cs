using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PerformanceEntry interface encapsulates a single performance metric that is part of the performance timeline. A performance entry can be directly created by making a performance mark or measure (for example by calling the mark() method) at an explicit point in an application. Performance entries are also created in indirect ways such as loading a resource (such as an image).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PerformanceEntry
    /// </summary>
    public class PerformanceEntry : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PerformanceEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string representing the name of a performance entry.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// A string representing the type of performance entry.
        /// </summary>
        public string EntryType => JSRef!.Get<string>("entryType");
        /// <summary>
        /// A double representing the starting time for the performance entry.
        /// </summary>
        public double StartTime => JSRef!.Get<double>("startTime");
        /// <summary>
        /// A double representing the duration of the performance entry.
        /// </summary>
        public double Duration => JSRef!.Get<double>("duration");
    }
}
