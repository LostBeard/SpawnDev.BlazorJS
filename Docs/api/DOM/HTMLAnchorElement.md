# HTMLAnchorElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLAnchorElement.cs`  
**MDN Reference:** [HTMLAnchorElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLAnchorElement)

> The HTMLAnchorElement interface represents hyperlink elements and provides special properties and methods (beyond those of the regular HTMLElement object interface that they inherit from) for manipulating the layout and presentation of such elements. This interface corresponds to a element; not to be confused with link, which is represented by HTMLLinkElement) https://developer.mozilla.org/en-US/docs/Web/API/HTMLAnchorElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLAnchorElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLAnchorElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Download` | `string` | get | A string indicating that the linked resource is intended to be downloaded rather than displayed in the browser. The value represent the proposed name of the file. If the name is not a valid filename of the underlying OS, browser will adapt it. |
| `Hash` | `string` | get | A string representing the fragment identifier, including the leading hash mark ('#'), if any, in the referenced URL. |
| `Host` | `string` | get/set | A string representing the hostname and port (if it's not the default port) in the referenced URL. |
| `Hostname` | `string` | get | A string representing the hostname in the referenced URL. |
| `Href` | `string` | get | A string that is the result of parsing the href HTML attribute relative to the document, containing a valid URL of a linked resource. |
| `Hreflang` | `string` | get | A string that reflects the hreflang HTML attribute, indicating the language of the linked resource. |
| `Origin` | `string` | get | Returns a string containing the origin of the URL, that is its scheme, its domain and its port. |
| `Password` | `string` | get | A string containing the password specified before the domain name. |
| `Pathname` | `string` | get | A string containing an initial '/' followed by the path of the URL, not including the query string or fragment. |
| `Ping` | `string` | get | A space-separated list of URLs. When the link is followed, the browser will send POST requests with the body PING to the URLs. |
| `Port` | `string` | get | A string representing the port component, if any, of the referenced URL. |
| `Protocol` | `string` | get | A string representing the protocol component, including trailing colon (':'), of the referenced URL. |
| `ReferrerPolicy` | `string` | get | A string that reflects the referrerpolicy HTML attribute indicating which referrer to use. |
| `Rel` | `string` | get | A string that reflects the rel HTML attribute, specifying the relationship of the target object to the linked object. |
| `RelList` | `DOMTokenList` | get | Returns a DOMTokenList that reflects the rel HTML attribute, as a list of tokens. |
| `Search` | `string` | get | A string representing the search element, including leading question mark ('?'), if any, of the referenced URL. |
| `Target` | `string` | get/set | A string that reflects the target HTML attribute, indicating where to display the linked resource. |
| `Text` | `string` | get | A string being a synonym for the Node.textContent property. |
| `Type` | `string` | get | A string that reflects the type HTML attribute, indicating the MIME type of the linked resource. |
| `Username` | `string` | get | A string containing the username specified before the domain name. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToString()` | `string` | Returns a string containing the whole URL. It is a synonym for HTMLAnchorElement.href, though it can't be used to modify the value. |

