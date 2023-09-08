using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class QuickWorker
    {
        public static Worker? CreateWorkerFromJS(string js)
        {
            using var blob = new Blob(new string[] { js }, new BlobOptions { Type = "application/javascript" });
            var objUrl = URL.CreateObjectURL(blob);
            var ret = new Worker(objUrl);
            URL.RevokeObjectURL(objUrl);
            return ret;
        }
    }
}
