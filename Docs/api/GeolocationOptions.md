# GeolocationOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/GeolocationOptions.cs`  

> Geolocation options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GeolocationOptions` | `class` | get | Geolocation options |
| `Timeout` | `long?` | get |  |
| `EnableHighAccuracy` | `bool?` | get |  |
| `MaximumAge` | `long?` | get/set | A positive long value indicating the maximum age in milliseconds of a possible cached position that is acceptable to return. If set to 0, it means that the device cannot use a cached position and must attempt to retrieve the real current position. If set to Infinity the device must return a cached position regardless of its age. Default: 0 |

