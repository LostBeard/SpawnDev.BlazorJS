# DOMParser

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/DOMParser.cs`  

> The DOMParser interface provides the ability to parse XML or HTML source code from a string into a DOM Document. You can perform the opposite operation—converting a DOM tree into XML or HTML source—using the XMLSerializer interface. In the case of an HTML document, you can also replace portions of the DOM with new DOM trees built from HTML by setting the value of the Element.innerHTML and outerHTML properties.These properties can also be read to fetch HTML fragments corresponding to the corresponding DOM subtree. Note that XMLHttpRequest can parse XML and HTML directly from a URL-addressable resource, returning a Document in its response property. https://developer.mozilla.org/en-US/docs/Web/API/DOMParser

## Constructors

| Signature | Description |
|---|---|
| `DOMParser()` | The DOMParser() constructor creates a new DOMParser object. This object can be used to parse the text of a document using the parseFromString() method. |
| `DOMParser(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ParseFromString(string input, string mimeType)` | `Document` | The parseFromString() method of the DOMParser interface parses an input containing either HTML or XML, returning a Document with the type given in the contentType property. |
| `ParseFromString(TrustedHTML input, string mimeType)` | `Document` | The parseFromString() method of the DOMParser interface parses an input containing either HTML or XML, returning a Document with the type given in the contentType property. This overload takes a TrustedHTML produced by a Trusted Type policy. parseFromString is a Trusted Types injection sink: on a page whose CSP enforces `require-trusted-types-for 'script'` (e.g. YouTube, Gmail) the string overload throws `TypeError: This document requires 'TrustedHTML'`, so code that may run on such a page must pass a TrustedHTML instead. |
