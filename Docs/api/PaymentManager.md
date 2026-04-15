# PaymentManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PaymentManager.cs`  
**MDN Reference:** [PaymentManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentManager)

> The PaymentManager interface of the Payment Handler API is used to manage various aspects of payment app functionality. It is accessed via the ServiceWorkerRegistration.paymentManager property. https://developer.mozilla.org/en-US/docs/Web/API/PaymentManager

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `UserHint` | `string` | get | Provides a hint for the browser to display along with the payment app's name and icon in the Payment Handler UI. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `EnableDelegations(IEnumerable<string> delegations)` | `Task` | Delegates responsibility for providing various parts of the required payment information to the payment app rather than collecting it from the browser (for example, via autofill). An array containing one or more enumerated values that specify the payment information you want to delegate to the payment app. Possible values can be: payerEmail - The payment app will provide the payer's email whenever it is needed. payerName - The payment app will provide the payer's name whenever it is needed. payerPhone - The payment app will provide the payer's phone number whenever it is needed. shippingAddress - The payment app will provide the shipping address whenever it is needed. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PaymentManager>(...)` or constructor `new PaymentManager(...)`

```js
navigator.serviceWorker.register("serviceworker.js").then((registration) => {
  registration.paymentManager.userHint = "Card number should be 16 digits";

  registration.paymentManager
    .enableDelegations(["shippingAddress", "payerName"])
    .then(() => {
      // …
    });

  // …
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentManager)*

