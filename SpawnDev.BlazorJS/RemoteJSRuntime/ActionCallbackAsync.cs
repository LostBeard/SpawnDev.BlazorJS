using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    public class ActionCallbackAsync : CallbackAsync
    {
        Func<Task> Target;
        public ActionCallbackAsync(IJSRuntime jsr, Func<Task> target, bool once = false) : base(jsr, once)
        {
            Target = target;
        }
        [JSInvokable]
        public async Task InvokeAsync()
        {
            await Target();
            if (once) await DisposeAsync();
        }
    }
    public class ActionCallbackAsync<T1> : CallbackAsync
    {
        Func<T1, Task> Target;
        public ActionCallbackAsync(IJSRuntime jsr, Func<T1, Task> target, bool once = false) : base(jsr, once)
        {
            Target = target;
        }
        [JSInvokable]
        public async Task InvokeAsync(T1 arg1)
        {
            await Target(arg1);
            if (once) await DisposeAsync();
        }
    }
    public class ActionCallbackAsync<T1, T2> : CallbackAsync
    {
        Func<T1, T2, Task> Target;
        public ActionCallbackAsync(IJSRuntime jsr, Func<T1, T2, Task> target, bool once = false) : base(jsr, once)
        {
            Target = target;
        }
        [JSInvokable]
        public async Task InvokeAsync(T1 arg1, T2 arg2)
        {
            await Target(arg1, arg2);
            if (once) await DisposeAsync();
        }
    }
}
