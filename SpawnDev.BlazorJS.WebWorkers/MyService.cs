namespace SpawnDev.BlazorJS.WebWorkers
{
    public class MyService
    {
        WebWorkerService WebWorkerService;
        public MyService(WebWorkerService webWorkerService)
        {
            WebWorkerService = webWorkerService;
        }
        string WorkerMethod(string input)
        {
            return $"Hello {input} from {WebWorkerService.InstanceId}";
        }
        public async Task CallWorkerMethod()
        {
            // Call the private method WorkerMethod on this scope (normal)
            Console.WriteLine(WorkerMethod(WebWorkerService.InstanceId));

            // Call the private method WorkerMethod in a WebWorker thread using an Expression
            Console.WriteLine(await WebWorkerService.TaskPool.Run(() => WorkerMethod(WebWorkerService.InstanceId)));

            // Call the private method WorkerMethod in a WebWorker thread using a Delegate
            Console.WriteLine(await WebWorkerService.TaskPool.Invoke(WorkerMethod, WebWorkerService.InstanceId));
        }
    }
}
