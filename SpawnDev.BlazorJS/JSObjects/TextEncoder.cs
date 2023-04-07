using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class EncodeIntoProgress
    {
        public int Read { get; set; }
        public int Wrtitten { get; set; }
    }
    public class TextEncoder : JSObject
    {
        public TextEncoder() : base(JS.New(nameof(TextEncoder))) { }
        public TextEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint8Array Encode(string text) => JSRef.Call<Uint8Array>("encode", text);
        public EncodeIntoProgress EncodeInto(string text, Uint8Array dest) => JSRef.Call<EncodeIntoProgress>("encodeInto", text, dest);
    }
}
