---
trigger: always_on
---

# SpawnDev.BlazorJS Implementation Standards (2026)

You are an expert developer for the SpawnDev.BlazorJS library. All C# code must provide high-performance, strongly-typed interop that mirrors the browser's JavaScript environment.

## 1. Inheritance & Async Patterns
*   **Base Class:** All JS wrappers MUST inherit from `SpawnDev.BlazorJS.JSObject`.
*   **Sync vs Async Calls:** Match the JavaScript behavior exactly.
    *   **Synchronous:** Use `JSRef.Call<T>` or `JSRef.CallVoid`.
    *   **Asynchronous:** If the JS method returns a Promise or is `async`, use `JSRef.CallAsync<T>` or `JSRef.CallVoidAsync`.
*   **Property Access:** Use `JSRef.Get<T>` and `JSRef.Set` for standard property interop.

## 2. Event Handling (EventTarget Wrappers)
For objects inheriting from `EventTarget` (like `Window`, `Document`, or `HTMLVideoElement`):
*   **ActionEvent:** Use for standard events that do not return a value. 
    *   *Implementation:* Expose as a public property using the `ActionEvent` or `ActionEvent<T>` type.
    *   *Goal:* Allow users to use `+=` and `-=` operators in C#.
*   **FuncEvent:** Use for events that require a return value to the JavaScript environment.
*   **Automatic Cleanup:** Remind users that `ActionEvent` handles reference detachment automatically when removed.

## 3. Passing .NET Methods to JavaScript
When a JavaScript method requires a callback function, wrap the C# delegate:
*   **ActionCallback:** Use to pass an `Action` (void return) to JS.
*   **FuncCallback:** Use to pass a `Func` (typed return) to JS.
*   **Memory Management:** Always implement or remind the user to call `.DisposeJS()` on these callback wrappers to prevent memory leaks in the interop layer.

## 4. Documentation & Sourcing
*   **Primary Source:** Use [developer.mozilla.org (MDN)](https://developer.mozilla.org) for all API descriptions.
*   **XML Comments:**
    *   **Summary:** Summarize the MDN description.
    *   **MDN Link:** The `<summary>` tag MUST include a `<see href="..."/>` link to the specific MDN documentation page for that interface or member.
    *   **Example:**
        ```csharp
        /// <summary>
        /// The Window.requestAnimationFrame() method tells the browser you wish to perform an animation.
        /// <see href="https://developer.mozilla.orgen-US/docs/Web/API/window/requestAnimationFrame"/>
        /// </summary>
        ```

## 5. Type Safety
*   Avoid `dynamic` and `object`.
*   If a JS method returns an object that has a corresponding wrapper in this library, return that wrapper type (e.g., return `Element` instead of `JSObject`).
