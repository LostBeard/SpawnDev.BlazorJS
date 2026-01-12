using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    /// <summary>
    /// Async callback wrapper for Action
    /// </summary>
    public class ActionCallbackAsync : CallbackAsync
    {
        Func<Task> Target;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="jsr"></param>
        /// <param name="target"></param>
        /// <param name="once"></param>
        public ActionCallbackAsync(IJSRuntime jsr, Func<Task> target, bool once = false) : base(jsr, once)
        {
            Target = target;
        }
        /// <summary>
        /// Invokes the callback
        /// </summary>
        [JSInvokable]
        public async Task InvokeAsync()
        {
            await Target();
            if (once) await DisposeAsync();
        }
    }
    /// <summary>
    /// Async callback wrapper for Action
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public class ActionCallbackAsync<T1> : CallbackAsync
    {
        Func<T1, Task> Target;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="jsr"></param>
        /// <param name="target"></param>
        /// <param name="once"></param>
        public ActionCallbackAsync(IJSRuntime jsr, Func<T1, Task> target, bool once = false) : base(jsr, once)
        {
            Target = target;
        }
        /// <summary>
        /// Invokes the callback
        /// </summary>
        /// <param name="arg1"></param>
        [JSInvokable]
        public async Task InvokeAsync(T1 arg1)
        {
            await Target(arg1);
            if (once) await DisposeAsync();
        }
    }
    /// <summary>
    /// Async callback wrapper for Action
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class ActionCallbackAsync<T1, T2> : CallbackAsync
    {
        Func<T1, T2, Task> Target;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="jsr"></param>
        /// <param name="target"></param>
        /// <param name="once"></param>
        public ActionCallbackAsync(IJSRuntime jsr, Func<T1, T2, Task> target, bool once = false) : base(jsr, once)
        {
            Target = target;
        }
        /// <summary>
        /// Invokes the callback
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        [JSInvokable]
        public async Task InvokeAsync(T1 arg1, T2 arg2)
        {
            await Target(arg1, arg2);
            if (once) await DisposeAsync();
        }
    }
}
