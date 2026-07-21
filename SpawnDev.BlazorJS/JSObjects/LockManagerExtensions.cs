namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Adds extension methods to LockManager
    /// </summary>
    public static class LockManagerExtensions
    {
        // A LockManager snapshot comes from Javascript, where "held" and "pending" can be absent and a
        // LockInfo can carry no clientId. These two keep that reality in one place so each query below
        // reads as the question it is asking.
        private static IEnumerable<LockInfo> OrEmpty(this LockInfo[]? locks) => locks ?? Enumerable.Empty<LockInfo>();

        private static string[] ClientIds(this IEnumerable<LockInfo> locks)
            => locks.Select(o => o.ClientId).Where(id => id != null).Select(id => id!).Distinct().ToArray();

        private static void ContinueWith(TaskCompletionSource lockWait, Task t)
        {
            if (!t.IsCompletedSuccessfully && !lockWait.Task.IsCompleted)
            {
                lockWait.TrySetException(new Exception("Failed to acquire lock"));
            }
        }
        /// <summary>
        /// Once the lock is acquired, a TaskCompletionSource is returned. The lock will be held until TaskCompletionSource completes
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<TaskCompletionSource> RequestHandle(this LockManager _this, string lockName, LockRequestOptions options)
        {
            var lockWait = new TaskCompletionSource();
            var ret = new TaskCompletionSource();
            _ = _this.Request(lockName, options, () =>
            {
                lockWait.SetResult();
                return ret.Task;
            }).ContinueWith(t => ContinueWith(lockWait, t));
            await lockWait.Task;
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<TaskCompletionSource<TResult>> RequestHandle<TResult>(this LockManager _this, string lockName, LockRequestOptions options)
        {
            var lockWait = new TaskCompletionSource();
            var ret = new TaskCompletionSource<TResult>();
            _ = _this.Request(lockName, options, () =>
            {
                ;
                lockWait.SetResult();
                return ret.Task;
            }).ContinueWith(t => ContinueWith(lockWait, t));
            await lockWait.Task;
            return ret;
        }
        /// <summary>
        /// Once the lock is acquired, a TaskCompletionSource is returned. The lock will be held until TaskCompletionSource completes
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <returns></returns>
        public static async Task<TaskCompletionSource> RequestHandle(this LockManager _this, string lockName)
        {
            var lockWait = new TaskCompletionSource();
            var ret = new TaskCompletionSource();
            _ = _this.Request(lockName, () =>
            {
                lockWait.SetResult();
                return ret.Task;
            }).ContinueWith(t => ContinueWith(lockWait, t));
            await lockWait.Task;
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <returns></returns>
        public static async Task<TaskCompletionSource<TResult>> RequestHandle<TResult>(this LockManager _this, string lockName)
        {
            var lockWait = new TaskCompletionSource();
            var ret = new TaskCompletionSource<TResult>();
            _ = _this.Request(lockName, () =>
            {
                lockWait.SetResult();
                return ret.Task;
            }).ContinueWith(t => ContinueWith(lockWait, t));
            await lockWait.Task;
            return ret;
        }
        /// <summary>
        /// Once the lock is acquired, a TaskCompletionSource is returned. The lock will be held until TaskCompletionSource completes
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public static async Task<TaskCompletionSource> RequestHandle(this LockManager _this, string lockName, int millisecondsTimeout)
        {
            var lockWait = new TaskCompletionSource();
            var ret = new TaskCompletionSource();
            using var signal = AbortSignal.Timeout(millisecondsTimeout);
            var options = new LockRequestOptions { Signal = signal };
            _ = _this.Request(lockName, options, () =>
            {
                lockWait.SetResult();
                return ret.Task;
            }).ContinueWith(t => ContinueWith(lockWait, t));
            await lockWait.Task;
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public static async Task<TaskCompletionSource<TResult>> RequestHandle<TResult>(this LockManager _this, string lockName, int millisecondsTimeout)
        {
            var lockWait = new TaskCompletionSource();
            var ret = new TaskCompletionSource<TResult>();
            using var signal = AbortSignal.Timeout(millisecondsTimeout);
            var options = new LockRequestOptions { Signal = signal };
            _ = _this.Request(lockName, options, () =>
            {
                lockWait.SetResult();
                return ret.Task;
            }).ContinueWith(t => ContinueWith(lockWait, t));
            await lockWait.Task;
            return ret;
        }
        /// <summary>
        /// Returns an array of client ids that are holding or waiting for locks
        /// </summary>
        /// <returns></returns>
        public static async Task<string[]> QueryClientIds(this LockManager _this)
        {
            var state = await _this.Query();
            // held/pending may be absent from the Javascript snapshot, and a LockInfo may carry no
            // clientId; the declared string[] promises neither is in the result, so honour that here
            // rather than by annotation
            return state.Held.OrEmpty().Concat(state.Pending.OrEmpty()).ClientIds();
        }
        /// <summary>
        /// Returns an array of clientIds that are holding a given lock name
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <returns></returns>
        public static async Task<string[]> QueryClientIdsHolding(this LockManager _this, string lockName)
        {
            var state = await _this.Query();
            return state.Held.OrEmpty().Where(o => o.Name == lockName).ClientIds();
        }
        /// <summary>
        /// Returns an array of clientIds that are pending a given lock name
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <returns></returns>
        public static async Task<string[]> QueryClientIdsPending(this LockManager _this, string lockName)
        {
            var state = await _this.Query();
            return state.Pending.OrEmpty().Where(o => o.Name == lockName).ClientIds();
        }
        /// <summary>
        /// Returns the clientId of the first holder of a given lock name, or null if none
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="lockName"></param>
        /// <returns></returns>
        public static async Task<string?> QueryClientIdHolding(this LockManager _this, string lockName)
        {
            var state = await _this.Query();
            return state.Held.OrEmpty().FirstOrDefault(o => o.Name == lockName)?.ClientId;
        }
        /// <summary>
        /// Returns the clientId of this instance
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<string> GetClientId(this LockManager _this)
        {
            var lockName = Guid.NewGuid().ToString();
            var handle = await _this.RequestHandle(lockName);
            try
            {
                return (await _this.QueryClientIdHolding(lockName))!;
            }
            finally
            {
                handle.SetResult();
            }
        }
    }
}
