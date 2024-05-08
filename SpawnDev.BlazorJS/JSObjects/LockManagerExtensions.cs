namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Adds extension methods to LockManager
    /// </summary>
    public static class LockManagerExtensions
    {
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
            {;
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
    }
}
