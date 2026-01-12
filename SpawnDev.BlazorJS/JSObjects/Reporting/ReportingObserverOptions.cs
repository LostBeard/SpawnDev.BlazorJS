using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options utilized when creating a new ReportingObserver.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver/ReportingObserver#options
    /// </summary>
    public class ReportingObserverOptions
    {
        /// <summary>
        /// An array of strings representing the types of reports to be collected by the observer. If not specified, all available report types will be collected.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? Types { get; set; }
        /// <summary>
        /// A boolean value that indicates whether reports generated before the observer was created should be included in the reports delivered to the observer. The default is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Buffered { get; set; }
    }
}
