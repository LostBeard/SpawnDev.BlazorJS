# FluentUsing

**Namespace:** `SpawnDev.BlazorJS`  
**Type:** Static extension methods class  
**Source:** `SpawnDev.BlazorJS/FluentUsing.cs`

> FluentUsing provides LINQ-style extension methods for IDisposable objects, arrays, and lists. These methods allow you to use disposable objects in functional chains where a `using` statement would be awkward - the objects are automatically disposed after the lambda executes. This is especially useful when working with JSObject arrays from query methods like QuerySelectorAll.

## IDisposable Extensions

| Method | Return Type | Description |
|---|---|---|
| `Using<T>(Action<T> use)` | `void` | Use the disposable, then dispose it. |
| `Using<T, TResult>(Func<T, TResult> use)` | `TResult` | Use the disposable, return a result, then dispose it. |
| `UsingAsync<T, TResult>(Func<T, Task> use)` | `Task` | Async use, then dispose. |
| `UsingAsync<T, TResult>(Func<T, Task<TResult>> use)` | `Task<TResult>` | Async use with result, then dispose. |

## Array Extensions (T[])

| Method | Return Type | Description |
|---|---|---|
| `Using<T>()` | `void` | Dispose all items in the array. |
| `Using<T>(Action<T[]> use)` | `void` | Use the array, then dispose all items. |
| `Using<T, TResult>(Func<T[], TResult> use)` | `TResult` | Use the array, return a result, then dispose all items. |
| `UsingEach<T>(Action<T> use)` | `void` | Iterate each item, then dispose all. |
| `UsingEachAsync<T>(Func<T, Task> use)` | `Task` | Async iterate each item, then dispose all. |
| `UsingWhere<T>(Func<T, bool> use)` | `List<T>` | Filter items - kept items are NOT disposed, rejected items ARE disposed. |
| `UsingWhereAsync<T>(Func<T, Task<bool>> use)` | `Task<List<T>>` | Async filter with selective disposal. |
| `UsingFirstOrDefault<T>(Func<T, bool> use)` | `T?` | Return first match, dispose all others. |
| `UsingFirstOrDefaultAsync<T>(Func<T, Task<bool>> use)` | `Task<T?>` | Async first match, dispose all others. |
| `UsingFirst<T>(Func<T, bool> use)` | `T?` | Return first match, dispose all others. Throws if no match. |
| `UsingFirstAsync<T>(Func<T, Task<bool>> use)` | `Task<T?>` | Async first match. Throws if no match. |
| `UsingCount<T, TResult>(Func<T, bool> use)` | `long` | Count matches, dispose all items. |
| `UsingAsync<T>(Func<T[], Task> use)` | `Task` | Async use array, dispose all. |
| `UsingAsync<T, TResult>(Func<T[], Task<TResult>> use)` | `Task<TResult>` | Async use array with result, dispose all. |
| `DisposeAll()` | `void` | Dispose all IDisposable items in the array. |

## List Extensions (List&lt;T&gt;)

Same methods as Array extensions, but operating on `List<T>`.

## Example - Single Object

```csharp
// Use and dispose in one expression
var title = JS.Get<Document>("document").Using(doc => doc.Title);
// doc is disposed after the lambda returns

// Async variant
var html = await JS.CallAsync<Response>("fetch", "/page").UsingAsync(async response =>
{
    return await response.Text();
});
// response is disposed after text is extracted
```

## Example - Array of JSObjects

```csharp
// QuerySelectorAll returns disposable elements
// UsingEach processes each and disposes all when done
document.QuerySelectorAll("div.item").Using().UsingEach(el =>
{
    Console.WriteLine(el.InnerHTML);
});
// All elements are disposed

// Filter - keep only visible elements, dispose the rest
var visible = document.QuerySelectorAll("div")
    .Using()
    .UsingWhere(el => el.CheckVisibility());
// visible list contains only visible elements (NOT disposed)
// non-visible elements are already disposed

// Find first match - disposes all others
var target = document.QuerySelectorAll("button")
    .Using()
    .UsingFirstOrDefault(btn => btn.GetAttribute("data-action") == "submit");
// target is the first submit button (if found), all others are disposed
```

## Example - Count Pattern

```csharp
long hiddenCount = document.QuerySelectorAll("*")
    .Using()
    .UsingCount<Element, bool>(el => !el.CheckVisibility());
// All elements disposed, hiddenCount has the result
```
