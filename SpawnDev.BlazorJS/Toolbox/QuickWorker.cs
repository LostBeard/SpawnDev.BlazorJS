using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// QuickWorker provides helper methods for running Javascript workers.<br/>
    /// </summary>
    public static class QuickWorker
    {
        /// <summary>
        /// Create a dedicated worker instance from the provided Javascript code string
        /// </summary>
        /// <param name="js">worker script string</param>
        /// <returns>The new Worker</returns>
        public static Worker CreateWorkerFromJS(string js)
        {
            using var blob = new Blob(new string[] { js }, new BlobOptions { Type = "application/javascript" });
            var objUrl = URL.CreateObjectURL(blob);
            var ret = new Worker(objUrl);
            URL.RevokeObjectURL(objUrl);
            return ret;
        }
        /// <summary>
        /// Creates the specified number of workers using the provided Javascript script source
        /// </summary>
        /// <param name="js">worker script string</param>
        /// <param name="count">number of workers to create</param>
        /// <returns>The new Workers</returns>
        public static List<Worker> CreateWorkersFromJS(string js, int count)
        {
            using var blob = new Blob(new string[] { js }, new BlobOptions { Type = "application/javascript" });
            var objUrl = URL.CreateObjectURL(blob);
            var ret = new List<Worker>();
            for (var i =0; i < count; i++)
            {
                ret.Add(new Worker(objUrl));
            }
            URL.RevokeObjectURL(objUrl);
            return ret;
        }

        /// <summary>
        /// When done the worker must postMessage(INSTANCE_OF_Uint8Array, [ INSTANCE_OF_Uint8Array.buffer ])
        /// </summary>
        /// <param name="data"></param>
        /// <param name="js">worker script string</param>
        /// <returns></returns>
        public static Task<byte[]> ProcessData(byte[] data, string js) => ProcessData<byte[]>(data, js);

        /// <summary>
        /// Create a worker that will process the data received in the first message event and postMessage back the result as type TResult.
        /// </summary>
        /// <typeparam name="TResult">The data Type of the result.</typeparam>
        /// <param name="data">data to send to the worker via postMessage</param>
        /// <param name="js">The Javascript source</param>
        /// <returns>The data received from the worker via a message event as type TResult.</returns>
        public static Task<TResult> ProcessData<TResult>(byte[] data, string js)
        {
            using var uint8 = new Uint8Array(data);
            using var buffer = uint8.Buffer;
            return ProcessData<TResult>(js, data, new object[] { buffer });
        }

        /// <summary>
        /// Creates a Worker from the provided Javascript code and sends it the specified data, optionally using transferables<br/>
        /// The first message received from the worker is expected to have the result that will be returned as type TResult.
        /// </summary>
        /// <typeparam name="TResult">The return type of the data the worker will return via postMessage</typeparam>
        /// <param name="js">worker script string</param>
        /// <param name="data">data to send to the worker</param>
        /// <param name="transferables">What data, if any, should be transferred instead of cloned.</param>
        /// <returns></returns>
        public static Task<TResult> ProcessData<TResult>(string js, object data, object[]? transferables = null)
        {
            var sw = Stopwatch.StartNew();
            var t = new TaskCompletionSource<TResult>();
            var worker = CreateWorkerFromJS(js);
            Action<MessageEvent>? msgHandler = null;
            msgHandler = new Action<MessageEvent>((msg) =>
            {
                worker.OnMessage -= msgHandler!; 
                worker.Terminate();
                worker.Dispose();
                var result = msg.GetData<TResult>();
                t.SetResult(result);
#if DEBUG
                Console.WriteLine($"WorkerProcessor finished: {sw.Elapsed.TotalMilliseconds}");
#endif
            });
            worker.OnMessage += msgHandler;
            if (transferables == null)
            {
                worker.PostMessage(data);
            }
            else
            {
                worker.PostMessage(data, transferables);
            }
            return t.Task;
        }

        /// <summary>
        /// Creates a new SharedArrayBuffer and copies the data from the provided ArrayBuffer to it.
        /// </summary>
        /// <param name="arrayBuffer">Source data to copy</param>
        /// <param name="options">Optional SharedArrayBufferOptions</param>
        /// <returns>new SharedArrayBuffer</returns>
        public static SharedArrayBuffer CreateSharedArrayBuffer(ArrayBuffer arrayBuffer, SharedArrayBufferOptions? options = null)
        {
            var ret = options == null ? new SharedArrayBuffer(arrayBuffer.ByteLength) : new SharedArrayBuffer(arrayBuffer.ByteLength, options);
            using var uint8ArraySrc = new Uint8Array(arrayBuffer);
            using var uint8ArrayDest = new Uint8Array(ret);
            uint8ArrayDest.Set(uint8ArraySrc);
            return ret;
        }

        /// <summary>
        /// Creates a new SharedArrayBuffer, copies the data from the provided Uint8Array to it, and returns a new Uint8Array view of the SharedArrayBuffer.<br/>
        /// </summary>
        /// <param name="uint8ArraySrc">Source data to copy</param>
        /// <param name="options">Optional SharedArrayBufferOptions</param>
        /// <returns>new Uint8Array with an SharedArrayBuffer buffer</returns>
        public static Uint8Array CreateNewSharedUint8Array(Uint8Array uint8ArraySrc, SharedArrayBufferOptions? options = null)
        {
            using var ret = options == null ? new SharedArrayBuffer(uint8ArraySrc.Length) : new SharedArrayBuffer(uint8ArraySrc.Length, options);
            var uint8ArrayDest = new Uint8Array(ret);
            uint8ArrayDest.Set(uint8ArraySrc);
            return uint8ArrayDest;
        }

        /// <summary>
        /// Creates a new SharedArrayBuffer, copies the data from the provided byte[] to it, and returns a new Uint8Array view of the SharedArrayBuffer.<br/>
        /// </summary>
        /// <param name="uint8ArraySrc">Source data to copy</param>
        /// <param name="options">Optional SharedArrayBufferOptions</param>
        /// <returns>new Uint8Array with an SharedArrayBuffer buffer</returns>
        public static Uint8Array CreateNewSharedUint8Array(byte[] uint8ArraySrc, SharedArrayBufferOptions? options = null)
        {
            using var ret = options == null ? new SharedArrayBuffer(uint8ArraySrc.Length) : new SharedArrayBuffer(uint8ArraySrc.Length, options);
            var uint8ArrayDest = new Uint8Array(ret);
            uint8ArrayDest.Set(uint8ArraySrc);
            return uint8ArrayDest;
        }


        /// <summary>
        /// The worker message data property will be an array with the values [ WORKER_INDEX, WORKER_COUNT, SharedArrayBuffer ]
        /// this function could check if SharedArrayBuffer and Passing it to workers is supported and force a count of 1 and disable SharedArrayBuffer if needed
        /// but that would require the script to know that and work differently
        /// </summary>
        /// <param name="js"></param>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static async Task<byte[]> ParallelProcessData(string js, byte[] data, int count = 4)
        {
            using var sharedUint8Array = CreateNewSharedUint8Array(data);
            var workers = CreateWorkersFromJS(js, count);
            var tasks = new List<Task>();
            for(var i=0; i < workers.Count; i++)
            {
                var worker = workers[i];
                var t = new TaskCompletionSource();
                Action<MessageEvent>? msgHandler = null;
                msgHandler = new Action<MessageEvent>((msg) =>
                {
                    worker.OnMessage -= msgHandler!;
                    worker.Terminate();
                    worker.Dispose();
                    t.SetResult();
                });
                worker.OnMessage += msgHandler;
                worker.PostMessage(new object[] { i, count, sharedUint8Array });
                tasks.Add(t.Task);
            }
            await Task.WhenAll(tasks);
            data = sharedUint8Array.ReadBytes();
            return data;
        }
        // Demo of ParallelProcessData where each worker only modifies byte indexes specific to its index
        //var testData = new byte[1024];
        //var test1 = await QuickWorker.ParallelProcessData(@"
        //self.onmessage = function({ data }) {
        //    var index = data[0];                // this worker's index (0 based)
        //    var count = data[1];                // parallel worker count
        //    var sharedUint8Array = data[2];     // SharedUint8Array
        //    //console.log('ParallelProcessData >>', index, count);
        //    for (var i = index; i < sharedUint8Array.length; i += count)
        //    {
        //        sharedUint8Array[i] = index;
        //    }
        //    //console.log('ParallelProcessData <<', index, count);
        //    self.postMessage(true);
        //}
        //", testData, 4);
        //// test1 = [ 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, ...];
    }
}
