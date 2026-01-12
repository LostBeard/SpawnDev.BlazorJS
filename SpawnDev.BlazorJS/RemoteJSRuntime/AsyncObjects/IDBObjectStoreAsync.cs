using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The IDBObjectStoreAsync interface of the IndexedDB API represents an object store in a database.
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBObjectStoreAsync<TPrimaryKey, TValue> : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public IDBObjectStoreAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
}
