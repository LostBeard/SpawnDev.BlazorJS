# PaymentAddress

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PaymentRequest/PaymentAddress.cs`  
**MDN Reference:** [PaymentAddress on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentAddress)

> The PaymentAddress interface of the Payment Request API is used to store validity information about an address used for payment. https://developer.mozilla.org/en-US/docs/Web/API/PaymentAddress

## Constructors

| Signature | Description |
|---|---|
| `PaymentAddress(IJSInProcessObjectReference _ref)` | Creates a new instance of `PaymentAddress`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AddressLine` | `Array<string>` | get | Returns the first line of the address. |
| `City` | `string` | get | Returns the city. |
| `Country` | `string` | get | Returns the country. |
| `DependentLocality` | `string` | get | Returns the dependent locality. |
| `Organization` | `string` | get | Returns the organization. |
| `Phone` | `string` | get | Returns the phone number. |
| `PostalCode` | `string` | get | Returns the postal code. |
| `Recipient` | `string` | get | Returns the recipient. |
| `Region` | `string` | get | Returns the region. |
| `SortingCode` | `string` | get | Returns the sorting code. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToJSON()` | `object` | Returns a JSON-serializable object that provides a address information using the PaymentAddress vocabulary. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PaymentAddress>(...)` or constructor `new PaymentAddress(...)`

```js
const supportedInstruments = [
  {
    supportedMethods: "https://example.com/pay",
  },
];

const details = {
  total: { label: "Donation", amount: { currency: "USD", value: "65.00" } },
  displayItems: [
    {
      label: "Original donation amount",
      amount: { currency: "USD", value: "65.00" },
    },
  ],
  shippingOptions: [
    {
      id: "standard",
      label: "Standard shipping",
      amount: { currency: "USD", value: "0.00" },
      selected: true,
    },
  ],
};

const options = { requestShipping: true };

async function doPaymentRequest() {
  const request = new PaymentRequest(supportedInstruments, details, options);
  // Add event listeners here.
  // Call show() to trigger the browser's payment flow.
  const response = await request.show();
  // Process payment.
  const json = response.toJSON();
  const httpResponse = await fetch("/pay/", { method: "POST", body: json });
  const result = httpResponse.ok ? "success" : "failure";

  await response.complete(result);
}
doPaymentRequest();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentAddress)*

