# Storage

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Storage.cs`  
**MDN Reference:** [Storage on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Storage)

> The Storage interface of the Web Storage API provides access to a particular domain's session or local storage. It allows, for example, the addition, modification, or deletion of stored data items. https://developer.mozilla.org/en-US/docs/Web/API/Storage

## Constructors

| Signature | Description |
|---|---|
| `Storage(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns an integer representing the number of data items stored in the Storage object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Key(int index)` | `string?` | When passed a number n, this method will return the name of the nth key in the storage. |
| `SetItem(string key, string value)` | `void` | When passed a key name and value, will add that key to the storage, or update that key's value if it already exists. |
| `GetItemKeys()` | `List<string>` | Returns keys using Object.keys |
| `GetItem(string key)` | `string?` | When passed a key name, will return that key's value. |
| `ItemExists(string key)` | `bool` | Tests for a key's existence using hasOwnProperty |
| `RemoveItem(string key)` | `void` | When passed a key name, will remove that key from the storage. |
| `Clear()` | `void` | When invoked, will empty all keys out of the storage. |
| `GetJSON(string key)` | `T` | JSON getter |
| `SetJSON(string key, T value)` | `void` | JSON setter |

## Example

```csharp
// Get localStorage from the window global
using var localStorage = JS.Get<Storage>("localStorage");

// Store string values
localStorage.SetItem("username", "TJ");
localStorage.SetItem("theme", "dark");

// Retrieve values
var username = localStorage.GetItem("username");
Console.WriteLine($"Username: {username}"); // "TJ"

// Check if a key exists
if (localStorage.ItemExists("theme"))
{
    Console.WriteLine($"Theme: {localStorage.GetItem("theme")}");
}

// Store and retrieve complex objects as JSON
var settings = new { FontSize = 14, Language = "en" };
localStorage.SetJSON("settings", settings);
var loaded = localStorage.GetJSON<Dictionary<string, object>>("settings");

// Get the number of stored items
Console.WriteLine($"Items stored: {localStorage.Length}");

// Iterate through all keys
for (int i = 0; i < localStorage.Length; i++)
{
    var key = localStorage.Key(i);
    var value = localStorage.GetItem(key!);
    Console.WriteLine($"  {key} = {value}");
}

// Get all keys at once
var allKeys = localStorage.GetItemKeys();

// Remove a specific item
localStorage.RemoveItem("theme");

// Clear all items
localStorage.Clear();

// sessionStorage works the same way
using var sessionStorage = JS.Get<Storage>("sessionStorage");
sessionStorage.SetItem("tempData", "session-only");
```

