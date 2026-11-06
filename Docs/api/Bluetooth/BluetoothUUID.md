# BluetoothUUID

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/Bluetooth/BluetoothUUID.cs`  

> The BluetoothUUID interface of the Web Bluetooth API provides a way to look up Universally Unique Identifier (UUID) values by name in the registry maintained by the Bluetooth SIG. https://developer.mozilla.org/en-US/docs/Web/API/BluetoothUUID

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `CanonicalUUID(uint alias)` | `string` | Returns the 128-bit UUID when passed the 16- or 32-bit UUID alias. |
| `GetCharacteristic(string name)` | `string` | Returns the 128-bit UUID representing a registered characteristic when passed a name or the 16- or 32-bit UUID alias. |
| `GetDescriptor(string name)` | `string` | Returns a UUID representing a registered descriptor when passed a name or the 16- or 32-bit UUID alias. |
| `GetService(string name)` | `string` | Returns a UUID representing a registered service when passed a name or the 16- or 32-bit UUID alias. |
