using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    public interface IBlazorJSRuntime
    {
        bool CrossOriginIsolated { get; }
        DedicatedWorkerGlobalScope? DedicateWorkerThis { get; }
        string EnvironmentVersion { get; }
        string FileVersion { get; }
        string FrameworkVersion { get; }
        GlobalScope GlobalScope { get; }
        JSObject GlobalThis { get; }
        string GlobalThisTypeName { get; }
        string InformationalVersion { get; }
        bool IsDedicatedWorkerGlobalScope { get; }
        bool IsServiceWorkerGlobalScope { get; }
        bool IsSharedWorkerGlobalScope { get; }
        bool IsWindow { get; }
        bool IsWorker { get; }
        ServiceWorkerGlobalScope? ServiceWorkerThis { get; }
        SharedWorkerGlobalScope? SharedWorkerThis { get; }
        Window? WindowThis { get; }

        object? Call(Type returnType, object identifier);
        object? Call(Type returnType, object identifier, object? arg0);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8);
        object? Call(Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9);
        T Call<T>(object identifier);
        T Call<T>(object identifier, object? arg0);
        T Call<T>(object identifier, object? arg0, object? arg1);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8);
        T Call<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9);
        object? CallApply(Type returnType, object identifier, object?[]? args = null);
        T CallApply<T>(object identifier, object?[]? args = null);
        Task<T> CallApplyAsync<T>(object identifier, object?[]? args = null);
        void CallApplyVoid(object identifier, object?[]? args = null);
        Task CallApplyVoidAsync(object identifier, object?[]? args = null);
        Task<T> CallAsync<T>(object identifier);
        Task<T> CallAsync<T>(object identifier, object? arg0);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8);
        Task<T> CallAsync<T>(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9);
        void CallVoid(object identifier);
        void CallVoid(object identifier, object? arg0);
        void CallVoid(object identifier, object? arg0, object? arg1);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2, object? arg3);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8);
        void CallVoid(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9);
        Task CallVoidAsync(object identifier);
        Task CallVoidAsync(object identifier, object? arg0);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2, object? arg3);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8);
        Task CallVoidAsync(object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9);
        bool Delete(object identifier);
        void DisposeCallback(string callbackerID);
        void DocumentBodyAppendChild(IJSInProcessObjectReference element);
        IJSInProcessObjectReference DocumentCreateElement(string elementType);
        T DocumentCreateElement<T>(string elementType) where T : JSObject;
        void DocumentHeadAppendChild(IJSInProcessObjectReference element);
        Task<Response> Fetch(Request resource);
        Task<Response> Fetch(string resource);
        Task<Response> Fetch(string resource, FetchOptions options);
        JSObject FromElementReference(ElementReference elementRef);
        T FromElementReference<T>(ElementReference elementRef) where T : JSObject;
        object? Get(Type returnType, object identifier);
        T Get<T>(object identifier);
        Task<T> GetAsync<T>(object identifier);
        IJSInProcessObjectReference GetDocument();
        T GetDocument<T>() where T : JSObject;
        IJSInProcessObjectReference GetDocumentBody();
        T GetDocumentBody<T>() where T : JSObject;
        IJSInProcessObjectReference GetDocumentHead();
        T GetDocumentHead<T>() where T : JSObject;
        IJSInProcessObjectReference GetWindow();
        T GetWindow<T>() where T : JSObject;
        bool IfScope(GlobalScope scope, Action method);
        Task<bool> IfScopeAsync(GlobalScope scope, Func<Task> method);
        Task<ModuleNamespaceObject?> Import(string moduleName);
        bool IsDisplayModeStandalone();
        bool IsScope(GlobalScope scope);
        bool IsUndefined(string identifier);
        Task<bool> LoadScript(string src, string? ifThisGlobalVarIsUndefined = null);
        void LoadScript(string src, Action<bool> callback);
        Task LoadScripts(string[] sources);
        void Log(params object?[] args);
        IJSInProcessObjectReference New(string className);
        IJSInProcessObjectReference New(string className, object arg0);
        IJSInProcessObjectReference New(string className, object arg0, object arg1);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8);
        IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9);
        IJSInProcessObjectReference NewApply(string className, object?[]? args = null);
        T ReturnMe<T>(object obj);
        T ReturnMe<T>(T obj);
        void Set(object identifier, object? value);
        void SetTimeout(Action callback, int msDelay);
        void SetTimeout(Callback callback, int msDelay);
        IJSInProcessObjectReference ToJSRef(ElementReference elementRef);
        string TypeOf(string identifier);
    }
}