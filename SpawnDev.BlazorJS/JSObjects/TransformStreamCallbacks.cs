using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for the TransformStream constructor.<br/>
    /// </summary>
    public class TransformStreamCallbacks : IDisposable
    {
        /// <summary>
        /// Called when the TransformStream is constructed. It is typically used to enqueue chunks using TransformStreamDefaultController.enqueue().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Callback? Start { get; protected set; }
        /// <summary>
        /// Called when a chunk written to the writable side is ready to be transformed, and performs the work of the transformation stream. It can return a promise to signal success or failure of the write operation. If no transform() method is supplied, the identity transform is used, and the chunk will be enqueued with no changes.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Callback? Transform { get; protected set; }
        /// <summary>
        /// Called after all chunks written to the writable side have been successfully transformed, and the writable side is about to be closed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Callback? Flush { get; protected set; }
        /// <summary>
        /// Creates a new instance of TransformerAsync with the specified callbacks.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="transform"></param>
        /// <param name="flush"></param>
        public TransformStreamCallbacks(Func<TransformStreamDefaultController, Task>? start = null, Func<JSObject, TransformStreamDefaultController, Task>? transform = null, Func<TransformStreamDefaultController, Task>? flush = null)
        {
            Start = start != null ? new FuncCallback<TransformStreamDefaultController, Task>(start) : null;
            Transform = transform != null ? new FuncCallback<JSObject, TransformStreamDefaultController, Task>(transform) : null;
            Flush = flush != null ? new FuncCallback<TransformStreamDefaultController, Task>(flush) : null;
        }
        /// <summary>
        /// Creates a new instance of TransformerAsync with the specified callbacks.
        /// </summary>
        public TransformStreamCallbacks(Func<TransformStreamDefaultController, Task>? start = null, Func<VideoFrame, TransformStreamDefaultController, Task>? transform = null, Func<TransformStreamDefaultController, Task>? flush = null)
        {
            Start = start != null ? new FuncCallback<TransformStreamDefaultController, Task>(start) : null;
            Transform = transform != null ? new FuncCallback<VideoFrame, TransformStreamDefaultController, Task>(transform) : null;
            Flush = flush != null ? new FuncCallback<TransformStreamDefaultController, Task>(flush) : null;
        }
        /// <summary>
        /// Creates a new instance of TransformerAsync with the specified callbacks.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="transform"></param>
        /// <param name="flush"></param>
        public TransformStreamCallbacks(Action<TransformStreamDefaultController>? start = null, Action<JSObject, TransformStreamDefaultController>? transform = null, Action<TransformStreamDefaultController>? flush = null)
        {
            Start = start != null ? new ActionCallback<TransformStreamDefaultController>(start) : null;
            Transform = transform != null ? new ActionCallback<JSObject, TransformStreamDefaultController>(transform) : null;
            Flush = flush != null ? new ActionCallback<TransformStreamDefaultController>(flush) : null;
        }
        /// <summary>
        /// Creates a new instance of TransformerAsync with the specified callbacks.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="transform"></param>
        /// <param name="flush"></param>
        public TransformStreamCallbacks(Action<TransformStreamDefaultController>? start = null, Action<VideoFrame, TransformStreamDefaultController>? transform = null, Action<TransformStreamDefaultController>? flush = null)
        {
            Start = start != null ? new ActionCallback<TransformStreamDefaultController>(start) : null;
            Transform = transform != null ? new ActionCallback<VideoFrame, TransformStreamDefaultController>(transform) : null;
            Flush = flush != null ? new ActionCallback<TransformStreamDefaultController>(flush) : null;
        }
        ///<inheritdoc/>
        protected TransformStreamCallbacks()
        {
            // Protected constructor for derived classes
        }
        /// <inheritdoc/>
        public void Dispose()
        {
            Start?.Dispose();
            Start = null;
            Transform?.Dispose();
            Transform = null;
            Flush?.Dispose();
            Flush = null;
        }
    }
    /// <summary>
    /// Options for the TransformStream constructor.<br/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TransformStreamCallbacks<T> : TransformStreamCallbacks
    {
        /// <summary>
        /// Creates a new instance of TransformerAsync with the specified callbacks.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="transform"></param>
        /// <param name="flush"></param>
        public TransformStreamCallbacks(Func<TransformStreamDefaultController, Task>? start = null, Func<T, TransformStreamDefaultController, Task>? transform = null, Func<TransformStreamDefaultController, Task>? flush = null) : base()
        {
            Start = start != null ? new FuncCallback<TransformStreamDefaultController, Task>(start) : null;
            Transform = transform != null ? new FuncCallback<T, TransformStreamDefaultController, Task>(transform) : null;
            Flush = flush != null ? new FuncCallback<TransformStreamDefaultController, Task>(flush) : null;
        }
        /// <summary>
        /// Creates a new instance of TransformerAsync with the specified callbacks.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="transform"></param>
        /// <param name="flush"></param>
        public TransformStreamCallbacks(Action<TransformStreamDefaultController>? start = null, Action<T, TransformStreamDefaultController>? transform = null, Action<TransformStreamDefaultController>? flush = null)
        {
            Start = start != null ? new ActionCallback<TransformStreamDefaultController>(start) : null;
            Transform = transform != null ? new ActionCallback<T, TransformStreamDefaultController>(transform) : null;
            Flush = flush != null ? new ActionCallback<TransformStreamDefaultController>(flush) : null;
        }
    }
}
