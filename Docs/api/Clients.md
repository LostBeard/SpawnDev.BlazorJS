# Clients

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Clients.cs`  
**MDN Reference:** [Clients on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Clients)

> The Clients interface provides access to Client objects. Access it via self.clients within a service worker. https://developer.mozilla.org/en-US/docs/Web/API/Clients

## Constructors

| Signature | Description |
|---|---|
| `Clients(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Get(string id)` | `Task<Client>` | Returns a Promise for a Client matching a given id. |
| `MatchAll()` | `Task<Array<Client>>` | Returns a Promise for an array of Client objects. An options argument allows you to control the types of clients returned. |
| `MatchAll(ClientsMatchAllOptions options)` | `Task<Array<Client>>` | Returns a Promise for an array of Client objects. An options argument allows you to control the types of clients returned. |
| `OpenWindow(string url)` | `Task<WindowClient>` | The openWindow() method of the Clients interface creates a new top level browsing context and loads a given URL. If the calling script doesn't have permission to show popups, openWindow() will throw an InvalidAccessError. In Firefox, the method is allowed to show popups only when called as the result of a notification click event. In Chrome for Android, the method may instead open the URL in an existing browsing context provided by a standalone web app previously added to the user's home screen. As of recently, this also works on Chrome for Windows. |
| `Claim()` | `Task` | Allows an active service worker to set itself as the controller for all clients within its scope. Usually called in the service worker 'activate' event |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Clients>(...)` or constructor `new Clients(...)`

```js
addEventListener("notificationclick", (event) => {
  event.waitUntil(
    (async () => {
      const allClients = await clients.matchAll({
        includeUncontrolled: true,
      });

      let chatClient;

      // Let's see if we already have a chat window open:
      for (const client of allClients) {
        const url = new URL(client.url);

        if (url.pathname === "/chat/") {
          // Excellent, let's use it!
          client.focus();
          chatClient = client;
          break;
        }
      }

      // If we didn't find an existing chat window,
      // open a new one:
      chatClient ??= await clients.openWindow("/chat/");

      // Message the client:
      chatClient.postMessage("New chat messages!");
    })(),
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Clients)*

