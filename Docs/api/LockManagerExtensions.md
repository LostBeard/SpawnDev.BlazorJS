# LockManagerExtensions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/LockManagerExtensions.cs`  

> Adds extension methods to LockManager

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestHandle(this LockManager _this, string lockName, LockRequestOptions options)` | `Task<TaskCompletionSource>` | Once the lock is acquired, a TaskCompletionSource is returned. The lock will be held until TaskCompletionSource completes |
| `RequestHandle<TResult>(this LockManager _this, string lockName, LockRequestOptions options)` | `Task<TaskCompletionSource<TResult>>` |  |
| `RequestHandle(this LockManager _this, string lockName)` | `Task<TaskCompletionSource>` | Once the lock is acquired, a TaskCompletionSource is returned. The lock will be held until TaskCompletionSource completes |
| `RequestHandle<TResult>(this LockManager _this, string lockName)` | `Task<TaskCompletionSource<TResult>>` |  |
| `RequestHandle(this LockManager _this, string lockName, int millisecondsTimeout)` | `Task<TaskCompletionSource>` | Once the lock is acquired, a TaskCompletionSource is returned. The lock will be held until TaskCompletionSource completes |
| `RequestHandle<TResult>(this LockManager _this, string lockName, int millisecondsTimeout)` | `Task<TaskCompletionSource<TResult>>` |  |
| `QueryClientIds(this LockManager _this)` | `Task<string[]>` | Returns an array of client ids that are holding or waiting for locks |
| `QueryClientIdsHolding(this LockManager _this, string lockName)` | `Task<string[]>` | Returns an array of clientIds that are holding a given lock name |
| `QueryClientIdsPending(this LockManager _this, string lockName)` | `Task<string[]>` | Returns an array of clientIds that are pending a given lock name |
| `QueryClientIdHolding(this LockManager _this, string lockName)` | `Task<string?>` | Returns the clientId of the first holder of a given lock name, or null if none |
| `GetClientId(this LockManager _this)` | `Task<string>` | Returns the clientId of this instance |
