using Microsoft.Playwright;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        // test port
        static ushort _port = 32301;
        private Process? _webServerProcess;
        protected string BaseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? $"https://localhost:{_port}";

        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions
            {
                IgnoreHTTPSErrors = true,
            };
        }
        /// <summary>
        /// Starts serving the Blazor WebAssembly app using dotnet and waits for it to be ready for a max amount of time
        /// </summary>
        [OneTimeSetUp]
        public async Task StartApp()
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BASE_URL")))
            {
                return;
            }
            // start hosting the Blazor WASM app using dotnet
            // path to the Blazor WASM project file
            var projectPath = Path.GetFullPath(@"../../../../SpawnDev.BlazorJS.Demo/SpawnDev.BlazorJS.Demo.csproj");
            _webServerProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
#if DEBUG
                    Arguments = $"run --project \"{projectPath}\" --urls \"{BaseUrl}\"",
#else
                    Arguments = $"run --configuration Release --no-build --project \"{projectPath}\" --urls \"{BaseUrl}\"",
#endif
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            _webServerProcess.Start();
            // wait a few seconds for the Blazor app to warm up
            // use HttpClient to test for the server readiness
            using var httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed < TimeSpan.FromSeconds(30))
            {
                try
                {
                    using var response = await httpClient.GetAsync(BaseUrl).WaitAsync(TimeSpan.FromSeconds(2));
                    if (response?.IsSuccessStatusCode == true)
                    {
                        break;
                    }
                }
                catch { }
                await Task.Delay(1000);
            }
        }
        /// <summary>
        /// Shutdown Blazor WASM host process
        /// </summary>
        [OneTimeTearDown]
        public void StopApp()
        {
            // shutdown the Blazor WASM host
            _webServerProcess?.Kill();
            _webServerProcess?.Dispose();
        }
        /// <summary>
        /// Runs all tests in Home.razor > UnitTestsView component one at a time
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Test]
        public async Task RunAllTestsInTable_ShouldSucceed()
        {
            await Page.GotoAsync(BaseUrl);

            // get the table
            var table = Page.Locator("table.unit-test-view");

            // wait for the table to finish rendering
            await Expect(table).ToHaveClassAsync(new Regex("unit-test-ready"), new() { Timeout = 10000 });

            // get table body
            var tbody = table.Locator("tbody");

            // get all rows in the target table body
            var rows = tbody.Locator("tr");

            // iterate the rows
            int rowCount = await rows.CountAsync();
            for (int i = 0; i < rowCount; i++)
            {
                // get the specific row by index
                var currentRow = rows.Nth(i);

                // find the button within THIS specific row
                var runButton = currentRow.GetByRole(AriaRole.Button, new() { Name = "Run" });

                // click the button to start the process for this row
                await runButton.ClickAsync();

                // assert that the row eventualyl gets the class 'test-state-done'
                await Expect(currentRow).ToHaveClassAsync(new Regex("test-state-done"), new() { Timeout = 10000 });

                // get test type name
                var typeName = await currentRow.Locator(".test-type-name").TextContentAsync();

                // get test method name
                var methodName = await currentRow.Locator(".test-method-name").TextContentAsync();

                try
                {
                    // verify success
                    await Expect(currentRow).ToHaveClassAsync(new Regex("test-success"));
                }
                catch (Exception ex)
                {
                    // throw an error with details about the TestMethod that failed
                    throw new Exception($"Failed - {typeName}.{methodName} {ex.ToString()}");
                }
            }
        }
    }
}
