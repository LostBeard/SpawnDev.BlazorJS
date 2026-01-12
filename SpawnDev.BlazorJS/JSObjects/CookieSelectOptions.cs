using System.ComponentModel.DataAnnotations;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CookieStore/delete#options
    /// </summary>
    public class CookieSelectOptions
    {
        /// <summary>
        /// A string with the name of a cookie.
        /// </summary>
        [Required]
        public string Name { get; set; } = default!;
        /// <summary>
        /// A string with the domain of a cookie. Defaults to null.
        /// </summary>
        public string? Domain { get; set; }
        /// <summary>
        /// A string containing a path. Defaults to /.
        /// </summary>
        public string? Path { get; set; }
        /// <summary>
        /// A boolean value that defaults to false. Setting it to true specifies that the cookie to delete will be a partitioned cookie. See Cookies Having Independent Partitioned State (CHIPS) for more information.
        /// </summary>
        public bool? Partitioned { get; set; }
    }
}
