﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// All of the SVG DOM interfaces that correspond directly to elements in the SVG language derive from the SVGElement interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SVGElement
    /// </summary>
    public class SVGElement : Element
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SVGElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new SVGElement from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public SVGElement(ElementReference elementReference) : base(JS.ReturnMe<IJSInProcessObjectReference>(elementReference)) { }
    }
}
