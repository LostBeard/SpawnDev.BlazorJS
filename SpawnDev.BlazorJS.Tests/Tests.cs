using Microsoft.Playwright;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        static ushort _port = 32322;
        private Process? _webServerProcess;
        protected string BaseUrl = $"https://localhost:{_port}"; // Match your app's port

        [OneTimeSetUp]
        public void StartApp()
        {
            // Path to your Blazor Host/Server project file
            var projectPath = Path.GetFullPath(@"../../../../SpawnDev.BlazorJS.Demo/SpawnDev.BlazorJS.Demo.csproj");

            _webServerProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"run --project \"{projectPath}\" --urls \"{BaseUrl}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            _webServerProcess.Start();

            // Wait a few seconds for the Blazor app to warm up
            Thread.Sleep(5000);
        }

        [OneTimeTearDown]
        public void StopApp()
        {
            _webServerProcess?.Kill();
            _webServerProcess?.Dispose();
        }
        [Test]
        public async Task RunAllTestsInTable_ShouldSucceed()
        {
            await Page.GotoAsync($"https://localhost:{_port}/");

            var table = Page.Locator("table.unit-test-view");

            // wait for the table to render
            await Expect(table).ToHaveClassAsync(new Regex("unit-test-ready"), new() { Timeout = 10000 });

            // 1. Locate all rows in the target table body
            // It's better to use a specific ID or TestId to find the table
            var tbody = table.Locator("tbody");

            var rows = tbody.Locator("tr");

            // 2. Count the rows to iterate through them
            int rowCount = await rows.CountAsync();

            for (int i = 0; i < rowCount; i++)
            {
                // Get the specific row by index
                var currentRow = rows.Nth(i);

                int currentRowCount = await currentRow.CountAsync();
                
                // 3. Find the button within THIS specific row
                var runButton = currentRow.GetByRole(AriaRole.Button, new() { Name = "Run" });
                int runButtonCount = await runButton.CountAsync();

                // Click the button to start the process for this row
                await runButton.ClickAsync();

                // Assert that the text eventually changes to "Complete"
                // Playwright will automatically retry this assertion for up to 10 seconds
                await Expect(currentRow).ToHaveClassAsync(new Regex("test-state-done"), new() { Timeout = 10000 });

                var typeName = await currentRow.Locator(".test-type-name").TextContentAsync();
                var methodName = await currentRow.Locator(".test-method-name").TextContentAsync();

                try
                {
                    // Verify specific success styling
                    await Expect(currentRow).ToHaveClassAsync(new Regex("test-success"));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed - {typeName}.{methodName}");
                }
            }
        }
    }
}
