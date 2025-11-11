using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Intl namespace object contains several constructors as well as functionality common to the internationalization constructors and other language sensitive functions.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl
    /// </summary>
    public class Intl : JSObject
    {
        #region Constructors
        /// <summary>
        /// Gets the global Intl instance
        /// </summary>
        public Intl() : base(JS.Get<IJSInProcessObjectReference>("Intl")) { }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Intl(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// Returns an array containing the canonical locale names. Duplicates will be omitted and elements will be validated as structurally valid language tags.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/getCanonicalLocales
        /// </summary>
        /// <param name="locales">A string or array of strings to get the canonical locale names for</param>
        /// <returns>An array containing the canonical locale names</returns>
        public string[] GetCanonicalLocales(Union<string, string[]> locales) => JSRef!.Call<string[]>("getCanonicalLocales", locales);

        /// <summary>
        /// Returns an array containing the supported values for a given key.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/supportedValuesOf
        /// </summary>
        /// <param name="key">A string key indicating the category of values to return. Possible values are: "calendar", "collation", "currency", "numberingSystem", "timeZone", "unit"</param>
        /// <returns>A sorted array of unique string values</returns>
        public string[] SupportedValuesOf(string key) => JSRef!.Call<string[]>("supportedValuesOf", key);
        #endregion
    }
}
