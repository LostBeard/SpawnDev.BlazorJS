using Microsoft.JSInterop;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WritableStream interface of the Streams API provides a standard abstraction for writing streaming data to a destination, known as a sink. This object comes with built-in backpressure and queuing.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WritableStream<br/>
    /// https://streams.spec.whatwg.org/#writablestream<br/>
    /// </summary>
    [Transferable]
    public class WritableStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WritableStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="sink"></param>
        public WritableStream(UnderlyingSink? sink = null) : base(sink == null ? JS.New(nameof(WritableStream)) : JS.New(nameof(WritableStream), sink)) { }
        /// <summary>
        /// A boolean indicating whether the WritableStream is locked to a writer.
        /// </summary>
        public bool Locked => JSRef!.Get<bool>("locked");
        /// <summary>
        /// Aborts the stream, signaling that the producer can no longer successfully write to the stream and it is to be immediately moved to an error state, with any queued writes discarded.
        /// </summary>
        public Task Abort(string? reason = null) => reason == null ? JSRef!.CallVoidAsync("abort") : JSRef!.CallVoidAsync("abort", reason);
        /// <summary>
        /// Closes the stream.
        /// </summary>
        public Task Close() => JSRef!.CallVoidAsync("close");
        /// <summary>
        /// Returns a new instance of WritableStreamDefaultWriter and locks the stream to that instance. While the stream is locked, no other writer can be acquired until this one is released.
        /// </summary>
        /// <returns></returns>
        public WritableStreamDefaultWriter GetWriter() => JSRef!.Call<WritableStreamDefaultWriter>("getWriter");
    }
}
