﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLSlotElement interface of the Shadow DOM API enables access to the name and assigned nodes of an HTML slot element.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLSlotElement<br />
    /// </summary>
    public class HTMLSlotElement : HTMLElement
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLSlotElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLSlotElement(ElementReference elementReference) : base(elementReference) { }
        #endregion
        /// <summary>
        /// A string used to get and set the slot's name.
        /// </summary>
        public string Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }
    }
}
