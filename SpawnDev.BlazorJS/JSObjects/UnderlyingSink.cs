using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WritableStream() constructor accepts as its first argument a JavaScript object representing the underlying sink. Such objects can contain any of the following properties:<br/>
    /// https://streams.spec.whatwg.org/#underlying-sink-api<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WritableStream/WritableStream#underlyingsink
    /// </summary>
    public class UnderlyingSink
    {
        /// <summary>
        /// A function that is called immediately during creation of the WritableStream.
        /// Typically this is used to acquire access to the underlying sink resource being represented.
        /// If this setup process is asynchronous, it can return a promise to signal success or failure; a rejected promise will error the stream. Any thrown exceptions will be re-thrown by the WritableStream() constructor.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FuncCallback<WritableStreamDefaultController, Task>? Start { get; set; }
        /// <summary>
        /// A function that is called when a new chunk of data is ready to be written to the underlying sink. The stream implementation guarantees that this function will be called only after previous writes have succeeded, and never before start() has succeeded or after close() or abort() have been called.
        /// This function is used to actually send the data to the resource presented by the underlying sink, for example by calling a lower-level API.
        /// If the process of writing data is asynchronous, and communicates success or failure signals back to its user, then this function can return a promise to signal success or failure.This promise return value will be communicated back to the caller of writer.write(), so they can monitor that individual write.Throwing an exception is treated the same as returning a rejected promise.
        /// Note that such signals are not always available; compare e.g. § 10.6 A writable stream with no backpressure or success signals with § 10.7 A writable stream with backpressure and success signals. In such cases, it’s best to not return anything.
        /// The promise potentially returned by this function also governs whether the given chunk counts as written for the purposes of computed the desired size to fill the stream’s internal queue.That is, during the time it takes the promise to settle, writer.desiredSize will stay at its previous value, only increasing to signal the desire for more chunks once the write succeeds.
        /// Finally, the promise potentially returned by this function is used to ensure that well-behaved producers do not attempt to mutate the chunk before it has been fully processed. (This is not guaranteed by any specification machinery, but instead is an informal contract between producers and the underlying sink.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FuncCallback<JSObject, WritableStreamDefaultController, Task>? Write { get; set; }
        /// <summary>
        /// A function that is called after the producer signals, via writer.close(), that they are done writing chunks to the stream, and subsequently all queued-up writes have successfully completed.
        /// This function can perform any actions necessary to finalize or flush writes to the underlying sink, and release access to any held resources.
        /// If the shutdown process is asynchronous, the function can return a promise to signal success or failure; the result will be communicated via the return value of the called writer.close() method.Additionally, a rejected promise will error the stream, instead of letting it close successfully. Throwing an exception is treated the same as returning a rejected promise.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FuncCallback<Task>? Close { get; set; }
        /// <summary>
        /// A function that is called after the producer signals, via stream.abort() or writer.abort(), that they wish to abort the stream. It takes as its argument the same value as was passed to those methods by the producer.
        /// Writable streams can additionally be aborted under certain conditions during piping; see the definition of the pipeTo() method for more details.
        /// This function can clean up any held resources, much like close(), but perhaps with some custom handling.
        /// If the shutdown process is asynchronous, the function can return a promise to signal success or failure; the result will be communicated via the return value of the called writer.abort() method.Throwing an exception is treated the same as returning a rejected promise. Regardless, the stream will be errored with a new TypeError indicating that it was aborted.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FuncCallback<JSObject?, Task>? Abort { get; set; }
    }
}
