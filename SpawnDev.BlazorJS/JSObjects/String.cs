﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The String object is used to represent and manipulate a sequence of characters.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String
    /// </summary>
    public class String : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public String(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The String() constructor creates String objects.
        /// </summary>
        /// <param name="thing">Anything to be converted to a string.</param>
        public String(object thing) : base(JS.New(nameof(String), thing)) { }
        /// <summary>
        /// Returns the primitive value of the specified object. Overrides the Object.prototype.valueOf() method.
        /// </summary>
        /// <returns></returns>
        public string ValueOf() => JSRef!.Call<string>("valueOf");
        /// <summary>
        /// Implicit conversion to .Net string
        /// </summary>
        /// <param name="strObj"></param>
        public static implicit operator string(String strObj) => strObj.ValueOf();
    }
}
