# EpochDateTime

**Namespace:** `SpawnDev.BlazorJS`  
**Source:** `SpawnDev.BlazorJS/EpochDateTime.cs`

> EpochDateTime converts between .NET DateTime and JavaScript epoch milliseconds (milliseconds since 1970-01-01 UTC). It serializes to a JSON number (epoch milliseconds) and deserializes back to EpochDateTime. This is useful for JavaScript APIs that use numeric timestamps, such as `Date.now()`, `performance.timeOrigin`, or any API returning milliseconds since the Unix epoch.

## Properties

| Property | Type | Description |
|---|---|---|
| `Value` | `DateTime` | The DateTime value in local time (DateTimeKind.Local). |
| `ValueEpoch` | `long` | The epoch milliseconds (ms since 1970-01-01 UTC). Get or set. |
| `Now` | `EpochDateTime` | Static. Returns the current date/time as EpochDateTime. |

## Constructors

```csharp
new EpochDateTime()                        // Default
new EpochDateTime(DateTime value)          // From DateTime
new EpochDateTime(long valueEpoch)         // From epoch milliseconds
```

## Implicit Conversions

All conversions are implicit and bidirectional:

```csharp
// DateTime <-> EpochDateTime
EpochDateTime epoch = DateTime.Now;
DateTime dt = epoch;

// DateTime? <-> EpochDateTime?
EpochDateTime? nullableEpoch = (DateTime?)null;
DateTime? nullableDt = (EpochDateTime?)null;

// long <-> EpochDateTime
EpochDateTime epoch = 1712345678000L;
long ms = epoch;

// long? <-> EpochDateTime?
EpochDateTime? nullableEpoch = (long?)null;
long? nullableMs = (EpochDateTime?)null;
```

## Example

```csharp
// Reading a JS timestamp
EpochDateTime created = jsObject.JSRef!.Get<EpochDateTime>("createdAt");
Console.WriteLine($"Created: {created.Value}");         // DateTime
Console.WriteLine($"Epoch ms: {created.ValueEpoch}");   // 1712345678000

// Setting a JS timestamp
jsObject.JSRef!.Set("expiresAt", EpochDateTime.Now);

// In a wrapper class
public class Token : JSObject
{
    public Token(IJSInProcessObjectReference _ref) : base(_ref) { }

    public EpochDateTime IssuedAt
    {
        get => JSRef!.Get<EpochDateTime>("iat");
        set => JSRef!.Set("iat", value);
    }

    public EpochDateTime ExpiresAt
    {
        get => JSRef!.Get<EpochDateTime>("exp");
        set => JSRef!.Set("exp", value);
    }
}
```

## JSON Serialization

Serializes as a plain JSON number:

```json
1712345678000
```

Deserializes from a number or null.
