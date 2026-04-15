# Atomics

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** Static class  
**MDN Reference:** [Atomics - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Atomics)

> Wraps the JavaScript `Atomics` namespace object. Provides static methods for performing atomic operations on SharedArrayBuffer and ArrayBuffer typed arrays. All methods are generic and automatically handle the `BigInt<long>`/`BigInt<ulong>` conversion required for 64-bit typed arrays (`BigInt64Array`, `BigUint64Array`), making them seamless to use from C#.

## BigInt Conversion

JavaScript's `Atomics` methods require `BigInt` values when operating on `BigInt64Array` or `BigUint64Array`. SpawnDev.BlazorJS handles this transparently - when `T` is `long` or `ulong`, the values are automatically converted to/from `BigInt<long>` or `BigInt<ulong>` internally. You simply pass and receive `long`/`ulong` values.

## Static Methods

### Arithmetic Operations

| Method | Return Type | Description |
|---|---|---|
| `Add<T>(TypedArray<T> typedArray, long index, T value)` | `T` | Atomically adds `value` to the element at `index`. Returns the old value. |
| `Sub<T>(TypedArray<T> typedArray, long index, T value)` | `T` | Atomically subtracts `value` from the element at `index`. Returns the old value. |

### Bitwise Operations

| Method | Return Type | Description |
|---|---|---|
| `And<T>(TypedArray<T> typedArray, long index, T value)` | `T` | Atomically performs bitwise AND. Returns the old value. |
| `Or<T>(TypedArray<T> typedArray, long index, T value)` | `T` | Atomically performs bitwise OR. Returns the old value. |
| `Xor<T>(TypedArray<T> typedArray, long index, T value)` | `T` | Atomically performs bitwise XOR. Returns the old value. |

### Load / Store

| Method | Return Type | Description |
|---|---|---|
| `Load<T>(TypedArray<T> typedArray, long index)` | `T` | Atomically reads the value at `index`. |
| `Store<T>(TypedArray<T> typedArray, long index, T value)` | `T` | Atomically writes `value` to `index`. Returns the stored value. |

### Exchange

| Method | Return Type | Description |
|---|---|---|
| `Exchange<T>(TypedArray<T> typedArray, long index, T value)` | `T` | Atomically replaces the value at `index` with `value`. Returns the old value. |
| `CompareExchange<T>(TypedArray<T> typedArray, long index, T expectedValue, T replacementValue)` | `T` | Atomically replaces `index` with `replacementValue` only if the current value equals `expectedValue`. Returns the old value regardless. |

### Wait / Notify

| Method | Return Type | Description |
|---|---|---|
| `Wait<T>(TypedArray<T> typedArray, long index, T value)` | `string` | Blocks until the value at `index` changes from `value`, or forever. Returns `"ok"`, `"not-equal"`, or `"timed-out"`. Only works on `Int32Array`/`BigInt64Array` backed by `SharedArrayBuffer`. |
| `Wait<T>(TypedArray<T> typedArray, long index, T value, int timeout)` | `string` | Same as above with a timeout in milliseconds. Negative values become 0. |
| `WaitAsync<T>(TypedArray<T> typedArray, long index, T value)` | `AtomicsWaitAsyncResult` | Asynchronous version of Wait. Returns an object with `Async` (bool) and `Value` (string or Promise). |
| `WaitAsync<T>(TypedArray<T> typedArray, long index, T value, int timeout)` | `AtomicsWaitAsyncResult` | Async Wait with timeout. |
| `Notify(TypedArray typedArray, long index, int count)` | `int` | Wakes up to `count` agents waiting on the given index. Returns the number of agents actually woken. Returns 0 if the buffer is not shared. |

### Utility

| Method | Return Type | Description |
|---|---|---|
| `IsLockFree(int size)` | `bool` | Returns `true` if atomic operations on the given byte size use hardware atomics (lock-free). Typically true for sizes 1, 2, and 4. |

## Supported TypedArray Types

`T` must be `struct`. The following typed arrays are supported:
- `Int8Array` (`sbyte`), `Uint8Array` (`byte`)
- `Int16Array` (`short`), `Uint16Array` (`ushort`)
- `Int32Array` (`int`), `Uint32Array` (`uint`)
- `BigInt64Array` (`long`), `BigUint64Array` (`ulong`) - automatically converted via `BigInt<T>`

## Example

```csharp
// Create a shared buffer for cross-worker communication
using var sab = new SharedArrayBuffer(1024);
using var view = new Int32Array(sab);

// Atomic store and load
Atomics.Store(view, 0, 42);
int val = Atomics.Load(view, 0);  // 42

// Atomic add (returns old value)
int oldVal = Atomics.Add(view, 0, 10);  // 42
int newVal = Atomics.Load(view, 0);     // 52

// Compare-and-swap
int prev = Atomics.CompareExchange(view, 0, 52, 100);
// prev == 52, view[0] is now 100

// Bitwise operations
Atomics.Store(view, 1, 0xFF);
Atomics.And(view, 1, 0x0F);  // view[1] is now 0x0F

// Wait/Notify for cross-worker synchronization
// In a worker thread:
string result = Atomics.Wait(view, 0, 100);  // Blocks until value changes
// result is "ok" when notified, "not-equal" if value already changed

// In the main thread or another worker:
int woken = Atomics.Notify(view, 0, 1);  // Wake 1 waiting agent

// Check lock-free support
bool lockFree4 = Atomics.IsLockFree(4);  // true on most platforms

// 64-bit atomics (BigInt conversion is automatic)
using var sab64 = new SharedArrayBuffer(64);
using var view64 = new BigInt64Array(sab64);
Atomics.Store(view64, 0, 9007199254740993L);  // Beyond Number.MAX_SAFE_INTEGER
long loaded = Atomics.Load(view64, 0);         // 9007199254740993
```
