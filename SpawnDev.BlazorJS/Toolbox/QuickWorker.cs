using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class QuickWorker
    {
        static string createObjectURLFuncName = null;
        public static Worker? CreateWorkerFromJS(string js)
        {
            if (createObjectURLFuncName == null)
            {
                if (!BlazorJSRuntime.JS.IsUndefined("URL.createObjectURL")) createObjectURLFuncName = "URL.createObjectURL";
                else if (!BlazorJSRuntime.JS.IsUndefined("webkitURL.createObjectURL")) createObjectURLFuncName = "webkitURL.createObjectURL";
                else createObjectURLFuncName = "";
            }
            if (string.IsNullOrEmpty(createObjectURLFuncName)) return null;
            using var blob = new Blob(new string[] { js }, new BlobOptions { Type = "application/javascript" });
            var objUrl = BlazorJSRuntime.JS.Call<string>(createObjectURLFuncName, blob);
            return new Worker(objUrl);
        }
    }
}
