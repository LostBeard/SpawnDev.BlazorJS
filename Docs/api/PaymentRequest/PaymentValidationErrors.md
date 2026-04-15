# PaymentValidationErrors

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/PaymentRequest/PaymentValidationErrors.cs`  
**MDN Reference:** [PaymentValidationErrors on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PaymentValidationErrors)

> The PaymentValidationErrors dictionary is a dictionary that indicates which fields in a PaymentResponse failed validation. https://developer.mozilla.org/en-US/docs/Web/API/PaymentValidationErrors

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PaymentValidationErrors` | `class` | get | The PaymentValidationErrors dictionary is a dictionary that indicates which fields in a PaymentResponse failed validation. https://developer.mozilla.org/en-US/docs/Web/API/PaymentValidationErrors |
| `Payer` | `PayerErrors?` | get |  |
| `ShippingAddress` | `AddressErrors?` | get |  |
| `PayerErrors` | `class` | get | Validation errors for payer details. |
| `Name` | `string?` | get |  |
| `Phone` | `string?` | get |  |
| `AddressErrors` | `class` | get | Validation errors for the shipping address. |
| `City` | `string?` | get |  |
| `Country` | `string?` | get |  |
| `DependentLocality` | `string?` | get |  |
| `Organization` | `string?` | get |  |
| `PostalCode` | `string?` | get |  |
| `Recipient` | `string?` | get |  |
| `Region` | `string?` | get |  |
| `SortingCode` | `string?` | get |  |

