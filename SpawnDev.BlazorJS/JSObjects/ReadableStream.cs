﻿using Microsoft.JSInterop;
using System.IO.Pipelines;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ReadableStream interface of the Streams API represents a readable stream of byte data. The Fetch API offers a concrete instance of a ReadableStream through the body property of a Response object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream
    /// </summary>
    [Transferable]
    public class ReadableStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ReadableStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates and returns a readable stream object from the given handlers.
        /// </summary>
        public ReadableStream() : base(JS.New(nameof(ReadableStream))) { }
        /// <summary>
        /// Creates and returns a readable stream object from the given handlers.
        /// </summary>
        /// <param name="underlyingSource"></param>
        public ReadableStream(ReadableStreamUnderlyingSource underlyingSource) : base(JS.New(nameof(ReadableStream), underlyingSource)) { }
        /// <summary>
        /// Returns a boolean indicating whether or not the readable stream is locked to a reader.
        /// </summary>
        public bool Locked => JSRef!.Get<bool>("locked");
        /// <summary>
        /// Returns a Promise that resolves when the stream is canceled. Calling this method signals a loss of interest in the stream by a consumer. The supplied reason argument will be given to the underlying source, which may or may not use it.
        /// </summary>
        /// <returns></returns>
        public Task Cancel() => JSRef!.CallVoidAsync("cancel");
        /// <summary>
        /// Returns a Promise that resolves when the stream is canceled. Calling this method signals a loss of interest in the stream by a consumer. The supplied reason argument will be given to the underlying source, which may or may not use it.
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        public Task Cancel(string reason) => JSRef!.CallVoidAsync("cancel", reason);
        /// <summary>
        /// Creates a reader and locks the stream to it. While the stream is locked, no other reader can be acquired until this one is released.
        /// </summary>
        /// <returns></returns>
        public ReadableStreamDefaultReader GetReader() => JSRef!.Call<ReadableStreamDefaultReader>("getReader");
        /// <summary>
        /// The pipeTo() method of the ReadableStream interface pipes the current ReadableStream to a given WritableStream and returns a Promise that fulfills when the piping process completes successfully, or rejects if any errors were encountered.<br/>
        /// Piping a stream will generally lock it for the duration of the pipe, preventing other readers from locking it.<br/>
        /// </summary>
        /// <param name="destination">A WritableStream that acts as the final destination for the ReadableStream.</param>
        /// <returns>A Promise that resolves when the piping process has completed.</returns>
        public Task PipeTo(WritableStream destination) => JSRef!.CallVoidAsync("pipeTo", destination);
        /// <summary>
        /// The pipeTo() method of the ReadableStream interface pipes the current ReadableStream to a given WritableStream and returns a Promise that fulfills when the piping process completes successfully, or rejects if any errors were encountered.<br/>
        /// Piping a stream will generally lock it for the duration of the pipe, preventing other readers from locking it.<br/>
        /// </summary>
        /// <param name="destination">A WritableStream that acts as the final destination for the ReadableStream.</param>
        /// <param name="options">PipeToOptions</param>
        /// <returns>A Promise that resolves when the piping process has completed.</returns>
        public Task PipeTo(WritableStream destination, PipeToOptions options) => JSRef!.CallVoidAsync("pipeTo", destination, options);
    }
}
