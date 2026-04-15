# PaymentCurrencyAmount

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/PaymentCurrencyAmount.cs`  
**MDN Reference:** [PaymentCurrencyAmount on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/total#value)

> https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/total#value

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PaymentCurrencyAmount` | `class` | get/set | https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/total#value |
| `Value` | `string` | get | A string containing a decimal monetary value, e.g., 2.55. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PaymentCurrencyAmount>(...)` or constructor `new PaymentCurrencyAmount(...)`

```js
self.addEventListener("paymentrequest", (e) => {
  console.log(e.total);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/total)*

