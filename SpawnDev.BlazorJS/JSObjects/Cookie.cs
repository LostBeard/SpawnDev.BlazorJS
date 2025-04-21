using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Cookie
    /// </summary>
    public class Cookie
    {
        /// <summary>
        /// A string containing the domain of the cookie.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Domain { get; set; }
        /// <summary>
        /// A timestamp, given as Unix time in milliseconds, containing the expiration date of the cookie.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EpochDateTime? Expires { get; set; }
        /// <summary>
        /// A string containing the name of the cookie.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A boolean indicating whether the cookie is a partitioned cookie (true) or not (false). See Cookies Having Independent Partitioned State (CHIPS) for more information.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Partitioned { get; set; }
        /// <summary>
        /// A string containing the path of the cookie.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Path { get; set; }
        /// <summary>
        /// One of the following SameSite values: "strict", "lax", or "none".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SameSite { get; set; }
        /// <summary>
        /// A boolean value indicating whether the cookie is to be used in secure contexts only (true) or not (false).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Secure { get; set; }
        /// <summary>
        /// A string containing the value of the cookie.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value { get; set; }
    }
}
