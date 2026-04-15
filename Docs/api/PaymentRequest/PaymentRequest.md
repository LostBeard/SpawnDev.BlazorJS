# PaymentRequest

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/PaymentRequest/PaymentRequest.cs`  

> The PaymentRequest interface of the Payment Request API is the primary entry point into the API. It allows the web page to create a payment request, to determine if the user has a way to make the payment, and to show the payment UI to the user.

## Constructors

| Signature | Description |
|---|---|
| `PaymentRequest(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `PaymentRequest(IEnumerable<PaymentMethodData> methodData, PaymentDetailsInit details, PaymentOptions? options)` | Creates a new PaymentRequest. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | Returns the ID of the payment request. |
| `ShippingAddress` | `PaymentAddress?` | get | Returns the shipping address chosen by the user. |
| `ShippingOption` | `string?` | get | Returns the shipping option chosen by the user. |
| `ShippingType` | `string?` | get | Returns the shipping type chosen by the user. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Show()` | `Task<PaymentResponse>` | Shows the payment UI to the user. |
| `Show(Task<PaymentDetailsInit> detailsPromise)` | `Task<PaymentResponse>` | Shows the payment UI to the user. |
| `Abort()` | `Task` | Aborts the payment request. |
| `CanMakePayment()` | `Task<bool>` | Returns a boolean indicating whether the user has a way to make the payment. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnPaymentMethodChange` | `ActionEvent<Event>` | Fired when the user changes the payment method. |
| `OnShippingAddressChange` | `ActionEvent<Event>` | Fired when the user changes the shipping address. |
| `OnShippingOptionChange` | `ActionEvent<Event>` | Fired when the user changes the shipping option. |

