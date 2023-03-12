using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<AsyncIterator>))]
    public class AsyncIterator : JSObject
    {
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ValueTask<AsyncIteratorNext> Next() => JSRef.CallAsync<AsyncIteratorNext>("next");
    }
}
