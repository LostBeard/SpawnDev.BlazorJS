# Worker

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`, `IMessagePort`  
**Source:** `JSObjects/Worker.cs`  
**MDN Reference:** [Worker on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Worker)

> The Worker interface of the Web Workers API represents a background task that can be created via script, which can send messages back to its creator. https://developer.mozilla.org/en-US/docs/Web/API/Worker

## Constructors

| Signature | Description |
|---|---|
| `Worker(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Worker(string url)` | Creates a dedicated web worker that executes the script at the specified URL. This also works for Blob URLs. A string representing the URL of the script the worker will execute. It must obey the same-origin policy. The URL is resolved relative to the current HTML page's location. |
| `Worker(string url, WorkerOptions options)` | Creates a dedicated web worker that executes the script at the specified URL. This also works for Blob URLs. A string representing the URL of the script the worker will execute. It must obey the same-origin policy. The URL is resolved relative to the current HTML page's location. An object containing option properties that can be set when creating the Worker instance. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Terminate()` | `void` | Immediately terminates the worker. This does not let worker finish its operations; it is halted at once. ServiceWorker instances do not support this method. |
| `PostMessage(object message)` | `void` | Sends a message - consisting of any JavaScript object - to the worker's inner scope. |
| `PostMessage(object message, object[] transfer)` | `void` | Sends a message - consisting of any JavaScript object - to the worker's inner scope. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnError` | `ActionEvent<Event>` | Fires when an error occurs in the worker. |
| `OnMessage` | `ActionEvent<MessageEvent>` | Fires when the worker's parent receives a message from that worker. |
| `OnMessageError` | `ActionEvent<MessageEvent>` | Fires when a Worker object receives a message that can't be deserialized. |

## Example

```csharp
// Create a dedicated web worker from a script URL
using var worker = new Worker("/js/my-worker.js");

// Listen for messages from the worker
Action<MessageEvent> onMessage = (MessageEvent e) =>
{
    var result = e.DataAs<string>();
    Console.WriteLine($"Worker says: {result}");
    e.Dispose();
};
worker.OnMessage += onMessage;

// Listen for errors in the worker
Action<Event> onError = (Event e) =>
{
    Console.WriteLine("Worker error occurred");
    e.Dispose();
};
worker.OnError += onError;

// Send a message to the worker
worker.PostMessage("start processing");

// Send structured data
worker.PostMessage(new { action = "compute", value = 42 });

// Send a message with transferable objects (zero-copy transfer)
using var buffer = new ArrayBuffer(1024);
worker.PostMessage(
    new { type = "data", buffer = buffer },
    new object[] { buffer }
);

// Create a worker with options (e.g., module type)
using var moduleWorker = new Worker("/js/module-worker.js", new WorkerOptions
{
    Type = "module"
});

// Clean up event handlers
worker.OnMessage -= onMessage;
worker.OnError -= onError;

// Terminate the worker immediately
worker.Terminate();
```

