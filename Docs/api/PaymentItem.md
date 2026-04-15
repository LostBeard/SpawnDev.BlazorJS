# PaymentItem

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/PaymentItem.cs`  
**MDN Reference:** [PaymentItem on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers#total)

> https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers#total

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PaymentItem` | `class` | get/set | https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers#total |
| `Amount` | `PaymentCurrencyAmount` | get/set | A PaymentCurrencyAmount object (see total > Value). |
| `Pending` | `bool` | get | A boolean. When set to true it means that the amount member is not final. This is commonly used to show items such as shipping or tax amounts that depend upon selection of shipping address or shipping option. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PaymentItem>(...)` or constructor `new PaymentItem(...)`

```js
self.addEventListener("paymentrequest", (e) => {
  console.log(e.modifiers);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers)*

