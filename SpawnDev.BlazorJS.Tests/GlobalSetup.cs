namespace SpawnDev.BlazorJS.Tests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            // This tells Playwright to run in headed mode for the entire test run
            //Environment.SetEnvironmentVariable("HEADED", "1");
            Environment.SetEnvironmentVariable("PLAYWRIGHT_ARGS", "--use-fake-ui-for-media-stream --use-fake-device-for-media-stream");
        }
    }
}
