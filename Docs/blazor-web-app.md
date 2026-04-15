# Blazor Web App Compatibility

.NET 8 introduced the Blazor Web App hosting model that allows mixing server-side rendering and WebAssembly rendering, with optional prerendering. This guide covers how to use SpawnDev.BlazorJS in this context.

---

## Background

SpawnDev.BlazorJS requires `IJSInProcessRuntime`, which is only available in Blazor WebAssembly. It cannot run on the server. However, as of version 2.5.11, the `BlazorJSRuntime` service can be **registered** on the server - it just will not be functional. This allows prerendering to work without crashing due to a missing service.

---

## Key Concepts

### IsBrowser Check

Components that use `BlazorJSRuntime` must check whether they are actually running in a browser before calling interop methods:

```csharp
@inject BlazorJSRuntime JS

@code {
    protected override void OnInitialized()
    {
        // Check before using JS interop
        if (JS.IsBrowser)
        {
            var height = JS.Get<int>("window.innerHeight");
        }

        // Alternative using the platform check directly
        if (OperatingSystem.IsBrowser())
        {
            // Safe to use JS interop
        }
    }
}
```

During server-side prerendering, `JS.IsBrowser` returns `false` and `JS.HasInProcessRuntime` returns `false`. Calling interop methods in this state will fail.

---

## Server Project Registration

Register BlazorJSRuntime in the server project the same way as the client:

```csharp
// Server Program.cs
builder.Services.AddBlazorJSRuntime();
```

This registers a non-functional BlazorJSRuntime singleton that won't crash during prerendering but won't do anything either. The real, functional runtime is available only when the component switches to WebAssembly rendering.

---

## Interactive Render Mode Options

### Per Page/Component Interactivity

In the Server project's `App.razor`, use the default `<Routes />` without a render mode:

```html
<!-- App.razor (Server project) -->
<Routes />
```

Then in each WebAssembly page or component that needs SpawnDev.BlazorJS, add the render mode directive:

```csharp
@rendermode @(new InteractiveWebAssemblyRenderMode(prerender: false))
```

With `prerender: false`, the component is never server-rendered - it waits for WebAssembly to load and then renders entirely on the client. This guarantees that `BlazorJSRuntime` is functional when the component's lifecycle methods run.

With `prerender: true` (the default), the component renders on the server first (without JS interop), then re-renders on the client. Your component code must handle both cases:

```csharp
@rendermode @(new InteractiveWebAssemblyRenderMode(prerender: true))

@code {
    protected override void OnAfterRender(bool firstRender)
    {
        // OnAfterRender only runs in the browser - safe to use JS
        if (firstRender && OperatingSystem.IsBrowser())
        {
            // Now JS interop is available
            var height = JS.Get<int>("window.innerHeight");
        }
    }
}
```

### Global Interactivity

In the Server project's `App.razor`, apply the render mode to `<Routes />`:

```html
<!-- App.razor (Server project) -->
<Routes @rendermode="new InteractiveWebAssemblyRenderMode(prerender: false)" />
```

This makes all pages and components render in WebAssembly mode. No per-component `@rendermode` directives are needed.

With prerendering enabled globally:

```html
<Routes @rendermode="new InteractiveWebAssemblyRenderMode(prerender: true)" />
```

All components will prerender on the server first, then switch to WebAssembly. Guard all JS interop calls with `IsBrowser` checks.

---

## Compatible Project Options

When creating a Blazor Web App project, these settings work with SpawnDev.BlazorJS:

### Interactive Render Mode

- **Auto (Server and WebAssembly)** - Works. Components start in Server mode, then switch to WebAssembly. SpawnDev.BlazorJS is only functional in WebAssembly mode.
- **WebAssembly** - Works. Components render in WebAssembly mode. SpawnDev.BlazorJS is functional.
- **Server** - Does NOT work for SpawnDev.BlazorJS components (no `IJSInProcessRuntime`).

### Interactivity Location

- **Per page/component** - Each component specifies its render mode. SpawnDev.BlazorJS components must use `InteractiveWebAssemblyRenderMode`.
- **Global** - Set once in `App.razor`. All components use the specified mode.

---

## Client Project Setup

The client (WebAssembly) project's `Program.cs` is set up normally:

```csharp
// Client Program.cs
using SpawnDev.BlazorJS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddBlazorJSRuntime();

await builder.Build().BlazorJSRunAsync();
```

---

## Summary

| Hosting Model | SpawnDev.BlazorJS Works? | Notes |
|---|---|---|
| Blazor WebAssembly Standalone | Yes | Full support, this is the primary target |
| Blazor Web App - WebAssembly mode | Yes | Full support when components use WebAssembly render mode |
| Blazor Web App - Auto mode | Partial | Only functional after switching to WebAssembly |
| Blazor Web App - Server mode | No | No `IJSInProcessRuntime` on the server |
| Blazor Web App - Prerendering | Partial | BlazorJSRuntime is registered but non-functional during prerender |

**Recommendation:** For the best experience with SpawnDev.BlazorJS, use either a Blazor WebAssembly Standalone app or set `prerender: false` on components that need JavaScript interop.

---

## See Also

- [Getting Started](getting-started.md) - Standard setup
- [Worker Scope Detection](worker-scopes.md) - Scope-aware Program.cs
- [BlazorJSRuntime](blazorjsruntime.md) - IsBrowser and HasInProcessRuntime properties
