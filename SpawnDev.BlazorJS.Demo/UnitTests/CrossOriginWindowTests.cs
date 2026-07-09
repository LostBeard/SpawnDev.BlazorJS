using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using Async = SpawnDev.BlazorJS.Toolbox.Async;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    public class CrossOriginWindowTests(BlazorJSRuntime JS)
    {

        [TestMethod]
        public async Task CrossOriginWindowTest()
        {
            var url = "https://www.googleapis.com/auth/youtube";

            var window = new Window();

            var popup = window.Open(url, "Google Auth", "height=800,width=1200");

            if (popup is not null)
            {
                await Task.Delay(2000);

                // Close the popup in 5 seconds
                _ = Async.RunAsync(async () =>
                {
                    await Task.Delay(5000);
                    try
                    {
                        popup!.Close();
                    }
                    catch { }
                });

                popup!.Focus();
                while (!popup.Closed)
                    await Task.Delay(1000);
            }
            else
            {
                throw new UnsupportedTestException("Failed to open popup. User interaction is required. Run test manually.");
            }
        }
    }
}
