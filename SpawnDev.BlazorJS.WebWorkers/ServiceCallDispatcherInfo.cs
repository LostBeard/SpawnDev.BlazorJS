namespace SpawnDev.BlazorJS.WebWorkers
{
    //internal class WebWorkerCallMessageTask
    //{
    //    public TaskCompletionSource<Array> TaskCompletionSource { get; } = new TaskCompletionSource<Array>();
    //    //public string RequestId => webWorkerCallMessageOutgoing.RequestId;
    //    //public Action<Array>? OnComplete { get; set; }
    //    //public CancellationToken? CancellationToken { get; set; }
    //    //public WebWorkerMessageOut webWorkerCallMessageOutgoing { get; set; }
    //    //public WebWorkerCallMessageTask(Action<Array>? onComplete)
    //    //{
    //    //    OnComplete = onComplete;
    //    //}
    //}
    public class ServiceCallDispatcherInfo
    {
        public string InstanceId { get; init; } = "";
        public string GlobalThisTypeName { get; init; } = "";
    }
}
