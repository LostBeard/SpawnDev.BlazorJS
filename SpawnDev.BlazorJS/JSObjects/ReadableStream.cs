using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ReadableStream : JSObject
    {
        public ReadableStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ReadableStream() : base(JS.New(nameof(ReadableStream))) { }
        public ReadableStream(ReadableStreamUnderlyingSource underlyingSource) : base(JS.New(nameof(ReadableStream), underlyingSource)) { }

        public Uint8Array? Read()
        {
            Uint8Array? ret = null;
            try
            {
                ret = JSRef.Call<Uint8Array>("read");
            }
            catch { }
            return ret;
        }

        public AsyncIterator GetAsyncIterator()
        {
            var ret = JSRef.Get<AsyncIterator>("Symbol.asyncIterator");
            return ret;
        }

        public ReadableStreamDefaultReader GetReader() => JSRef.Call<ReadableStreamDefaultReader>("getReader");
        public void Destroy() => JSRef.CallVoid("destroy");
    }
}
