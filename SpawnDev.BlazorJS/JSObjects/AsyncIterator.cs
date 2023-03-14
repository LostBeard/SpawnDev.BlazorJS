using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class AsyncIterator : JSObject
    {
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<AsyncIteratorNext> Next() => JSRef.CallAsync<AsyncIteratorNext>("next");
    }
}
