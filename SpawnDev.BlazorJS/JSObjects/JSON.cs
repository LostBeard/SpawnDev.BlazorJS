namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The JSON namespace object contains static methods for parsing values from and converting values to JavaScript Object Notation (JSON).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/JSON
    /// </summary>
    public static class JSON
    {
        private static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// Return a JSON string corresponding to the specified value, optionally including only certain properties or replacing property values in a user-defined manner.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Stringify(object value) => JS.Call<string>("JSON.stringify", value);
        /// <summary>
        /// Parse a piece of string text as JSON, optionally transforming the produced value and its properties, and return the value.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static JSObject? Parse(string text) => JS.Call<JSObject?>("JSON.parse", text);
        /// <summary>
        /// Parse a piece of string text as JSON, optionally transforming the produced value and its properties, and return the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static T Parse<T>(string text) => JS.Call<T>("JSON.parse", text);
    }
}
