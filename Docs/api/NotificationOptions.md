# NotificationDirection

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/NotificationOptions.cs`  

> Notification direction

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Auto` | `"auto"` | Auto |
| `LeftToRight` | `"ltr"` | Left to right |
| `RightToLeft` | `"rtl"` | Right to left |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `NotificationDirection` | `enum` | get | Notification direction |
| `NotificationOptions` | `class` | get | Notification creation options https://developer.mozilla.org/en-US/docs/Web/API/Notification/Notification#options https://www.w3.org/TR/2015/REC-notifications-20151022/#api |
| `Lang` | `string?` | get |  |
| `Badge` | `string?` | get |  |
| `Body` | `string?` | get |  |
| `Tag` | `string?` | get |  |
| `Icon` | `string?` | get |  |
| `Image` | `string?` | get |  |
| `Data` | `object?` | get |  |
| `Vibrate` | `string?` | get |  |
| `Remotify` | `bool?` | get |  |
| `RequireInteraction` | `bool?` | get |  |
| `Actions` | `List<NotificationAction>?` | get |  |
| `Silent` | `bool?` | get |  |
| `Timestamp` | `EpochDateTime?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<NotificationOptions>(...)` or constructor `new NotificationOptions(...)`

```js
if (Notification.permission === "granted") {
  const notification = new Notification("Hi there!");
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Notification/Notification)*

