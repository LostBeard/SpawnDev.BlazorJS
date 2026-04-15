# HTMLImageElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLImageElement.cs`  
**MDN Reference:** [HTMLImageElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLImageElement)

> The HTMLImageElement interface represents an HTML &lt;img&gt; element, providing the properties and methods used to manipulate image elements. https://developer.mozilla.org/en-US/docs/Web/API/HTMLImageElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLImageElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLImageElement(ElementReference elementReference)` | Get an instance from an ElementReference |
| `HTMLImageElement()` | The Image() constructor creates and returns a new HTMLImageElement object representing an HTML &lt;img&gt; element which is not attached to any DOM tree. It accepts optional width and height parameters. When called without parameters, new Image() is equivalent to calling document.createElement('img'). |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Alt` | `string` | get | A string that reflects the alt HTML attribute, thus indicating the alternate fallback content to be displayed if the image has not been loaded. |
| `Complete` | `bool` | get | Returns a boolean value that is true if the browser has finished fetching the image, whether successful or not. That means this value is also true if the image has no src value indicating an image to load. |
| `CrossOrigin` | `string?` | get | A string specifying the CORS setting for this image element. See CORS settings attributes for further details. This may be null if CORS is not used. |
| `CurrentSrc` | `string` | get | Returns a string representing the URL from which the currently displayed image was loaded. This may change as the image is adjusted due to changing conditions, as directed by any media queries which are in place. |
| `Decoding` | `string?` | get | An optional string representing a hint given to the browser on how it should decode the image. If this value is provided, it must be one of the possible permitted values: sync to decode the image synchronously, async to decode it asynchronously, or auto to indicate no preference (which is the default). Read the decoding page for details on the implications of this property's values. |
| `FetchPriority` | `string?` | get | An optional string representing a hint given to the browser on how it should prioritize fetching of the image relative to other images. If this value is provided, it must be one of the possible permitted values: high to fetch at a high priority, low to fetch at a low priority, or auto to indicate no preference (which is the default). |
| `Height` | `int` | get | An integer value that reflects the height HTML attribute, indicating the rendered height of the image in CSS pixels. |
| `IsMap` | `bool` | get | A boolean value that reflects the ismap HTML attribute, indicating that the image is part of a server-side image map. This is different from a client-side image map, specified using an &lt;image&gt; element and a corresponding &lt;map&gt; which contains &lt;area&gt; elements indicating the clickable areas in the image. The image must be contained within an &lt;a&gt; element; see the ismap page for details. |
| `Loading` | `string?` | get | A string providing a hint to the browser used to optimize loading the document by determining whether to load the image immediately (eager) or on an as-needed basis (lazy). |
| `NaturalHeight` | `int` | get | An integer value representing the intrinsic height of the image in CSS pixels, if it is available; else, it shows 0. This is the height the image would be if it were rendered at its natural full size. |
| `NaturalWidth` | `int` | get | An integer value representing the intrinsic width of the image in CSS pixels, if it is available; otherwise, it will show 0. This is the width the image would be if it were rendered at its natural full size. |
| `ReferrerPolicy` | `string?` | get | A string that reflects the referrerpolicy HTML attribute, which tells the user agent how to decide which referrer to use in order to fetch the image. Read this article for details on the possible values of this string. |
| `Sizes` | `string?` | get | A string reflecting the sizes HTML attribute. This string specifies a list of comma-separated conditional sizes for the image; that is, for a given viewport size, a particular image size is to be used. Read the documentation on the sizes page for details on the format of this string. |
| `Src` | `string` | get | A string that reflects the src HTML attribute, which contains the full URL of the image including base URI. You can load a different image into the element by changing the URL in the src attribute. |
| `SrcSet` | `string?` | get | A string reflecting the srcset HTML attribute. This specifies a list of candidate images, separated by commas (',', U+002C COMMA). Each candidate image is a URL followed by a space, followed by a specially-formatted string indicating the size of the image. The size may be specified either the width or a size multiple. Read the srcset page for specifics on the format of the size substring. |
| `UseMap` | `string?` | get | A string reflecting the usemap HTML attribute, containing the page-local URL of the map element describing the image map to use. The page-local URL is a pound (hash) symbol (#) followed by the ID of the map element, such as #my-map-element. The map in turn contains area elements indicating the clickable areas in the image. |
| `Width` | `int` | get | An integer value that reflects the width HTML attribute, indicating the rendered width of the image in CSS pixels. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Decode()` | `Task` | Returns a Promise that resolves when the image is decoded and it's safe to append the image to the DOM. This prevents rendering of the next frame from having to pause to decode the image, as would happen if an undecoded image were added to the DOM. |
| `CreateFromImageAsync(string src, string? crossOrigin)` | `Task<HTMLImageElement>` | Creates a new Image and returns it when it has completed loading src, or throws an exception if it fails |
| `CreateFromImage(string src, Action<HTMLImageElement?> callback, string? crossOrigin)` | `void` | Creates a new Image and calls the callback when it has completed loading src or fails |
| `ConvertToBlob(ConvertToBlobOptions? options)` | `Task<Blob>` | Returns the Image as a Blob May throw an exception if the image is "tainted" by CORS issues. Non-standard method. An object with the following properties: type and quality A Promise returning a Blob object representing the image. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<HTMLImageElement>(...)` or constructor `new HTMLImageElement(...)`

### Creating and inserting an image element

```js
const img1 = new Image(); // Image constructor
img1.src = "image1.png";
img1.alt = "alt";
document.body.appendChild(img1);

const img2 = document.createElement("img"); // Use DOM HTMLImageElement
img2.src = "image2.jpg";
img2.alt = "alt text";
document.body.appendChild(img2);

// using first image in the document
alert(document.images[0].src);
```

### Getting width and height

```js
const arrImages = [
  document.getElementById("image1"),
  document.getElementById("image2"),
  document.getElementById("image3"),
];

const objOutput = document.getElementById("output");
let strHtml = "<ul>";

for (let i = 0; i < arrImages.length; i++) {
  const img = arrImages[i];
  strHtml += `<li>image${i + 1}: height=${img.height}, width=${img.width}, style.height=${img.style.height}, style.width=${img.style.width}</li>`;
}

strHtml += "</ul>";

objOutput.innerHTML = strHtml;
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLImageElement)*

