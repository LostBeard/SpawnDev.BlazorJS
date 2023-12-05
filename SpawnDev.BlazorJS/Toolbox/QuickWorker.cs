using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class QuickWorker
    {
        /// <summary>
        /// Create a dedicated worker instance from the provided Javascript code string
        /// </summary>
        /// <param name="js"></param>
        /// <returns></returns>
        public static Worker CreateWorkerFromJS(string js)
        {
            using var blob = new Blob(new string[] { js }, new BlobOptions { Type = "application/javascript" });
            var objUrl = URL.CreateObjectURL(blob);
            var ret = new Worker(objUrl);
            URL.RevokeObjectURL(objUrl);
            return ret;
        }
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
        /// <param name="js"></param>
        /// <returns></returns>
        public static Task<byte[]> ProcessData(byte[] data, string js) => ProcessData<byte[]>(data, js);
        public static Task<TResult> ProcessData<TResult>(byte[] data, string js)
        {
            using var uint8 = new Uint8Array(data);
            using var buffer = uint8.Buffer;
            return ProcessData<TResult>(js, data, new object[] { buffer });
        }

        /// <summary>
        /// Creates a Worker from the provided Javascript code and sends it the data optionally using transferables
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="js"></param>
        /// <param name="data"></param>
        /// <param name="transferables"></param>
        /// <returns></returns>
        public static Task<TResult> ProcessData<TResult>(string js, object data, object[]? transferables = null)
        {
            var sw = Stopwatch.StartNew();
            var t = new TaskCompletionSource<TResult>();
            var worker = CreateWorkerFromJS(js);
            Action<MessageEvent>? msgHandler = null;
            msgHandler = new Action<MessageEvent>((msg) =>
            {
                worker.OnMessage -= msgHandler; 
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
        public static SharedArrayBuffer CreateSharedArrayBuffer(ArrayBuffer arrayBuffer, SharedArrayBufferOptions? options = null)
        {
            var ret = new SharedArrayBuffer(arrayBuffer.ByteLength, options);
            using var uint8ArraySrc = new Uint8Array(arrayBuffer);
            using var uint8ArrayDest = new Uint8Array(ret);
            uint8ArrayDest.Set(uint8ArraySrc);
            return ret;
        }
        public static Uint8Array CreateNewSharedUint8Array(Uint8Array uint8ArraySrc, SharedArrayBufferOptions? options = null)
        {
            using var ret = new SharedArrayBuffer(uint8ArraySrc.Length, options);
            var uint8ArrayDest = new Uint8Array(ret);
            uint8ArrayDest.Set(uint8ArraySrc);
            return uint8ArrayDest;
        }
        public static Uint8Array CreateNewSharedUint8Array(byte[] uint8ArraySrc, SharedArrayBufferOptions? options = null)
        {
            using var ret = new SharedArrayBuffer(uint8ArraySrc.Length, options);
            var uint8ArrayDest = new Uint8Array(ret);
            uint8ArrayDest.Set(uint8ArraySrc);
            return uint8ArrayDest;
        }

        // the worker message data property will be an array with the values [ WORKER_INDEX, WORKER_COUNT, SharedArrayBuffer ]
        // this function could check if SharedArrayBuffer and Passing it to workers is supported and force a count of 1 and disable SharedArrayBuffer if needed
        // but that would require the script to know that and work differently
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
                    worker.OnMessage -= msgHandler;
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
