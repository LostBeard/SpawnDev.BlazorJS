# CanMakePaymentEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/CanMakePaymentEvent.cs`  
**MDN Reference:** [CanMakePaymentEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CanMakePaymentEvent)

> The canmakepayment event of the ServiceWorkerGlobalScope interface is fired on a payment app's service worker to check whether it is ready to handle a payment. Specifically, it is fired when the merchant website calls the PaymentRequest() constructor. https://developer.mozilla.org/en-US/docs/Web/API/CanMakePaymentEvent

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RespondWith(Task<bool> response)` | `void` | Enables the service worker to respond appropriately to signal whether it is ready to handle payments. |
| `RespondWith(Promise<bool> response)` | `void` | Enables the service worker to respond appropriately to signal whether it is ready to handle payments. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CanMakePaymentEvent>(...)` or constructor `new CanMakePaymentEvent(...)`

```js
self.addEventListener("canmakepayment", (e) => {
  e.respondWith(
    new Promise((resolve, reject) => {
      someAppSpecificLogic()
        .then((result) => {
          resolve(result);
        })
        .catch((error) => {
          reject(error);
        });
    }),
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CanMakePaymentEvent)*

