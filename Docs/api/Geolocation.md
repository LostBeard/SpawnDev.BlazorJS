# Geolocation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Geolocation.cs`  
**MDN Reference:** [Geolocation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Geolocation)

> The Geolocation interface represents an object able to obtain the position of the device programmatically. It gives Web content access to the location of the device. This allows a website or app to offer customized results based on the user's location. https://developer.mozilla.org/en-US/docs/Web/API/Geolocation

## Constructors

| Signature | Description |
|---|---|
| `Geolocation(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ClearWatch(int id)` | `void` | Removes the particular handler previously installed using watchPosition(). |
| `GetCurrentPosition(ActionCallback<GeolocationPosition> success)` | `void` | Determines the device's current location and gives back a GeolocationPosition object with the data. |
| `GetCurrentPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error)` | `void` | Determines the device's current location and gives back a GeolocationPosition object with the data. |
| `GetCurrentPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error, GeolocationOptions options)` | `void` | Determines the device's current location and gives back a GeolocationPosition object with the data. |
| `GetCurrentPosition(Action<GeolocationPosition> success, Action<GeolocationPositionError>? error, GeolocationOptions? options)` | `void` | Determines the device's current location and gives back a GeolocationPosition object with the data. |
| `GetCurrentPositionAsync(GeolocationOptions? options)` | `Task<GeolocationPosition>` | Determines the device's current location and gives back a GeolocationPosition object with the data. Throws an exception if the request fails. |
| `WatchPosition(ActionCallback<GeolocationPosition> success)` | `int` | The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function. |
| `WatchPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error)` | `int` | The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function. |
| `WatchPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error, GeolocationOptions options)` | `int` | The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function. |
| `WatchPosition(Action<GeolocationPosition> success, Action<GeolocationPositionError>? error, GeolocationOptions? options)` | `GeolocationWatchHandle` | Start watching the device position A GeolocationWatchHandle that can be used to start and stop the watch. |

## Example

```csharp
// Get the Geolocation object from Navigator
using var navigator = new Navigator();
using var geo = navigator.Geolocation;
if (geo == null)
{
    Console.WriteLine("Geolocation not available");
    return;
}

// One-shot position request using the async convenience method
try
{
    var position = await geo.GetCurrentPositionAsync(new GeolocationOptions
    {
        EnableHighAccuracy = true,
        Timeout = 10000,
        MaximumAge = 0
    });
    var coords = position.Coords;
    Console.WriteLine($"Latitude: {coords.Latitude}");
    Console.WriteLine($"Longitude: {coords.Longitude}");
    Console.WriteLine($"Accuracy: {coords.Accuracy}m");
}
catch (Exception ex)
{
    Console.WriteLine($"Geolocation error: {ex.Message}");
}

// One-shot position request using the Action overload (callback-based)
geo.GetCurrentPosition(
    success: (GeolocationPosition pos) =>
    {
        Console.WriteLine($"Got position: {pos.Coords.Latitude}, {pos.Coords.Longitude}");
    },
    error: (GeolocationPositionError err) =>
    {
        Console.WriteLine($"Error {err.Code}: {err.Message}");
    }
);

// Watch position continuously - returns a disposable handle
using var watchHandle = geo.WatchPosition(
    success: (GeolocationPosition pos) =>
    {
        Console.WriteLine($"Position updated: {pos.Coords.Latitude}, {pos.Coords.Longitude}");
    },
    error: (GeolocationPositionError err) =>
    {
        Console.WriteLine($"Watch error: {err.Message}");
    }
);
// Disposing the watchHandle automatically calls ClearWatch
```

