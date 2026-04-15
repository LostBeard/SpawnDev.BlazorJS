# GeolocationWatchHandle

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `IDisposable`  
**Source:** `JSObjects/GeolocationWatchHandle.cs`  

> Handles callbacks for the Geolocation watchPosition method Disposing this object will stop the watch and dispose the callbacks

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `int` | get | Geolocation watch id |
| `Watching` | `bool` | get | True if the watch is running |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start()` | `void` | Start watching the device position |
| `Stop()` | `void` | Stop watching the device position |

