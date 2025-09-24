using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp
    /// </summary>
    public class RegExp : JSObject
    {
        /// <inheritdoc/>
        public RegExp(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The RegExp() constructor creates RegExp objects.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="flags"></param>
        public RegExp(string pattern, string? flags = null) : base(flags == null ? JS.New(nameof(RegExp), pattern) : JS.New(nameof(RegExp), pattern, flags)) { }

        // TODO
    }
}
