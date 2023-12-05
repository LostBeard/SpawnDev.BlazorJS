using System.Runtime.CompilerServices;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class BackgroundWorkerPool : WebWorkerPool, IBackgroundService
    {
        public static BackgroundWorkerPool Instance { get; private set; }
        public static bool IsWindow { get; private set; }
        public static bool IsDedicatedWorker { get; private set; }
        BlazorJSRuntime JS;
        public BackgroundWorkerPool(BlazorJSRuntime js, WebWorkerService webWorkerService) : base(webWorkerService)
        {
            Instance = this;
            JS = js;
            // if running in the Window scope, some workers are started automatically
            IsWindow = JS.IsWindow;
            IsDedicatedWorker = JS.IsDedicatedWorkerGlobalScope;
            if (IsWindow)
            {
                WorkerCountRequest = 4;
            }
            else
            {
                IsDedicatedWorker = true;
            }
        }

        public static async Task<T> WorkerRun<T>(Delegate methodDelegate, object?[]? args = null)
        {
            return (T)await WorkerRun(methodDelegate, args);
        }
        public static async Task<object?> WorkerRun(Delegate methodDelegate, object?[]? args = null)
        {
            if (!methodDelegate.Method.IsStatic)
            {
                throw new NotImplementedException($"Only static methods can be called using {nameof(BackgroundWorkerPool)}");
            }
            if (IsDedicatedWorker)
            {
                return await methodDelegate.Method.InvokeAsync(null, args);
            }
            else
            {
                var worker = await Instance.GetFreeWorkerAsync();
                if (worker != null)
                {
                    try
                    {
                        return await worker.CallAsync(methodDelegate, args);
                    }
                    finally
                    {
                        Instance.ReleaseIdleWorker(worker);
                    }
                }
                else
                {
                    throw new NullReferenceException("Get worker failed.");
                }
            }
        }
        public static async Task<T> WindowRun<T>(Delegate methodDelegate, object?[]? args = null)
        {
            return (T)await WindowRun(methodDelegate, args);
        }
        public static async Task<object?> WindowRun(Delegate methodDelegate, object?[]? args = null)
        {
            if (!methodDelegate.Method.IsStatic)
            {
                throw new NotImplementedException($"Only static methods can be called using {nameof(BackgroundWorkerPool)}");
            }
            if (IsWindow)
            {
                return await methodDelegate.Method.InvokeAsync(null, args);
            }
            else
            {
                var worker = Instance.WebWorkerService.DedicatedWorkerParent;
                return await worker.CallAsync(methodDelegate, args);
            }
        }
        
        // Window
        // Action
        public static async Task WindowInvoke(Action methodDelegate)
            => await WindowRun(methodDelegate, null);
        public static Task WindowInvoke<T0>(Action<T0> methodDelegate, T0 arg0)
            => WindowRun(methodDelegate, new object[] { arg0 });
        public static Task WindowInvoke<T0, T1>(Action<T0, T1> methodDelegate, T0 arg0, T1 arg1)
            => WindowRun(methodDelegate, new object[] { arg0, arg1 });
        public static Task WindowInvoke<T0, T1, T2>(Action<T0, T1, T2> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2 });
        public static Task WindowInvoke<T0, T1, T2, T3>(Action<T0, T1, T2, T3> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public static Task WindowInvoke<T0, T1, T2, T3, T4>(Action<T0, T1, T2, T3, T4> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static Task WindowInvoke<T0, T1, T2, T3, T4, T5>(Action<T0, T1, T2, T3, T4, T5> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static Task WindowInvoke<T0, T1, T2, T3, T4, T5, T6>(Action<T0, T1, T2, T3, T4, T5, T6> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static Task WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7>(Action<T0, T1, T2, T3, T4, T5, T6, T7> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static Task WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static Task WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static Task WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // Func
        public static async Task<TResult> WindowInvoke<TResult>(Func<TResult> methodDelegate)
            => (TResult)await WindowRun(methodDelegate, null);
        public static async Task<TResult> WindowInvoke<T0, TResult>(Func<T0, TResult> methodDelegate, T0 arg0)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0 });
        public static async Task<TResult> WindowInvoke<T0, T1, TResult>(Func<T0, T1, TResult> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, TResult>(Func<T0, T1, T2, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // AsyncFunc
        public static async Task WindowInvoke<TResult>(Func<Task> methodDelegate)
            => await WindowRun(methodDelegate, null);
        public static async Task<TResult> WindowInvoke<TResult>(Func<Task<TResult>> methodDelegate)
            => (TResult)await WindowRun(methodDelegate, null);
        public static async Task<TResult> WindowInvoke<T0, TResult>(Func<T0, Task<TResult>> methodDelegate, T0 arg0)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0 });
        public static async Task<TResult> WindowInvoke<T0, T1, TResult>(Func<T0, T1, Task<TResult>> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, TResult>(Func<T0, T1, T2, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static async Task<TResult> WindowInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await WindowRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // Worker
        // Action
        public static async Task WorkerInvoke(Action methodDelegate)
            => await WorkerRun(methodDelegate, null);
        public static Task WorkerInvoke<T0>(Action<T0> methodDelegate, T0 arg0)
            => WorkerRun(methodDelegate, new object[] { arg0 });
        public static Task WorkerInvoke<T0, T1>(Action<T0, T1> methodDelegate, T0 arg0, T1 arg1)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1 });
        public static Task WorkerInvoke<T0, T1, T2>(Action<T0, T1, T2> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2 });
        public static Task WorkerInvoke<T0, T1, T2, T3>(Action<T0, T1, T2, T3> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public static Task WorkerInvoke<T0, T1, T2, T3, T4>(Action<T0, T1, T2, T3, T4> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static Task WorkerInvoke<T0, T1, T2, T3, T4, T5>(Action<T0, T1, T2, T3, T4, T5> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static Task WorkerInvoke<T0, T1, T2, T3, T4, T5, T6>(Action<T0, T1, T2, T3, T4, T5, T6> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static Task WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7>(Action<T0, T1, T2, T3, T4, T5, T6, T7> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static Task WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static Task WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static Task WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // Func
        public static async Task<TResult> WorkerInvoke<TResult>(Func<TResult> methodDelegate)
            => (TResult)await WorkerRun(methodDelegate, null);
        public static async Task<TResult> WorkerInvoke<T0, TResult>(Func<T0, TResult> methodDelegate, T0 arg0)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0 });
        public static async Task<TResult> WorkerInvoke<T0, T1, TResult>(Func<T0, T1, TResult> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, TResult>(Func<T0, T1, T2, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // AsyncFunc
        public static async Task WorkerInvoke<TResult>(Func<Task> methodDelegate)
            => await WorkerRun(methodDelegate, null);
        public static async Task<TResult> WorkerInvoke<TResult>(Func<Task<TResult>> methodDelegate)
            => (TResult)await WorkerRun(methodDelegate, null);
        public static async Task<TResult> WorkerInvoke<T0, TResult>(Func<T0, Task<TResult>> methodDelegate, T0 arg0)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0 });
        public static async Task<TResult> WorkerInvoke<T0, T1, TResult>(Func<T0, T1, Task<TResult>> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, TResult>(Func<T0, T1, T2, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static async Task<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // AsyncFunc
        public static async ValueTask WorkerInvoke<TResult>(Func<ValueTask> methodDelegate)
            => await WorkerRun(methodDelegate, null);
        public static async ValueTask<TResult> WorkerInvoke<TResult>(Func<ValueTask<TResult>> methodDelegate)
            => (TResult)await WorkerRun(methodDelegate, null);
        public static async ValueTask<TResult> WorkerInvoke<T0, TResult>(Func<T0, ValueTask<TResult>> methodDelegate, T0 arg0)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, TResult>(Func<T0, T1, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, TResult>(Func<T0, T1, T2, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static async ValueTask<TResult> WorkerInvoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await WorkerRun(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

    }
}
