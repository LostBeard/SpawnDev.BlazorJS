using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CookieStoreManager/unsubscribe#subscriptions
    /// </summary>
    public class CookieSubscription
    {
        /// <summary>
        /// A string with the name of a cookie.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }
        /// <summary>
        /// A string with the url of the scope used to subscribe to this cookie.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
