# PaymentResponse

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/PaymentRequest/PaymentResponse.cs`  

> The PaymentResponse interface of the Payment Request API is returned after a user selects a payment method and approves a payment request.

## Constructors

| Signature | Description |
|---|---|
| `PaymentResponse(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RequestId` | `string` | get | Returns the payment request ID. |
| `MethodName` | `string` | get | Returns the payment method identifier. |
| `ShippingAddress` | `PaymentAddress?` | get | Returns the shipping address chosen by the user. |
| `ShippingOption` | `string?` | get | Returns the shipping option chosen by the user. |
| `PayerName` | `string?` | get | Returns the payer's name. |
| `PayerEmail` | `string?` | get | Returns the payer's email. |
| `PayerPhone` | `string?` | get | Returns the payer's phone. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Details()` | `T` | Returns a JSON-serializable object that provides a payment method specific message used by the merchant to process the transaction and determine successful fund transfer. |
| `Complete(string result)` | `Task` | Signals that the transaction has completed. |
| `Retry(PaymentValidationErrors errorFields)` | `Task` | Signals that the user has retried the payment. |

