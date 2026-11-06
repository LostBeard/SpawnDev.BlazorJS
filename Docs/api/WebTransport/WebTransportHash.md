# WebTransportHash

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebTransport/WebTransportHash.cs`  

> A WebTransport certificate

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Algorithm` | `string?` | get/set | A string with the value: sha-256 (case-insensitive). Note that this string represents the algorithm to use to verify the hash, and that any hash using an unknown algorithm will be ignored. At the time of writing, SHA-256 is the only hash algorithm listed in the specification. |
| `Value` | `Union<byte[], ArrayBuffer, TypedArray, DataView>?` | get/set | An ArrayBuffer, TypedArray or DataView containing the hash value. |
