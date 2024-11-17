using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The IDBDatabase interface of the IndexedDB API provides a connection to a database; you can use an IDBDatabase object to open a transaction on your database then create, manipulate, and delete objects (data) in that database. The interface provides the only way to get and manage versions of the database.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase<br/>
    /// W3C spec:<br/>
    /// https://w3c.github.io/IndexedDB/#introduction
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBDatabaseAsync : EventTargetAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public IDBDatabaseAsync(IJSObjectReference jsRef) : base(jsRef) { }

        public Task<string[]> Get_ObjectStoreNames() => JSRef!.GetAsync<string[]>("objectStoreName");

        public Task<IDBObjectStoreAsync<TKey, TValue>> CreateObjectStore<TKey, TValue>(string storeName, IDBObjectStoreCreateOptions? options = null) => JSRef!.CallAsync<IDBObjectStoreAsync<TKey, TValue>>("createObjectStore", storeName, options);
    }
}
