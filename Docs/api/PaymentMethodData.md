# PaymentMethodData

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PaymentMethodData.cs`  
**MDN Reference:** [PaymentMethodData on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/methodData#value)

> https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/methodData#value

## Constructors

| Signature | Description |
|---|---|
| `PaymentMethodData()` | Creates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `SupportedMethods` | `string?` | get | A payment method identifier for a payment method that the merchant website accepts. |
| `Data` | `JSObject?` | get | An object that provides optional information that might be needed by the supported payment methods. If supplied, it will be JSON-serialized. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetData()` | `T` | Get data as T |
| `SetData(object data)` | `void` | Set data value |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PaymentMethodData>(...)` or constructor `new PaymentMethodData(...)`

```js
self.addEventListener("paymentrequest", (e) => {
  console.log(e.methodData);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/methodData)*

