# Union

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** Union (abstract) -> Union&lt;T1, T2&gt; -> Union&lt;T1, T2, T3&gt; -> ... -> Union&lt;T1...T8&gt;  
**Source:** `SpawnDev.BlazorJS/Union.cs`

> Union provides TypeScript-style discriminated union types for C#. A Union&lt;T1, T2&gt; can hold exactly one value of either T1 or T2, with type-safe access via pattern matching, implicit conversions, and explicit casts. Unions serialize/deserialize correctly through the SpawnDev.BlazorJS JSON serialization system, making them ideal for JavaScript APIs that accept multiple types for the same parameter.

## Variants

| Class | Description |
|---|---|
| `Union<T1, T2>` | Can hold a value of type T1 or T2. |
| `Union<T1, T2, T3>` | Can hold a value of type T1, T2, or T3. |
| `Union<T1, T2, T3, T4>` | Up to 4 types. |
| `Union<T1, T2, T3, T4, T5>` | Up to 5 types. |
| `Union<T1, T2, T3, T4, T5, T6>` | Up to 6 types. |
| `Union<T1, T2, T3, T4, T5, T6, T7>` | Up to 7 types. |
| `Union<T1, T2, T3, T4, T5, T6, T7, T8>` | Up to 8 types. |

## Base Class Properties (Union)

| Property | Type | Description |
|---|---|---|
| `Value` | `object?` | The boxed value contained in the union. |
| `ValueType` | `Type` | The runtime Type of the contained value. |

## Base Class Methods (Union)

| Method | Return Type | Description |
|---|---|---|
| `Is<T>()` | `bool` | Returns true if the union contains a value of type T. |
| `Is<T>(out T value)` | `bool` | Returns true and outputs the value if the union contains type T. |
| `Is(Type type)` | `bool` | Returns true if the union contains a value of the specified Type. |
| `As<T>()` | `T` | If Value is T, returns it cast to T; otherwise returns default(T). |
| `ToString()` | `string` | Returns Value?.ToString() or "null". |

## Union&lt;T1, T2&gt; Methods

| Method | Return Type | Description |
|---|---|---|
| `Match(Action<T1>, Action<T2>)` | `void` | Execute an action based on the contained type. |
| `Match<T>(Func<T1, T>, Func<T2, T>)` | `T` | Return a value based on the contained type. |
| `Map(Func<T1, Union<T1, T2>>)` | `Union<T1, T2>` | Transform if the union contains T1. |
| `Map(Func<T2, Union<T1, T2>>)` | `Union<T1, T2>` | Transform if the union contains T2. |
| `MapAsync(Func<T1, Task<Union<T1, T2>>>)` | `Task<Union<T1, T2>>` | Async transform if the union contains T1. |
| `MapAsync(Func<T2, Task<Union<T1, T2>>>)` | `Task<Union<T1, T2>>` | Async transform if the union contains T2. |

## Implicit and Explicit Conversions

```csharp
// Implicit: value -> Union
Union<string, int> u1 = "hello";    // Implicit from string
Union<string, int> u2 = 42;         // Implicit from int

// Explicit: Union -> value
string s = (string)u1;   // "hello"
int i = (int)u2;         // 42
int bad = (int)u1;       // default(int) = 0 (wrong type - returns default, not exception)
```

## Example - Basic Usage

```csharp
// TypeScript: function process(value: string | number | boolean): void
void Process(Union<string, int, bool> value)
{
    value.Match(
        s => Console.WriteLine($"String: {s}"),
        i => Console.WriteLine($"Number: {i}"),
        b => Console.WriteLine($"Boolean: {b}")
    );
}

// Implicit conversion - call with any of the union types
Process("hello");
Process(42);
Process(true);
```

## Example - With JS Interop

```csharp
// Many JS APIs accept multiple types
// Element.append() accepts Node or string
public void Append(params Union<Node, string>[] nodes)
    => JSRef!.CallApplyVoid("append", nodes);

// Usage
element.Append("Hello ");
element.Append(spanElement);
element.Append("world", boldElement, "!");
```

## Example - Match with Return Value

```csharp
Union<string, int> value = GetValue();

string description = value.Match(
    s => $"Got string: {s}",
    i => $"Got number: {i}"
);
```

## Example - Type Checking

```csharp
Union<string, int, bool> value = GetUnionValue();

if (value.Is<string>(out var str))
{
    Console.WriteLine($"It's a string: {str}");
}
else if (value.Is<int>())
{
    int num = value.As<int>();
    Console.WriteLine($"It's a number: {num}");
}
```
