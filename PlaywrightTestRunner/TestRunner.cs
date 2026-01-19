using Microsoft.Playwright;
using System.Diagnostics;
using System.Xml.Linq;

namespace PlaywrightTestRunner
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TestRunner : PageTest
    {
        // test port
        string dotnetVersion = "";
        static ushort _port = 32301;
        StaticFileServer? staticFileServer;
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
            // The GitHub action in this project that runs tests sets the enviroment BASE_URL value with the url of the server it has already started
            // if the environment variable is not found
            // this method will handle the steps the GitHub action normally handles: build publish version and host for testing
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BASE_URL")))
            {
                return;
            }

            // get the project being tested directory
            var projectDirectory = Path.GetFullPath(@"../../../../SpawnDev.BlazorJS.Demo");

            // start hosting the Blazor WASM app using dotnet
            // path to the Blazor WASM project file
            var projectPath = Path.Combine(projectDirectory, "SpawnDev.BlazorJS.Demo.csproj");

            // get the Blazor WASM project's dotnet version from its csproj file
            dotnetVersion = GetDotnetVersion(projectPath);

            // get wwwroot path
            var publishPath = Path.GetFullPath(Path.Combine(projectDirectory, $"bin/Release/{dotnetVersion}/publish/wwwroot"));

            // create https server for testing using StaticFileServer
            staticFileServer = new StaticFileServer(publishPath, BaseUrl);

            // start https server
            staticFileServer.Start();

            // wait for the server to start
            // use HttpClient to test for the server readiness
            using var httpClient = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
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
        public async Task StopApp()
        {
            // shutdown the Blazor WASM host
            if (staticFileServer != null)
            {
                await staticFileServer.Stop();
            }
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

        /// <summary>
        /// Gets the dotnet version from the csproj file
        /// </summary>
        /// <param name="projectPath">Path to the csproj file</param>
        /// <returns>The dotnet version</returns>
        private string GetDotnetVersion(string projectPath)
        {
            var xml = XDocument.Load(projectPath);
            var targetFramework = xml.Descendants("TargetFramework").FirstOrDefault();
            if (targetFramework == null)
            {
                throw new Exception("Could not find TargetFramework in csproj file");
            }
            return targetFramework.Value;
        }
    }
}
