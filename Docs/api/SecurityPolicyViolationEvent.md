# SecurityPolicyViolationEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/SecurityPolicyViolationEvent.cs`  
**MDN Reference:** [SecurityPolicyViolationEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SecurityPolicyViolationEvent)

> The SecurityPolicyViolationEvent interface inherits from Event, and represents the event object of an event sent on a document or worker when its content security policy is violated. https://developer.mozilla.org/en-US/docs/Web/API/SecurityPolicyViolationEvent

## Constructors

| Signature | Description |
|---|---|
| `SecurityPolicyViolationEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BlockedURI` | `string` | get | A string representing the URI of the resource that was blocked because it violates a policy. |
| `ColumnNumber` | `int?` | get | The column number in the document or worker at which the violation occurred. |
| `Disposition` | `string` | get | Indicates how the violated policy is configured to be treated by the user agent. This will be "enforce" or "report". |
| `DocumentURI` | `string` | get | A string representing the URI of the document or worker in which the violation was found. |
| `EffectiveDirective` | `string` | get | A string representing the directive whose enforcement uncovered the violation. |
| `LineNumber` | `int?` | get | The line number in the document or worker at which the violation occurred. |
| `OriginalPolicy` | `string` | get | A string containing the policy whose enforcement uncovered the violation. |
| `Referrer` | `string?` | get | A string representing the URL for the referrer of the resources whose policy was violated, or null. |
| `Sample` | `string?` | get | A string representing a sample of the resource that caused the violation, usually the first 40 characters. This will only be populated if the resource is an inline script, event handler, or style - external resources causing a violation will not generate a sample. |
| `SourceFile` | `string?` | get | If the violation occurred as a result of a script, this will be the URL of the script; otherwise, it will be null. Both columnNumber and lineNumber should have non-null values if this property is not null. |
| `StatusCode` | `int` | get | A number representing the HTTP status code of the document or worker in which the violation occurred. |
| `ViolatedDirective` | `string` | get | A string representing the directive whose enforcement uncovered the violation. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SecurityPolicyViolationEvent>(...)` or constructor `new SecurityPolicyViolationEvent(...)`

```js
document.addEventListener("securitypolicyviolation", (e) => {
  console.log(e.blockedURI);
  console.log(e.violatedDirective);
  console.log(e.originalPolicy);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SecurityPolicyViolationEvent)*

