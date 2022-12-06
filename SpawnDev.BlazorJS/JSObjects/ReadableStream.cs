using Microsoft.JSInterop;
using System;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{

    [JsonConverter(typeof(JSObjectConverter<ReadableStream>))]
    public class ReadableStream : JSObject
    {
        public ReadableStream(IJSInProcessObjectReference _ref) : base(_ref) { }

        CallbackGroup callbacks = new CallbackGroup();

        public void OnReadable(Action callback) { _ref.CallVoid("on", "readable", Callback.Create(callback, callbacks)); }
        public void OnEnd(Action callback) { _ref.CallVoid("on", "end", Callback.Create(callback, callbacks)); }

        public ReadableStream(ExpandoObject options) : base("ReadableStream", options) { }

        public Uint8Array? Read()
        {
            Uint8Array? ret = null;
            try
            {
                ret = _ref.Call<Uint8Array>("read");
            }
            catch { }
            return ret;
        }

        public ReadableStreamDefaultReader GetReader()
        {
            return _ref.Call<ReadableStreamDefaultReader>("getReader");
        }

        public void Destroy()
        {
            _ref.CallVoid("destroy");
        }

        public override void Dispose()
        {
            if (IsWrapperDisposed) return;
            base.Dispose();
            callbacks.Dispose();
        }
    }
}
