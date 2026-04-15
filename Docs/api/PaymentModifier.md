# PaymentModifier

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PaymentModifier.cs`  
**MDN Reference:** [PaymentModifier on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers#value)

> https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers#value

## Constructors

| Signature | Description |
|---|---|
| `PaymentModifier()` | Creates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `SupportedMethods` | `string?` | get/set | A payment method identifier. The members of the object only apply to the payment if the user selects this payment method. |
| `Total` | `PaymentItem?` | get | A PaymentItem object |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PaymentModifier>(...)` or constructor `new PaymentModifier(...)`

```js
self.addEventListener("paymentrequest", (e) => {
  console.log(e.modifiers);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers)*

