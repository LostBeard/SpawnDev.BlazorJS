using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using Async = SpawnDev.BlazorJS.Toolbox.Async;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    public class CrossOriginWindowTests(BlazorJSRuntime JS)
    {
        /// <summary>
        /// Test for LostBeard/SpawnDev.BlazorJS#62 - Window Closed throws a SecurityError
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnsupportedTestException"></exception>
        [TestMethod]
        public async Task CrossOriginWindowTest()
        {
            var url = "https://www.googleapis.com/auth/youtube";

            var window = new Window();

            var popup = window.Open(url, "Google Auth", "height=800,width=1200");

            if (popup is not null)
            {
                // small delay used in this test to make sure the window is flagged as
                // cross-origin before the test runs, which is part of the cause of the original issue #62
                await Task.Delay(2000);

                // Close the popup in 5 seconds
                Async.Run(async () =>
                {
                    await Task.Delay(5000);
                    try
                    {
                        popup!.Close();
                    }
                    catch { }
                });

                // try set focused
                popup!.Focus();

                // wait for the window to close
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
