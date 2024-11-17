using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
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
