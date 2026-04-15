# PaymentRequestEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/PaymentRequestEvent.cs`  
**MDN Reference:** [PaymentRequestEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent)

> The PaymentRequestEvent interface of the Payment Handler API is the object passed to a payment handler when a PaymentRequest is made. https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MethodData` | `PaymentMethodData[]` | get | Returns an array of objects containing payment method identifiers for the payment methods that the website accepts and any associated payment method specific data. |
| `Modifiers` | `PaymentModifier[]` | get | Returns an array of objects containing changes to payment details. |
| `PaymentRequestId` | `string` | get | Returns the ID of the PaymentRequest object. |
| `PaymentRequestOrigin` | `string` | get | Returns the origin where the PaymentRequest object was initialized. |
| `TopOrigin` | `string` | get | Returns the top-level origin where the PaymentRequest object was initialized. |
| `Total` | `PaymentCurrencyAmount` | get | Returns the total amount being requested for payment. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PaymentRequestEvent>(...)` or constructor `new PaymentRequestEvent(...)`

```js
let paymentRequestEvent;
let resolver;
let client;

// `self` is the global object in service worker
self.addEventListener("paymentrequest", async (e) => {
  if (paymentRequestEvent) {
    // If there's an ongoing payment transaction, reject it.
    resolver.reject();
  }
  // Preserve the event for future use
  paymentRequestEvent = e;

  // …
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent)*

